using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour,IPlayer {
	public bool isPlaying = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		gameObject.GetComponent<Renderer>().enabled = isPlaying;
	}

	public void setPlaying(bool _playing)
	{
		isPlaying = _playing;
	}
}
