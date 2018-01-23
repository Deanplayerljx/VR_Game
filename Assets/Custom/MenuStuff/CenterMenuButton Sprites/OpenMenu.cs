using UnityEngine;
using System.Collections;

public class OpenMenu : MonoBehaviour, IGvrGazeResponder {

	public GameObject menu;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnGazeEnter(){
		print ("Opening: " + menu.name);
		menu.GetComponent<MenuTracking> ().Activate ();
	}

	public void OnGazeExit(){

	}

	public void OnGazeTrigger(){

	}
}
