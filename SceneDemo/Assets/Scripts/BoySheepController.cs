using UnityEngine;
using System.Collections;

public class BoySheepController : MonoBehaviour, ISheep {
	public bool talking = false;
	public GameObject sheepMouth;
	public GameObject bubble;
	private string content = "";

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
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.font.name = "";
		style.normal.textColor = Color.black;

		Vector3 point = Camera.main.WorldToScreenPoint (bubble.transform.position);

		Rect labelRect = new Rect (point.x - 180, point.y - 350, 600, 320);
		GUI.Label (labelRect, content, style);
	}


	public void Talk(bool bTalk)
	{
		talking = bTalk;
		sheepMouth.GetComponent<Animator> ().SetBool("isTalking",talking);
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
}
