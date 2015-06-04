using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class StoryPerson
{
	public string name;
	public string audio;
	public string content;
	public int fontSize;
	public float auBegin;
	public float auEnd;

	public StoryPerson(string _name)
	{
		name = _name;
		audio = "";
		content = "";
		fontSize = 75;
		auBegin = 0.0f;
		auEnd = float.MaxValue;
	}
}

public class StoryPlayer
{
	public string name;
	public bool isPlaying;

	public StoryPlayer(string _name)
	{
		name = _name;
		isPlaying = false;
	}
}

public class StorySegment{
	public List<StoryPerson> talking;
	public List<StoryPlayer> players;

	public StorySegment(XmlElement eleSegment)
	{
		talking = new List<StoryPerson> ();
		players = new List<StoryPlayer> ();

		XmlElement eleTalking = eleSegment["talking"];
		if(eleTalking != null)
		{
			XmlElement elePerson = (XmlElement)eleTalking.FirstChild;
			while(elePerson != null)
			{
				XmlElement eleName = elePerson["name"];
				if(eleName != null)
				{
					StoryPerson p = new StoryPerson(eleName.InnerText);
					XmlElement eleAudio = elePerson["audio"];
					if(eleAudio != null)
					{
						p.audio = eleAudio.InnerText;
						XmlAttribute attBegin = eleAudio.Attributes["begin"];
						if(attBegin != null)
							p.auBegin = (float)System.Convert.ToDouble(attBegin.Value);

						XmlAttribute attEnd = eleAudio.Attributes["end"];
						if(attEnd != null)
							p.auEnd = (float)System.Convert.ToDouble(attEnd.Value);
					}

					XmlElement eleContent = elePerson["content"];
					if(eleContent != null)
						p.content = eleContent.InnerText;

					XmlElement eleFontSize = elePerson["fontsize"];
					if(eleFontSize != null)
						p.fontSize = System.Convert.ToInt32(eleFontSize.InnerText);

					talking.Add(p);
				}

				elePerson = (XmlElement)elePerson.NextSibling;
			}
		}
		
		XmlElement elePlayers = eleSegment["players"];
		if(elePlayers != null)
		{
			XmlElement elePlayer = (XmlElement)elePlayers.FirstChild;
			while(elePlayer != null)
			{
				XmlElement eleName = elePlayer["name"];
				if(eleName != null)
				{
					StoryPlayer p = new StoryPlayer(eleName.InnerText);

					XmlElement elePlaying = elePlayer["playing"];
					if(elePlaying != null)
					{
						p.isPlaying = System.Convert.ToBoolean(elePlaying.InnerText);
					}

					players.Add(p);
				}
				
				elePlayer = (XmlElement)elePlayer.NextSibling;
			}
		}
	}
}
