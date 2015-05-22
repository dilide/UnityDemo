using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Story {
	public List<StorySegment> segments;
	private int currentSegIndex = -1;


	public Story()
	{
		segments = new List<StorySegment> ();
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
