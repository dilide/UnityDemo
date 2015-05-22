using UnityEngine;
using System.Collections;

public class MainLevelSelector : MonoBehaviour {
	Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}

	void OnGUI(){
		DisplayLevelSelector ();
	}

	void DisplayLevelSelector(){
		RectTransform rtTransform = GetComponent<RectTransform>();
		Vector3 point = Camera.main.WorldToScreenPoint (transform.position);

		scrollPosition = GUI.BeginScrollView ( new Rect(point.x - rtTransform.sizeDelta.x/2,point.y-rtTransform.sizeDelta.y/2,rtTransform.sizeDelta.x,rtTransform.sizeDelta.y),
		                                      scrollPosition, new Rect (10, 0, rtTransform.sizeDelta.x - 20, 50*10+60));

		for (int i=0; i<10; ++i) {
			Rect btnRect = new Rect(10,30+50*i,rtTransform.sizeDelta.x-20,40);
			if(GUI.Button(btnRect, "Level " + (i+1).ToString()))
			{
				Application.LoadLevel("Story-1-1");
			}
		}
		GUI.EndScrollView ();
	}
}
