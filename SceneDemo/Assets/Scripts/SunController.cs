using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour,IPlayer {
	bool isPlaying = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{

	}

	public void Play()
	{
		isPlaying = !isPlaying;
		Debug.Log ("Play trigger...");
	}
}
