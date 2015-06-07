using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginController : MonoBehaviour {

	public InputField kidname;
	public Toggle sexGirl;
	public Toggle sexBoy;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnBtnOK()
	{
		if (kidname.text == "")
			return;

		string sex = "girl";
		if (sexBoy.isOn)
			sex = "boy";

		PlayerPrefs.SetString ("KidName", kidname.text);
		PlayerPrefs.SetString ("Sex", sex);
		
		Application.LoadLevel("Loading");
	}
}
