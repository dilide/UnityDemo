using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//
	void FixedUpdate(){
//		System.Console.WriteLine("update...");
		bool sunActive = Input.GetButton ("Fire1");
		if (!sunActive) {
			return;
		}
		Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		
		Collider2D[] currentButtons = Physics2D.OverlapPointAll(touchPos);
		foreach (var obj in currentButtons) {
			IPlayer p = (IPlayer)obj.GetComponent(typeof(IPlayer));
			if(p!=null)
			{
				p.Play();
			}
		}
	}
}
