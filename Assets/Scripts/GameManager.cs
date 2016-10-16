using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This holds the main game logic

public class GameManager : MonoBehaviour {

	public Canvas overlayQTE;
	public Canvas startCanvas;
	public Canvas endCanvas;
	public Slider QTE;
	public Text messages;
	public Image whiteBackground;

	public float difficulty = 0f;

	public GameObject[] events;
	//Use this to track how many events the player has completed.
	public int playerEventNumber = 0;

	// Use this for initialization
	void Start () {
		QTE = QTE.GetComponent<Slider> ();

		endCanvas.enabled = false;
		overlayQTE.enabled = false;

		messages.text = "";
		whiteBackground.enabled = false;

		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Space to start the game
		if (Input.GetKeyDown (KeyCode.Space)) {
			startCanvas.enabled = false;
		}

		//***************QTE Stuff***************//
		if (playerEventNumber <= 23) {
			//Enable the QTE trigger that the player needs to interact with
			events [playerEventNumber].SetActive (true);
		} else {
			//Once all the evets are completed, throw up the end screen
			//and make click restart the game
			endCanvas.enabled = true;

			if (Input.GetMouseButtonDown(0)) {
				SceneManager.LoadScene ("Game");
			}
		}

		//Make the QTEs work
		if (overlayQTE.enabled == true) {
			//Increase Slider by a discrete amount per key press.
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKey (KeyCode.Q)) {
				QTE.value += 0.1f;
			}
			//Reduce slider a set amount every second. Speed dependent on difficulty.
			QTE.value -= difficulty * Time.deltaTime;

			//Do stuff when the slider reaches the end.
			if (QTE.value >= 0.98) {
				//Turn off qte stuff and reset it.
				overlayQTE.enabled = false;
				QTE.value = 0;

				//Turn off the current QTE trigger, except for some special conditions where we
				//Want a message to pop up once the player exits the trigger colider
				if (playerEventNumber != 6 && playerEventNumber != 13
					&& playerEventNumber != 17 && playerEventNumber != 19) {
					events [playerEventNumber].SetActive (false);
					messages.text = "";
					whiteBackground.enabled = false;
				}

				//Make the gameManager move on to the next QTE trigger
				playerEventNumber++;
			}
		}
	}
}
