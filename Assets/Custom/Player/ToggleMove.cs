using UnityEngine;
using System.Collections;

public class ToggleMove : MonoBehaviour {
	bool moving = false;
	bool toggleMoveOn = true;
	bool buttonPressed;

	static float longPressTime = 2.0f; //length of a press of the magnet button to count as a "long press" event.
	bool held = false;
	float pressStart; //the start time of the most recent press

	bool menuHeld = false;

	bool menuActive = false;
	Transform centerMenu;
	Transform leftMenu;
	Transform rightMenu;

	const float speed = 5.0f; //in m/s
	Camera mainCam;

	bool underWater;
	//GameObject curWater;

	// Use this for initialization
	void Start () {
		mainCam = FindObjectOfType<Camera> ();

		centerMenu = transform.FindChild ("QuickMenu");
		leftMenu = transform.FindChild ("ColorMenu");
		rightMenu = transform.FindChild ("InventoryMenu");
	}
	
	// Update is called once per frame
	void Update () {
		//Fake Menu activation code

		//Respawns if player falls off edge
		if (mainCam.transform.position.y < -50) {
			moving = false;
			transform.position = new Vector3 (0, 2, 0);
		}

		buttonPressed = /*CardboardMagnetSensor.CheckIfWasClicked () ||*/ Input.GetMouseButton(0) || Input.touchCount>0;// || PhoneScreenTouchStart || ClickStart
		if (!buttonPressed && held) {
			held = false;
			if (menuHeld) menuHeld = false;

			//Short press to start/stop moving, long press to toggle on or off this script.
			if (menuActive) { //This ends the menu
				//DeactivateMenu ();
			} else {//activates on short press
				if (toggleMoveOn) {
					print ("Toggling Move");
					moving = !moving;
				}
			}
		}

		if (buttonPressed && !held) {
			held = true;
			pressStart = Time.time;
		}

		//activates on longpress
		if (buttonPressed && (Time.time - pressStart) > longPressTime) {
			//This is the menu, most of these functions do nothing right now.
			if (!menuHeld) {
				menuHeld = true;
				if (menuActive)
					DeactivateMenu ();
				else
					ActivateMenu ();
			}
		}
			
		//
		if (toggleMoveOn) {
			//Move if the moving modifier is on
			if (moving) {
				mainCam = FindObjectOfType<Camera> ();
				if (underWater)
					transform.position += mainCam.transform.forward * speed * Time.deltaTime;
				else
					transform.position += new Vector3 (mainCam.transform.forward.x, 0, mainCam.transform.forward.z) * speed * Time.deltaTime;
			}
		}

		underWater = this.transform.position.y <= 1;
		/* Old underwater code
		if (curWater && (mainCam.transform.position.y < curWater.transform.position.y)) {
			if (!underWater) { // turn on underwater effect only once
				underWater = true;
				print("Entering Water");
			}
		} else { // but if it's not underwater...
			if (underWater) { // turn off underwater effect, if any
				underWater = false;
				print("Exiting Water");
			}
		}
		*/
	}

	public void ActivateMenu(){
		print ("Activating Menu");
		menuActive = true;
		//Disable movement
		moving = false;
		toggleMoveOn = false;

		//Lock to player
		leftMenu.GetComponent<MenuTracking>().PlayerLock();
		rightMenu.GetComponent<MenuTracking>().PlayerLock ();
		centerMenu.GetComponent<MenuTracking>().PlayerLock ();

		//Activate the menu graphics here
		centerMenu.GetComponent<MenuTracking>().Activate();
		rightMenu.GetComponent<MenuTracking>().Activate();
		leftMenu.GetComponent<MenuTracking>().Activate();


	}

	public void DeactivateMenu(){
		print ("Deactivating Menu");
		menuActive = false;
		//lock to camera
		leftMenu.GetComponent<MenuTracking>().CameraLock();
		rightMenu.GetComponent<MenuTracking> ().CameraLock ();
		centerMenu.GetComponent<MenuTracking> ().CameraLock ();

		//Disable the menu graphics
		centerMenu.GetComponent<MenuTracking>().Deactivate();
		rightMenu.GetComponent<MenuTracking>().Deactivate();
		leftMenu.GetComponent<MenuTracking>().Deactivate();

		//Enable movement
		toggleMoveOn = true;
		moving = false; //Make sure you don't start moving instantly.
	}
	/*
	void OnTriggerEnter(Collider other){
		if (other.tag=="Water"){ // if entering a waterplane
			if (transform.position.y < other.transform.position.y){
				// set reference to the current waterplane
				curWater = other.gameObject;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject==curWater){ // if exiting the waterplane...
			if (transform.position.y > curWater.transform.position.y){
				//  null the current waterplane reference
				curWater = null; 
			}
		}
	}
	*/
}
