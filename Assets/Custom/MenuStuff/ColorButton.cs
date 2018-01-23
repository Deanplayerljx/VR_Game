using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ColorButton : MonoBehaviour {
	public GameObject player;
	public Button colorButton;

	// Use this for initialization
//	void Start () {
//
//  }
	
	// Update is called once per frame
	void Update () {
		colorButton.onClick.AddListener (changeColor);
	}
	public void changeColor(){
		string color = colorButton.tag;
		PlayerNew script = player.GetComponent<PlayerNew> ();
		print (script);
		if (color == "Blue") {
			script.setColor (1);
		} 
		else if (color == "Green") {
			script.setColor (3);
		}
		else if (color == "Red") {
			script.setColor (2);
		}
		else if (color == "White") {
			script.setColor (4);
		}
		else if (color == "Black") {
			script.setColor (5);
		}
		else if (color == "Silver") {
			script.setColor (6);
		}
		else if (color == "Yellow") {
			script.setColor (7);
		}
		else if (color == "Magenta") {
			script.setColor (8);
		}
		print ("Color: " + color);


	}
}
