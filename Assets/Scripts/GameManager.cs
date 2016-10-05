using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This holds the main game logic

public class GameManager : MonoBehaviour {

	public Canvas overlayQTE;
	public Slider QTE;
	public Text messages;

	public float difficulty = 0f;
	bool complete;

	//Use this to track how many events the player has completed.
	public int playerEventNumber = 0;

	// Use this for initialization
	void Start () {
		QTE = QTE.GetComponent<Slider> ();

		overlayQTE.enabled = false;
		messages.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//Make the QTEs work
		if (Input.GetKeyDown(KeyCode.Space)) {
			QTE.value += 0.1f;
		}
		QTE.value -= difficulty * Time.deltaTime;

		if (QTE.value >= 0.98) {
			overlayQTE.enabled = false;
			playerEventNumber ++;
		}
	}
}
