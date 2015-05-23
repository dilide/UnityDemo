using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour,IPlayer {
	public GameObject objSunlight;
	public GameObject objSunface;

	public bool isPlaying = false;
	private bool isForward = true;

	private float lastPlayTime = 0;
	private float currentPlayTime = 5;
	private float minPlayTime = 3;
	private float maxPlayTime = 7;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if (isPlaying) {
			if(lastPlayTime+currentPlayTime < Time.time)
			{
				lastPlayTime = Time.time;
				currentPlayTime = Random.Range(minPlayTime, maxPlayTime);
				isForward = !isForward;
			}

			if(isForward)
			{
				objSunlight.transform.Rotate (0, 0, Time.deltaTime * Random.Range(10, 50));
			}
			else
			{
				objSunlight.transform.Rotate (0, 0, -Time.deltaTime * Random.Range(10, 50));
			}
		}
	}
	
	public void setPlaying(bool _playing)
	{
		isPlaying = _playing;
	}
}
