using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CirclularBar : MonoBehaviour {
	public Image circularSlider;
	public float time = 10;
	// Use this for initialization
	void Start () {
		circularSlider.fillAmount=0f;
	}
	
	// Update is called once per frame
	void Update () {
		//circularSlider.fillAmount += Time.deltaTime / time;
	}
}
