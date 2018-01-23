using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

[System.Serializable]
public class Item
{
	
	public string itemName;
	public string itemPrice;
	public int itemRemain;
	public Item(string name, string price, int remain){
		itemName = name;
		itemPrice = price;
		itemRemain = remain;
	}

}

public class ScrollList : MonoBehaviour {

	public List<Item> itemList;
	public Transform contentPanel;
	public SimpleObjectPool buttonObjectPool;
	public GameObject player;

	private PlayerNew playerScript;

	// Use this for initialization
	void Start () 
	{
		playerScript = player.GetComponent<PlayerNew> ();
		RefreshDisplay ();


	}
	// Update is called once per frame
//	void Update (){
//		RefreshDisplay ();
//	}
	public void RefreshDisplay()
	{
		// load all items in the inventory
		List<string> itemNames = new List<string>(playerScript.playerItems.Keys);
		Debug.Log (itemNames.Count);
		itemList.Clear();
		for (int i = 0; i < itemNames.Count; i++) {
			Item newItem = new Item (itemNames[i], "100", playerScript.playerItems[itemNames[i]]);
			itemList.Add(newItem);
		}
		RemoveButtons ();
		AddButtons ();
	}

	private void RemoveButtons()
	{
		while (contentPanel.childCount > 0) 
		{
			
			GameObject toRemove = transform.GetChild(0).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}

	private void AddButtons()
	{
		//Debug.Log (itemList);
		for (int i = 0; i < itemList.Count; i++) 
		{
			Debug.Log ("once");
			Item item = itemList[i];
			GameObject newButton = buttonObjectPool.GetObject();
			Debug.Log(newButton.tag);

			newButton.transform.SetParent(contentPanel, false);

			SampleButton sampleButton = newButton.GetComponent<SampleButton>();
			sampleButton.Setup(item, this);
		}
	}

//	public void TryTransferItemToOtherShop(Item item)
//	{
//		if (otherShop.gold >= item.price) 
//		{
//			gold += item.price;
//			otherShop.gold -= item.price;
//
//			AddItem(item, otherShop);
//			RemoveItem(item, this);
//
//			RefreshDisplay();
//			otherShop.RefreshDisplay();
//			Debug.Log ("enough gold");
//
//		}
//		Debug.Log ("attempted");
//	}

//	private void AddItem(Item itemToAdd, ScrollList List)
//	{
//		List.itemList.Add (itemToAdd);
//	}

	public void ThrowOneItem(Item itemToThrow, ScrollList List){
		
//		int remain = items [itemToThrow.itemName];
//		itemToThrow.itemRemain -= 1;
//		if (itemToThrow.itemRemain <= 0) {
//			RemoveItem (itemToThrow, List);
//			Debug.Log ("Throw");
//		}
		playerScript.throwItem(itemToThrow.itemName);

		RefreshDisplay ();
	}

	private void RemoveItem(Item itemToRemove, ScrollList List)
	{
		for (int i = List.itemList.Count - 1; i >= 0; i--) 
		{
			if (List.itemList[i] == itemToRemove)
			{
				List.itemList.RemoveAt(i);
			}
		}
	}
}