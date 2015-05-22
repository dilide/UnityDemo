using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
	public float moveSpeed = 1.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		Vector3 pos = transform.position;
		float fDelta = Time.deltaTime * moveSpeed;
		pos.x = pos.x - fDelta;
		transform.position = pos;
	}
}
