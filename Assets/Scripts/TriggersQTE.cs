using UnityEngine;
using System.Collections;

//This script passes important information specific to each encounter to the GameManager

public class TriggersQTE : MonoBehaviour {

	GameManager gm;
	float diff;
	string textQTE;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		if (this.name == "1-India Friends") {
			diff = 0.1f;
			textQTE = "What will we play today?";
		} else if (this.name == "2-India Family") {
			diff = 0.1f;
			textQTE = "Hey. You know what Siddarth and I did today?";
		}
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter () {
		gm.overlayQTE.enabled = true;
		gm.enableQTE = true;

		gm.difficulty = diff;
		gm.messages.text = textQTE;
	}
}
