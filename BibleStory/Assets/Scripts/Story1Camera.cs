using UnityEngine;
using System.Collections;
using System.Xml;

public class Story1Camera : MonoBehaviour {
	public GameObject sun;
	public GameObject girlSheep;
	public GameObject boySheep;
	public float lastTouchTime = 0;

	public Story story = null;
	
	void LoadStory()
	{
		XmlDocument doc = new XmlDocument ();
		TextAsset textStory = (TextAsset)Resources.Load ("story/story-1");
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
		if (story == null)
			return;

		if (story.CurrentSegment == null)
			return;

		bool touched = Input.GetButton ("Fire1");

		if (touched && (lastTouchTime + story.CurrentSegment.interval) < Time.time) {
			lastTouchTime = Time.time;
			PlayNext();
		}
	}

	void PlayNext()
	{
		StorySegment seg = story.PlayNext ();
		if (seg == null)
			return;
		Debug.Log ("Play next");


		//set talking sheep;
		foreach(string sheep in seg.talking)
		{
			GameObject obj = GameObject.Find(sheep);
			if(obj)
			{
				ISheep s = (ISheep)obj.GetComponent (typeof(ISheep));
				if (s != null) {
					s.Talk(true);
					s.SetBubbleVisible(true);
					s.SetBubbleContent(seg.content);
					s.SetAudio2Play(seg.audio);
				}
			}
		}


		//set shutup sheep;
		foreach(string sheep in seg.shutup)
		{
			GameObject obj = GameObject.Find(sheep);
			if(obj)
			{
				ISheep s = (ISheep)obj.GetComponent (typeof(ISheep));
				if (s != null) {
					s.Talk(false);
					s.SetBubbleVisible(false);
					s.SetBubbleContent("");
				}
			}
		}
	}
}
