using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {
	public Button AButton;
	public Text itemName;
	public Text price;
	public Text RemainNum;

	private Item curItem;
	private ScrollList curScrollList;
	// Use this for initialization
	void Start () {
		AButton.onClick.AddListener (ThrowOne);
	}
	public void Setup(Item item, ScrollList scrollList){
		curScrollList = scrollList;
		curItem = item;
		itemName.text = "Name: " + item.itemName;
		price.text = "100";
		RemainNum.text = "Remain: " + item.itemRemain.ToString();
		Debug.Log ("itemRemain is" + item.itemRemain);
	}
	//Throw one item per click
	public void ThrowOne(){
		curScrollList.ThrowOneItem (curItem, curScrollList);
	}
}
