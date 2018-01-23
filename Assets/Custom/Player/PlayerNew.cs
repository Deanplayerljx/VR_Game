using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerNew : MonoBehaviour {

	private float playerMoney = 1000000;
	private int playerColor;
	public GameObject caps;
	public Dictionary<string,int> playerItems = new Dictionary<string,int>();
	public Dictionary<string,GameObject> playerItemObject = new Dictionary<string,GameObject>();
	private List<string> friendList = new List<string>();
	private Renderer renderer;
	private UnityEngine.Object[] prefabList;
	private float placeDistance = 1.00f;

	public Material[] materials;
	public Text moneyText;
	public Text ItemText;
	//private GameObject s;
	void Awake() 
	{
		prefabList = Resources.LoadAll("Prefabs", typeof(GameObject));
		Debug.Log (prefabList.Length);
		for (int i = 0; i < prefabList.Length; i++) {
			playerItemObject [prefabList [i].name] = (GameObject)prefabList [i];

		}
		playerItems ["Sphere"] = 5; 

	}

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		moneyText.text = "$" + playerMoney;
		renderer = caps.GetComponent<Renderer>();
		//moneyText.fontSize = 1;

	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.Alpha1)) {
//			setColor (1);
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha2)) {
//			setColor (2);
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha3)) {
//			setColor (3);
//		}

//		Vector3 fwd = transform.TransformDirection(Vector3.forward);
//		RaycastHit hit;
//		if (Physics.Raycast(transform.position, fwd, out hit, 200.0f))
//		{
//			if (hit.collider.isTrigger) {
//				hit.collider.gameObject.SetActive (false);
//				changeItem (hit.collider.gameObject.tag, 1, false, 100, hit.collider.gameObject);
////				Debug.Log (playerItemObject[hit.collider.gameObject.tag].tag);
//			}
//
//		}

		moneyText.text = "$" + playerMoney;
//		Debug.Log (Camera.main.gameObject.transform.position);
//		if (Input.GetKeyDown (KeyCode.Alpha4)) {
////			TestPrefab = (GameObject)Resources.Load("MyPrefab", typeof(GameObject));
////			s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			throwItem("Cube");
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha5)) {
//			//			TestPrefab = (GameObject)Resources.Load("MyPrefab", typeof(GameObject));
//			//			s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			throwItem("Sphere");
//		}
		//Debug.Log (Camera.main.gameObject.transform.position.x);
	}

	public void changeItem(string itemName, int itemNumber, bool sell, float transMoney/*, GameObject item*/){
		if (!sell){
			if (playerMoney - transMoney >= 0) {
				if (playerItems.ContainsKey (itemName)) {
					playerItems [itemName] += itemNumber;
					playerMoney -= transMoney;
				} else {
					playerItems [itemName] = itemNumber;

					playerMoney -= transMoney;

				}
			}
			else {
				Debug.LogError("not enough money");
			}


		}
		else{
			if (playerItems.ContainsKey(itemName)){
				if (playerItems[itemName] < itemNumber){
					Debug.LogError("not enough items to sell");
				}
				else{
					playerItems[itemName] -= itemNumber;
					playerMoney += transMoney;
				}
			}
			else{
				Debug.LogError("no such item");
			}
			if (playerItems[itemName]==0){
				playerItems.Remove(itemName);

			}
		}
	}
	public int getItemNumber(string itemName){
		return playerItems[itemName];
	}

	public int getColor(){
		return playerColor;
	}

	public void setColor(int num) {
		playerColor = num;

		renderer.material = materials [num - 1];

	}
	public void throwItem(string itemName){
		changeItem (itemName, 1,true, 0);
		Instantiate(playerItemObject[itemName],Camera.main.transform.position + Camera.main.transform.forward * placeDistance,Quaternion.identity);
	}
//	void OnTriggerEnter(Collider other) 
//	{
//		if (other.gameObject.CompareTag ("Pick Up"))
//		{
//			other.gameObject.SetActive (false);
//		}
//	}

}
