using UnityEngine;
using System.Collections;

public class GirlSheepController : MonoBehaviour, ISheep {
	public bool talking = false;
	public GameObject sheepMouth;
	public GameObject bubble;
	private string content;

	// Use this for initialization
	void Start () {
		sheepMouth.GetComponent<Animator> ().SetBool("isTalking",talking);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

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
