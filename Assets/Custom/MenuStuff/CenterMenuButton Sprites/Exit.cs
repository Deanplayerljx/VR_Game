using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour, IGvrGazeResponder {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnGazeEnter(){
		Application.Quit();
	}

	public void OnGazeExit(){

	}

	public void OnGazeTrigger(){

	}
}