using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorySegment{
	public List<string> talking;
	public List<string> shutup;
	public string content;

	public StorySegment()
	{
		talking = new List<string> ();
		shutup = new List<string> ();
		content = "";
	}
}
