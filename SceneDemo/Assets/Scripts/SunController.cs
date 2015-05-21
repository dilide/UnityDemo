using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour,IPlayer {
	public GameObject objSunlight;
	public GameObject objSunface;

	private bool isPlaying = false;
	private int playCount = 0;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if (isPlaying) {
			if(playCount%2 == 0)
			{
				objSunlight.transform.Rotate (0, 0, Time.deltaTime * 100);
			}
			else
			{
				objSunlight.transform.Rotate (0, 0, -Time.deltaTime * 100);
			}
		}
	}

	public void Play()
	{
		isPlaying = !isPlaying;
		if (isPlaying)
			playCount++;
	}
}
