using UnityEngine;
using System.Collections;

//This script passes important information specific to each encounter to the GameManager

public class TriggersQTE : MonoBehaviour {

	GameManager gm;
	float diff;
	string textQTE;
	string contextQTE;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		if (this.name == "0-India Friends") {
			diff = 0.05f;
			textQTE = "You: What will we play today?";
			contextQTE = "Hope you play tag";
		} else if (this.name == "1-India Family") {
			diff = 0.05f;
			textQTE = "You: Hey mom. You know what Siddarth and I did today?";
			contextQTE = "Carry on talking";
		} else if (this.name == "2-India School") {
			diff = 0.1f;
			textQTE = "You: Psst. I'm behind on taking notes. Can I borrow your notbook later?";
			contextQTE = "Go on with school";
		} else if (this.name == "3-India Friends") {
			diff = 0.1f;
			textQTE = "*Drop Backpack*\nYou: Lets play here a bit before we go home.";
			contextQTE = "Have fun";
		} else if (this.name == "4-India Family") {
			diff = 0.4f;
			textQTE = "Dad: Rahul. We'll be going to America.";
			contextQTE = "Go on with life";
		} else if (this.name == "5-India Friends") {
			diff = 0.3f;
			textQTE = "Friends: Oh, you herd? Rahul is going to America. You'll be back in a year, right Rahul?";
			contextQTE = "Enjoy the time you have";
		} else if (this.name == "6-India Leaving") {
			diff = 0.5f;
			textQTE = "...";
			contextQTE = "Go on with life";
		} else if (this.name == "7-America School") {
			diff = 0.5f;
			textQTE = "Strangers: Where are you from?";
			contextQTE = "Try to fit in";
		} else if (this.name == "8-America Family") {
			diff = 0.3f;
			textQTE = "You: I don't like it here";
			contextQTE = "Look forward to sleep";
		} else if (this.name == "9-America School") {
			diff = 0.4f;
			textQTE = "It's recess.\n*Walk Alone*";
			contextQTE = "Go on with life";
		} else if (this.name == "10-America Family") {
			diff = 0.2f;
			textQTE = "You: Hey sis. Wanna play something?";
			contextQTE = "Try to have fun";
		} else if (this.name == "11-America School") {
			diff = 0.4f;
			textQTE = "Strangers: What is India like?";
			contextQTE = "Try to explain";
		} else if (this.name == "12-America Family") {
			diff = 0.5f;
			textQTE = "Dad: Rahul. We'll be here for another year.";
			contextQTE = "Go on with life";
		} else if (this.name == "13-America School") {
			diff = 0.3f;
			textQTE = "Acquaintances: Raul, Wanna play with us?";
			contextQTE = "Try to fit in";
		} else if (this.name == "14-America Family") {
			diff = 0.1f;
			textQTE = "Dad: We're staying in America, but moving to another state";
			contextQTE = "Go on with life";
		} else if (this.name == "15-America School") {
			diff = 0.2f;
			textQTE = "You: I'll be moving when school ends";
			contextQTE = "Carry on";
		} else if (this.name == "16-Maryland School") {
			diff = 0.35f;
			textQTE = "Strangers: I'm Raul";
			contextQTE = "Try not to be weird";
		} else if (this.name == "17-Maryland School") {
			diff = 0.25f;
			textQTE = "Strangers: Why don't you come sit with us?";
			contextQTE = "Don't be ackward";
		} else if (this.name == "18-Maryland High School") {
			diff = 0.2f;
			textQTE = "Teacher: I had no idea you moved here, Raul.\nYou fit right in.";
			contextQTE = "Fell good";
		} else if (this.name == "19-Maryland Family") {
			diff = 0.4f;
			textQTE = "Mom: Rahul. Come talk with us.\nWhy do you have to be on your own?";
			contextQTE = "You don't know. Make excuses.";
		} else if (this.name == "20-Maryland Family") {
			diff = 0.4f;
			textQTE = "Dad: We'll have to leave soon. Our visa's running out.";
			contextQTE = "Delude yourself you're staying";
		} else if (this.name == "21-Maryland Friends") {
			diff = 0.2f;
			textQTE = "Friends: So, if Daniel hadn't asked about summer, you wouldn't have told us you're leaving?";
			contextQTE = "Make excuses";
		} else if (this.name == "22-India Friends") {
			diff = 0.4f;
			textQTE = "You: Siddarth. You've changed so much. Didn't recognize you.";
			contextQTE = "Accept they've all moved on";
		} else if (this.name == "23-India Parents") {
			diff = 0.5f;
			textQTE = "Dad: Why don't you talk to your old friends? Do they not contact you?";
			contextQTE = "Go on with life";
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
		gm.contextQTE.text = contextQTE;
		gm.whiteBackground.enabled = true;
	}

	void OnTriggerExit () {
		if (gm.overlayQTE.enabled == false) {
			if (this.name == "6-India Leaving") {
				gm.messages.text = "Bye";
			}
			if (this.name == "13-America School") {
				gm.messages.text = "Another year passes";
			}
			if (this.name == "17-Maryland School") {
				gm.messages.text = "Two years pass";
			}
			if (this.name == "19-Maryland Family") {
				gm.messages.text = "Another two years pass";
			}
		}
	}
}
