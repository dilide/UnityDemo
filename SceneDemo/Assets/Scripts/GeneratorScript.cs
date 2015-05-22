using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratorScript : MonoBehaviour {
	private float screenWidthInPoints;

	public GameObject[] availableClouds;
	public List<GameObject> currentClouds;
	public int cloudCount = 100;
	public float minPosY = 1.5f;
	public float maxPosY = 4.5f;


	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate()
	{
		GenerateCloudsIfRequired ();
	}

	void GenerateCloudsIfRequired()
	{
		List<GameObject> cloudsToRemove = new List<GameObject> ();
		float cameraX = transform.position.x;
		float removeCloudX = cameraX - screenWidthInPoints*0.5f;

		foreach (var cloud in currentClouds) {
			float cloudWidth = cloud.transform.localScale.x;
			float cloudStartX = cloud.transform.position.x - (cloudWidth*0.5f);
			float cloudEndX = cloudStartX + cloudWidth;

			if(cloudEndX < removeCloudX)
				cloudsToRemove.Add(cloud);
		}

		foreach (var cloud in cloudsToRemove) {
			currentClouds.Remove(cloud);
			Destroy(cloud);
		}

		while (currentClouds.Count < cloudCount) {
			int randmoIndex = Random.Range(0, availableClouds.Length);
			GameObject cloud = (GameObject)Instantiate(availableClouds[randmoIndex]);
			Vector3 pos = new Vector3(cameraX+screenWidthInPoints*0.5f+cloud.transform.localScale.x,Random.Range(minPosY,maxPosY),-10);
			cloud.transform.position = pos;

			CloudController cc = (CloudController)cloud.GetComponent(typeof(CloudController));
			if(cc != null)
			{
				cc.moveSpeed = Random.Range(0.1f,1.5f);
			}


			currentClouds.Add(cloud);
		}
	}
}
