using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Story {
	public List<StorySegment> segments;
	private int currentSegIndex = -1;


	public Story(XmlElement eleStory)
	{
		segments = new List<StorySegment> ();

		XmlElement eleSegment = eleStory["segment"];
		while (eleSegment != null) {
			StorySegment seg = new StorySegment(eleSegment);

			segments.Add(seg);
			eleSegment = (XmlElement)eleSegment.NextSibling;
		}
	}

	public StorySegment CurrentSegment
	{
		get{
			if(currentSegIndex >= 0 && currentSegIndex < segments.Count)
				return segments[currentSegIndex];
			return null;
		}
	}


	public StorySegment PlayNext()
	{
		currentSegIndex++;

		return CurrentSegment;
	}
}
