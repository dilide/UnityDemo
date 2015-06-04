using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class StorySpeaker : MonoBehaviour {
	public GameObject girlSheep;
	public GameObject boySheep;
	public float lastTouchTime = 0.0f;
	public float interval = 0.5f;
	public string storyXml = "story/story-1-1";

	private Story story = null;
	
	void LoadStory()
	{
		XmlDocument doc = new XmlDocument ();
		TextAsset textStory = (TextAsset)Resources.Load (storyXml);
		doc.LoadXml (textStory.text);
		XmlElement eleDoc = doc.DocumentElement;

		if (eleDoc == null)
			return;

		story = new Story (eleDoc);

		PlayNext ();
	}

	// Use this for initialization
	void Start () {
		LoadStory ();
	}


	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (story == null || story.CurrentSegment == null)
			return;

		bool touched = Common.isTouched ();

		if (touched == false)
			return;

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if(hit.collider != null)
		{
			return;
		}

		PlayNext ();
	}

	void PlayNext()
	{
		StorySegment seg = story.PlayNext ();
		if (seg == null) {
			GameObject menu = GameObject.Find("StoryMenu");
			if(menu != null)
			{
				StoryMenu mm = menu.GetComponent<StoryMenu>();
				if(mm != null)
				{
					mm.btnNextClicked();
				}
			}

			return;
		}
		Debug.Log ("Play next");


		List<GameObject> allPersons = new List<GameObject> ();
		allPersons.AddRange(GameObject.FindGameObjectsWithTag ("person"));

		//set talking sheep;
		foreach(StoryPerson p in seg.talking)
		{
			GameObject obj = GameObject.Find(p.name);
			if(obj)
			{
				ISheep s = (ISheep)obj.GetComponent (typeof(ISheep));
				if (s != null) {
					s.Talk(p);

					allPersons.Remove(obj);
				}
			}
		}

		//set shutup sheep;
		foreach(GameObject obj in allPersons)
		{
			if(obj)
			{
				ISheep s = (ISheep)obj.GetComponent (typeof(ISheep));
				if (s != null) {
					s.Talk(null);
				}
			}
		}


		//set player
		foreach(StoryPlayer p in seg.players)
		{
			GameObject obj = GameObject.Find(p.name);
			if(obj)
			{
				IPlayer pp = (IPlayer)obj.GetComponent(typeof(IPlayer));
				if(pp != null)
				{
					pp.setPlaying(p.isPlaying);
				}
			}
		}
	}
}
