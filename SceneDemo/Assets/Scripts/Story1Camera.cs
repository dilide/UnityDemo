using UnityEngine;
using System.Collections;
using System.Xml;

public class Story1Camera : MonoBehaviour {
	public GameObject sun;
	public GameObject girlSheep;
	public GameObject boySheep;
	public float lastTouchTime = 0;
	public float touchInterval = 2;

	public Story story;
	
	// Following method is used to retrive the relative path as device platform
	private string getPath(){
		#if UNITY_EDITOR
		return Application.dataPath;
		#elif UNITY_ANDROID
		return Application.persistentDataPath;
		#elif UNITY_IPHONE
		return GetiPhoneDocumentsPath()+"/";
		#else
		return Application.dataPath +"/";
		#endif
	}
	
	void LoadStory()
	{
		XmlDocument doc = new XmlDocument ();
		string strPath = getPath() + "/Res/Story1/story.xml";
		doc.Load (strPath);
		XmlElement eleDoc = doc.DocumentElement;

		if (eleDoc == null)
			return;

		XmlElement eleSegment = eleDoc["segment"];
		while (eleSegment != null) {
			StorySegment seg = new StorySegment();

			XmlElement eleTalking = eleSegment["talking"];
			if(eleTalking != null)
			{
				XmlElement sheep = (XmlElement)eleTalking.FirstChild;
				while(sheep != null)
				{
					seg.talking.Add(sheep.InnerText);
					sheep = (XmlElement)sheep.NextSibling;
				}
			}

			XmlElement eleShutup = eleSegment["shutup"];
			if(eleShutup != null)
			{
				XmlElement sheep = (XmlElement)eleShutup.FirstChild;
				while(sheep != null)
				{
					seg.shutup.Add(sheep.InnerText);
					sheep = (XmlElement)sheep.NextSibling;
				}
			}

			seg.content = eleSegment["content"].InnerText;

			story.segments.Add(seg);
			eleSegment = (XmlElement)eleSegment.NextSibling;
		}

		PlayNext ();
	}

	// Use this for initialization
	void Start () {
		story = new Story ();
		LoadStory ();
	}


	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		bool touched = Input.GetButton ("Fire1");
		if (touched && (lastTouchTime + touchInterval) < Time.time) {
			lastTouchTime = Time.time;
			PlayNext();
		}
	}

	void OnGUI()
	{
		StorySegment seg = story.CurrentSegment;
		if (seg != null) {
			Debug.Log (seg.content);
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
