using UnityEngine;
using System.Collections;

public class StoryMenu : MonoBehaviour {
	public string nextLevel = "Story-1-2";


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void btnBackClicked()
	{
		Application.LoadLevel("Loading");
	}

	public void btnNextClicked()
	{
		Application.LoadLevel (nextLevel);
	}
}
