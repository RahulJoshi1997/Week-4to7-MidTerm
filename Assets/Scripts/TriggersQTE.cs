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

		if (this.name == "0-India Friends") {
			diff = 0.05f;
			textQTE = "You: What will we play today?";
		} else if (this.name == "1-India Family") {
			diff = 0.05f;
			textQTE = "You: Hey mom. You know what Siddarth and I did today?";
		} else if (this.name == "2-India School") {
			diff = 0.1f;
			textQTE = "You: Psst. I'm behind on taking notes. Can I borrow your notbook later?";
		} else if (this.name == "3-India Friends") {
			diff = 0.1f;
			textQTE = "*Drop Backpack*\nYou: Lets play here a bit before we go home.";
		} else if (this.name == "4-India Family") {
			diff = 0.4f;
			textQTE = "Dad: Rahul. We'll be going to America.";
		} else if (this.name == "5-India Friends") {
			diff = 0.3f;
			textQTE = "Friends: Oh, you herd? Rahul is going to America. You'll be back in a year, right Rahul?";
		} else if (this.name == "6-India Leaving") {
			diff = 0.5f;
			textQTE = "...";
		} else if (this.name == "7-America School") {
			diff = 0.5f;
			textQTE = "Strangers: Where are you from?";
		} else if (this.name == "8-America Family") {
			diff = 0.3f;
			textQTE = "I don't like it here";
		} else if (this.name == "9-America School") {
			diff = 0.4f;
			textQTE = "It's recess.\n*Walk Alone*";
		} else if (this.name == "10-America Family") {
			diff = 0.2f;
			textQTE = "You: Hey sis. Wanna play something?";
		} else if (this.name == "11-America School") {
			diff = 0.3f;
			textQTE = "Strangers: What is India like?";
		} else if (this.name == "12-America Family") {
			diff = 0.5f;
			textQTE = "Dad: Rahul. We'll be here for another year.";
		} else if (this.name == "13-America School") {
			diff = 0.1f;
			textQTE = "Acquaintances: Raul, Wanna play with us?";
		} else if (this.name == "14-America Family") {
			diff = 0.3f;
			textQTE = "Dad: We're staying in America, but moving to another state";
		} else if (this.name == "15-America School") {
			diff = 0.2f;
			textQTE = "You: I'll be moving when school ends. What can you do right?";
		} else if (this.name == "16-Maryland School") {
			diff = 0.35f;
			textQTE = "Strangers: I'm Raul";
		} else if (this.name == "17-Maryland School") {
			diff = 0.25f;
			textQTE = "Strangers: Why don't you come sit with us?";
		} else if (this.name == "18-Maryland High School") {
			diff = 0.2f;
			textQTE = "Teacher: I had no idea you moved here, Raul.\nYou fit right in.";
		} else if (this.name == "19-Maryland Family") {
			diff = 0.25f;
			textQTE = "Mom: Rahul. Come talk with us.\nWhy do you have to be on your own?";
		} else if (this.name == "20-Maryland Family") {
			diff = 0.3f;
			textQTE = "Dad: We'll have to leave soon. Our visa's running out.";
		} else if (this.name == "21-Maryland Friends") {
			diff = 0.15f;
			textQTE = "Friends: So, if Daniel hadn't asked about summer, you wouldn't have told us you're leaving?";
		} else if (this.name == "22-India Friends") {
			diff = 0.3f;
			textQTE = "You: Siddarth. You've changed so much. Didn't recognize you.";
		} else if (this.name == "23-India Parents") {
			diff = 0.5f;
			textQTE = "Dad: Why don't you talk to your old friends? Do they not contact you?";
		}
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter () {
		gm.overlayQTE.enabled = true;

		gm.difficulty = diff;
		gm.messages.text = textQTE;
		gm.whiteBackground.enabled = true;
	}

	void OnTriggerExit () {
		if (gm.overlayQTE.enabled == false) {
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
