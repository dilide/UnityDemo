using UnityEngine;
using System.Collections;

public class LoadingCamera : MonoBehaviour {
	public GameObject login;
	public GameObject menu;
	public GameObject levels;

	// Use this for initialization
	void Start () {
		string kidname = PlayerPrefs.GetString ("KidName", "");

		if (kidname == "") {
			login.SetActive (true);
			menu.SetActive (false);
			levels.SetActive(false);
		} else {
			login.SetActive (false);
			menu.SetActive (true);
			levels.SetActive(true);
		}
		login.SetActive (kidname == "");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//
	void FixedUpdate(){
//		System.Console.WriteLine("update...");
		bool touched = Common.isTouched ();
		if (!touched) {
			return;
		}

		Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		
		Collider2D[] currentButtons = Physics2D.OverlapPointAll(touchPos);
		foreach (var obj in currentButtons) {
			IPlayer p = (IPlayer)obj.GetComponent(typeof(IPlayer));
			if(p!=null)
			{
				p.setPlaying(!(p.isPlaying()));
			}
		}
	}
}
