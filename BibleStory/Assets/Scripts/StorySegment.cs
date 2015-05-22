using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class StorySegment{
	public List<string> talking;
	public List<string> shutup;
	public string content;
	public string audio;
	public int interval = 0;

	public StorySegment(XmlElement eleSegment)
	{
		talking = new List<string> ();
		shutup = new List<string> ();
		content = "";
		audio = "";

		XmlElement eleTalking = eleSegment["talking"];
		if(eleTalking != null)
		{
			XmlElement sheep = (XmlElement)eleTalking.FirstChild;
			while(sheep != null)
			{
				talking.Add(sheep.InnerText);
				sheep = (XmlElement)sheep.NextSibling;
			}
		}
		
		XmlElement eleShutup = eleSegment["shutup"];
		if(eleShutup != null)
		{
			XmlElement sheep = (XmlElement)eleShutup.FirstChild;
			while(sheep != null)
			{
				shutup.Add(sheep.InnerText);
				sheep = (XmlElement)sheep.NextSibling;
			}
		}

		XmlElement eleContent = eleSegment["content"];
		if (eleContent != null)
			content = eleContent.InnerText;

		XmlElement eleAudio = eleSegment["audio"];
		if(eleAudio != null)
			audio = eleAudio.InnerText;

		XmlElement eleInterval = eleSegment ["interval"];
		if (eleInterval != null) {
			interval = System.Convert.ToInt32(eleInterval.InnerText);
		}
	}
}
