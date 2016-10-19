using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This holds the main game logic

public class GameManager : MonoBehaviour {
	//This canvas holds the QTE slider along with the text above it and the white box behind it.
	public Canvas overlayQTE;
	//Start Screen
	public Canvas startCanvas;
	//End Screen
	public Canvas endCanvas;
	//The QTE Slider
	public Slider QTE;
	//The thing that displays the QTE specific text of what people say to you along with the background
	//image that makes the text legible.
	public Text messages;
	public Image whiteBackground;
	//TriggersQTE script will pass on this value to GM and it sets the difficulty of each specific
	//encounter
	public float difficulty = 0f;
	//This is the list of all the QTE triggers. I'll use this to make the right triggeres pop up and disappear.
	public GameObject[] events;
	//Use this to track how many QTE events the player has completed.
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
		//Press space to start the game
		if (Input.GetKeyDown (KeyCode.Space)) {
			startCanvas.enabled = false;
		}

		//***************QTE Stuff***************//
		if (playerEventNumber <= 23) {
			//Enable the QTE trigger that the player needs to interact with
			events [playerEventNumber].SetActive (true);
		} else {
			//Once all the evets are completed, throw up the end screen
			endCanvas.enabled = true;
			//Make click restart the game
			if (Input.GetMouseButtonDown(0)) {
				SceneManager.LoadScene ("Game");
			}
		}

		//Make the QTEs work. This stuff works only when the QTE UI is up, meaning it works only when the
		//TriggersQTE script enables the UI. This happens when the player walks into the trigger colider.
		if (overlayQTE.enabled == true) {
			//Increase Slider by a discrete amount per key press.
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKey (KeyCode.Q)) {
				QTE.value += 0.1f;
			}
			//Reduce the slider at a constant, frame independent, speed.
			//That speed is the difficulty value per second.
			QTE.value -= difficulty * Time.deltaTime;

			//When the slider reaches the end, and the player wins.
			if (QTE.value >= 0.98) {
				//Turn off the QTE canvas and reset the slider's value.
				overlayQTE.enabled = false;
				QTE.value = 0;

				//Get rid of dialogue text, except for some special cases where we
				//want a message to pop up once the player exits the trigger colider
				if (playerEventNumber != 6 && playerEventNumber != 13
				    && playerEventNumber != 17 && playerEventNumber != 19) {
					messages.text = "";
					whiteBackground.enabled = false;
				}

				//Make the gameManager move on to the next QTE trigger
				playerEventNumber++;
			}
		}

		//This moves downward all the previous QTE triggers that the player beat until they are out of sight.
		for (int x = 0; x < playerEventNumber; x++) {
			//Moves the triggers down at a constant speed, until they are at a y value <= -3f.
			if (events [x].transform.position.y > -3f) {
				events [x].transform.position -= new Vector3 (0f, 0.5f, 0f) * Time.deltaTime;
			}
		}
	}
}
