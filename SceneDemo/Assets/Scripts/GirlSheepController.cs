using UnityEngine;
using System.Collections;

public class GirlSheepController : MonoBehaviour, ISheep {
	public bool talking = false;
	public GameObject sheepMouth;
	public GameObject bubble;
	private string content;
	private AudioSource audio2Play = null;

	// Use this for initialization
	void Start () {
		sheepMouth.GetComponent<Animator> ().SetBool("isTalking",talking);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}
	
	void OnGUI(){
		DisplayContent ();
	}
	
	void DisplayContent()
	{
		if (content == "")
			return;
		
		GUIStyle style = new GUIStyle ();
		style.fontSize = 24;
		style.fontStyle = FontStyle.Bold;
		style.font = (Font)Resources.Load("Fonts/WawaSC-Regular");
		style.normal.textColor = new Color(255,0,0);
		
		Vector3 point = Camera.main.WorldToScreenPoint (bubble.transform.position);
		Vector3 size = Camera.main.WorldToScreenPoint(bubble.transform.localScale);
		
		Rect labelRect = new Rect (point.x - size.x*0.3f, point.y - size.y*1.0f, 10, size.y);
		GUI.Label (labelRect, content, style);
	}

	public void Talk(bool bTalk)
	{
		talking = bTalk;
		sheepMouth.GetComponent<Animator> ().SetBool("isTalking",talking);
		if (talking == false) {
			if(audio2Play != null)
			{
				audio2Play.Stop();
				audio2Play.clip = null;
			}
		}
	}

	public bool isTalking()
	{
		return talking;
	}
	
	public void SetBubbleVisible(bool visible)
	{
		bubble.GetComponent<Renderer>().enabled = visible;
	}
	
	public void SetBubbleContent(string text)
	{
		content = text;
	}
	
	public void SetAudio2Play(string auPath){
		if (audio2Play == null) {
			audio2Play = (AudioSource)gameObject.AddComponent <AudioSource>();
			audio2Play.loop = false;
		}
		
		AudioClip clip = (AudioClip)Resources.Load(auPath);
		if (clip == null)
			return;

		audio2Play.clip = clip;
		audio2Play.Play ();
	}
}
