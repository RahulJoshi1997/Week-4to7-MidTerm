using UnityEngine;
using System.Collections;

//This script passes important information specific to each encounter to the GameManager

public class TriggersQTE : MonoBehaviour {

	GameManager gm;
	float diff;
	string textQTE;
	string infoQTE;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		if (this.name == "0-India Friends") {
			diff = 0.05f;
			textQTE = "What will we play today?";
			infoQTE = "Friends in India";
		} else if (this.name == "1-India Family") {
			diff = 0.05f;
			textQTE = "Hey. You know what Siddarth and I did today?";
			infoQTE = "Family";
		} else if (this.name == "2-India School") {
			diff = 0.1f;
			textQTE = "Psst. I'm behind on taking notes. Can I borrow your notbook later?";
			infoQTE = "School";
		} else if (this.name == "3-India Friends") {
			diff = 0.1f;
			textQTE = "*Drop Backpack*\nLets play here a bit before we go home.";
			infoQTE = "Friends";
		} else if (this.name == "4-India Family") {
			diff = 0.3f;
			textQTE = "Rahul. We'll be going to America.";
			infoQTE = "Family";
		} else if (this.name == "5-India Friends") {
			diff = 0.3f;
			textQTE = "Oh, you herd? Rahul is going to America.\nRahul, you'll be back in a year right?";
			infoQTE = "Friends";
		} else if (this.name == "6-India Leaving") {
			diff = 0.4f;
			textQTE = "...";
			infoQTE = "Leaving";
		} else if (this.name == "7-America School") {
			diff = 0.5f;
			textQTE = "Where are you from?";
			infoQTE = "School in America";
		} else if (this.name == "8-America Family") {
			diff = 0.3f;
			textQTE = "I don't like it here";
			infoQTE = "Family";
		} else if (this.name == "9-America School") {
			diff = 0.001f;
			textQTE = "It's recess.\n*Walk Alone*";
			infoQTE = "School";
		} else if (this.name == "10-America Family") {
			diff = 0.1f;
			textQTE = "Hey sis. Wanna play something?";
			infoQTE = "Family";
		} else if (this.name == "11-America School") {
			diff = 0.3f;
			textQTE = "What is India like?";
			infoQTE = "School";
		} else if (this.name == "12-America Family") {
			diff = 0.5f;
			textQTE = "Rahul. We'll be here for another year.";
			infoQTE = "Family";
		} else if (this.name == "13-America School") {
			diff = 0.2f;
			textQTE = "Raul. Wanna play with us?";
			infoQTE = "School";
		} else if (this.name == "14-America Family") {
			diff = 0.3f;
			textQTE = "We're staying in America, but moving to another state";
			infoQTE = "Family";
		} else if (this.name == "15-America School") {
			diff = 0.2f;
			textQTE = "I'll be moving when school ends. What can you do right?";
			infoQTE = "Friends";
		} else if (this.name == "16-Maryland School") {
			diff = 0.35f;
			textQTE = "I'm Raul";
			infoQTE = "School in Maryland";
		} else if (this.name == "17-Maryland School") {
			diff = 0.3f;
			textQTE = "Why don't you come sit with us?";
			infoQTE = "School";
		} else if (this.name == "18-Maryland High School") {
			diff = 0.25f;
			textQTE = "I had no you moved here, Raul.\nYou fit right in.";
			infoQTE = "High School";
		} else if (this.name == "19-Maryland Family") {
			diff = 0.4f;
			textQTE = "Rahul. Come talk with us.\nWhy do you have to be on your own?";
			infoQTE = "Family";
		} else if (this.name == "20-Maryland Family") {
			diff = 0.3f;
			textQTE = "We'll have to leave soon. Our visa's running out.";
			infoQTE = "Family";
		} else if (this.name == "21-Maryland Friends") {
			diff = 0.15f;
			textQTE = "So, if Daniel hadn't asked about summer, you wouldn't have told us you're leaving?";
			infoQTE = "Friends";
		} else if (this.name == "22-India Friends") {
			diff = 0.3f;
			textQTE = "Siddarth. You've changed so much. Didn't recognize you.";
			infoQTE = "Friends";
		} else if (this.name == "23-India Parents") {
			diff = 0.5f;
			textQTE = "Why don't you talk to your old friends? Do they not contact you?";
			infoQTE = "Family";
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
		gm.info.text = infoQTE;
	}

	void OnTriggerExit () {
		if (gm.enableQTE == false) {
			if (this.name == "6-India Leaving") {
				gm.messages.text = "Bye";
				gm.events [6].SetActive (false);
			}
			if (this.name == "13-America School") {
				gm.messages.text = "Another year passes";
				gm.events [13].SetActive (false);
			}
			if (this.name == "17-Maryland School") {
				gm.messages.text = "Two years pass";
				gm.events [17].SetActive (false);
			}
			if (this.name == "19-Maryland Family") {
				gm.messages.text = "Another two years pass";
				gm.events [19].SetActive (false);
			}
		}
	}
}
