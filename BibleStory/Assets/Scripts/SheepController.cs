using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SheepController : MonoBehaviour, ISheep {
	public GameObject sheepMouth;
	public GameObject bubble;
	public Text textContent;
	public StoryPerson storyPerson;

	private bool talking = false;
	private AudioSource audio2Play = null;

	SheepController()
	{
	}

	// Use this for initialization
	void Start () {
		audio2Play = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio2Play.loop = false;
		
		Animator ani = sheepMouth.GetComponent<Animator> ();
		if(ani != null)
			ani.SetBool("isTalking",talking);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		if (talking != audio2Play.isPlaying) {
			talking = audio2Play.isPlaying;
			Animator ani = sheepMouth.GetComponent<Animator> ();
			if(ani != null)
				ani.SetBool("isTalking",talking);
		}

		if (audio2Play.isPlaying) {
			if(audio2Play.time < storyPerson.auBegin)
				audio2Play.time = storyPerson.auBegin;
			if(audio2Play.time > storyPerson.auEnd)
				audio2Play.Stop();
		}
	}
	
	void OnGUI(){
//		DisplayContent ();
	}
	
	public void Talk(StoryPerson person)
	{
		storyPerson = person;
		if (storyPerson == null || storyPerson.audio == "") {
			SetBubbleContent("",0);
			if(audio2Play != null)
			{
				audio2Play.Stop();
			}
			return;
		}

		StartCoroutine(SetAudio (storyPerson.audio));
		SetBubbleContent(storyPerson.content,storyPerson.fontSize);
	}

	public bool isTalking()
	{
		return talking;
	}

	protected void SetBubbleContent(string text, int fontsize)
	{
		textContent.text = text;
		if (text == null || text == "") {
			bubble.GetComponent<Renderer> ().enabled = false;
			textContent.enabled = false;
		} else {
			bubble.GetComponent<Renderer> ().enabled = true;
			textContent.enabled = true;
			textContent.fontSize = fontsize;
		}
	}

	protected IEnumerator SetAudio(string auPath)
	{
		ResourceRequest req = Resources.LoadAsync (auPath);
		while (!req.isDone) {
			yield return 0;
		}
		
//		AudioClip clip = (AudioClip)Resources.Load(auPath);
		AudioClip clip = (AudioClip)req.asset;
		if (clip == null) {
			audio2Play.Stop();
			SetBubbleContent("",0);
			return false;
		}

		audio2Play.clip = clip;
		audio2Play.Play ();
		return true;
	}
}
