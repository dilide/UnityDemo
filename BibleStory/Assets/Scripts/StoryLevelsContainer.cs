using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryLevelsContainer : MonoBehaviour {
	public GameObject storyLevelModel;
	public List<GameObject> storyLevels;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		bool isTouched = Input.GetButton ("Fire1");
		if (!isTouched) {
			return;
		}
		
		Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		
		Collider2D[] currentButtons = Physics2D.OverlapPointAll(touchPos);
		foreach (var obj in currentButtons) {
			StoryLevelSelector story = (StoryLevelSelector)obj.GetComponent(typeof(StoryLevelSelector));

			if(story != null)
			{
				Application.LoadLevel("Story-1-1");
			}
		}
	}
}
