using UnityEngine;
using System.Collections;

public class TeleportButton : MonoBehaviour, IGvrGazeResponder {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnGazeEnter(){
		print ("Respawning");
		player.transform.position = new Vector3 (0, 2, 0);
	}

	public void OnGazeExit(){

	}

	public void OnGazeTrigger(){

	}
}
