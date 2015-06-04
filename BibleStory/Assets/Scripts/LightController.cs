using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour,IPlayer {
	public bool playing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		gameObject.GetComponent<Renderer>().enabled = playing;
	}

	public void setPlaying(bool _playing)
	{
		playing = _playing;
	}
	public bool isPlaying()
	{
		return playing;
	}
}
