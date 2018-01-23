using UnityEngine;
using System.Collections;

public class MenuTracking : MonoBehaviour {

	public Camera cam; //Lock to this when 
	public Transform playerTransform;
	public bool camLocked;

	//public Vector3 relativePosition;
	//public Vector3 relativeRotation;

	// Use this for initialization
	void Start () {
		//Take the initial position of the menu so that it
		//can be reattached to the camera

		//Attach to camera for tracking purposes
		//From FPSCanvasTracking.cs
		if (cam == null) {
			cam = this.transform.parent.FindChild("Main Camera").GetComponent<Camera>();
		}
		if (playerTransform == null) {
			playerTransform = this.transform.parent;
		}
		if (cam != null) {
			// Tie this to the camera, and do not keep the local orientation.
			CameraLock();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CameraLock(){
		transform.SetParent (cam.GetComponent<Transform> (), true);
		camLocked = true;
		//Deactivate ();
	}

	public void Deactivate(){
		transform.localScale = new Vector3 (0, 0, 0);
	}

	public void PlayerLock(){
		transform.SetParent (playerTransform.GetComponent<Transform> (), true);
		camLocked = false;
		//Activate ();
	}

	public void Activate(){
		transform.localScale = new Vector3 (1, 1, 1);
	}

}
