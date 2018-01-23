using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour {

	private float playerMoney = 1000000;
	private int playerColor;
	private Dictionary<string,int> playerItems = new Dictionary<string,int>();
	private List<string> friendList = new List<string>();
	private Renderer renderer;
	public Material[] materials;
	public Text ItemText;
	public Text moneyText;
	public float height;

	// Use this for initialization
	#region Start
	void Start () {
		renderer = this.transform.FindChild("Capsule").GetComponent<Renderer>();
		height = 2.0f;
	}
	#endregion

	// Update is called once per frame
	#region Update
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			setColor (1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			setColor (2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			setColor (3);
		}
		moneyText.text = '$' + playerMoney.ToString();
	}
	#endregion

	public void changeItem(string itemName, int itemNumber, bool sell, float transMoney){
		if (!sell){
			if (playerMoney - transMoney >= 0)
			if (playerItems.ContainsKey(itemName)){
				playerItems[itemName] += itemNumber;
				playerMoney -= transMoney;
			}
			else{
				playerItems[itemName] = itemNumber;
				playerMoney -= transMoney;
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

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			Debug.Log("Item Picked Up");
		}
	}

	#region Getters and Setters
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
	public float getHeight(){
		return height;
	}
	public void setHeight(float h){
		height = h;
	}
	#endregion
}