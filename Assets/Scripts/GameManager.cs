using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This holds the main game logic

public class GameManager : MonoBehaviour {

	public Canvas overlayQTE;
	public Canvas endCanvas;
	public Slider QTE;
	public Text messages;
	public Text info;

	public float difficulty = 0f;
	public bool enableQTE;

	public GameObject[] events;
	//Use this to track how many events the player has completed.
	public int playerEventNumber = 0;

	// Use this for initialization
	void Start () {
		QTE = QTE.GetComponent<Slider> ();

		endCanvas.enabled = false;
		overlayQTE.enabled = false;

		enableQTE = false;

		messages.text = "";
		info.text = "";

		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerEventNumber <= 23) {
			//Enable the QTEtriggers that the player needs to interact with
			events [playerEventNumber].SetActive (true);
		} else {
			endCanvas.enabled = true;
		}

		//Make the QTEs work
		if (enableQTE == true) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKey (KeyCode.Q)) {
				QTE.value += 0.1f;
			}
			QTE.value -= difficulty * Time.deltaTime;

			if (QTE.value >= 0.98) {
				enableQTE = false;
				overlayQTE.enabled = false;
				QTE.value = 0;

				if (playerEventNumber != 6 && playerEventNumber != 13
					&& playerEventNumber != 17 && playerEventNumber != 19) {
					events [playerEventNumber].SetActive (false);
					messages.text = "";
				}
				info.text = "";

				playerEventNumber++;
			}
		}
	}
}
