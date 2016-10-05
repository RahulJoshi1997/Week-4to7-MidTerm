using UnityEngine;
using System.Collections;

//This script passes important information specific to each encounter to the GameManager

public class TriggersQTE : MonoBehaviour {

	GameManager gm;
	int eventNumber;
	float diff;
	string textQTE;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		if (this.name == "India Friends") {
			eventNumber = 0;
			diff = 0.1f;
			textQTE = "What will we play today?";
		} else if (this.name == "India Family") {
			eventNumber = 1;
			diff = 0.1f;
			textQTE = "Hey. You know what Siddarth did today?";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		if (gm.playerEventNumber == eventNumber) {
			gm.overlayQTE.enabled = true;
			gm.difficulty = diff;

			gm.messages.text = textQTE;
		} else if (gm.playerEventNumber > eventNumber) {
			gm.messages.text = "You're skipping forward in time. Please don't time travel.";
		} else if (gm.playerEventNumber < eventNumber) {
			gm.messages.text = "Stop. Please don't go back in time.";
		}
	}

	void OnTriggerExit () {
		gm.messages.text = "";
	}
}
