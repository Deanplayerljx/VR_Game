using UnityEngine;
using System.Collections;

public class CantLookLong : MonoBehaviour, IGvrGazeResponder {

	private bool isGazed = false;

	private float spinSpeed = 0.0f;
	private float minSpinSpeed = 0.0f;
	private float maxSpinSpeed = 120.0f;
	private float spinAccel = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (isGazed) {
			spinSpeed = Mathf.Min (maxSpinSpeed, spinSpeed + spinAccel);
		} else {
			spinSpeed = Mathf.Max (minSpinSpeed, spinSpeed - spinAccel);
		}

		this.transform.Rotate(new Vector3(0.0f, spinSpeed, 0.0f));
	}

	public void OnGazeEnter(){
		isGazed = true;
	}

	public void OnGazeExit(){
		isGazed = false;
	}
		
	public void OnGazeTrigger(){

	}
		
}
