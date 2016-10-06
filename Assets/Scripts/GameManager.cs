using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This holds the main game logic

public class GameManager : MonoBehaviour {

	public Canvas overlayQTE;
	public Slider QTE;
	public Text messages;

	public float difficulty = 0f;
	public bool enableQTE;
	bool completedQTE;

	public GameObject[] events;
	//Use this to track how many events the player has completed.
	public int playerEventNumber = 0;

	// Use this for initialization
	void Start () {
		QTE = QTE.GetComponent<Slider> ();

		overlayQTE.enabled = false;
		enableQTE = false;
		messages.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		events [playerEventNumber].SetActive (true);

		//Make the QTEs work
		if (enableQTE == true) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				QTE.value += 0.1f;
			}
			QTE.value -= difficulty * Time.deltaTime;

			if (QTE.value >= 0.98) {
				enableQTE = false;
				overlayQTE.enabled = false;
				QTE.value = 0;
				events [playerEventNumber].SetActive (false);

				playerEventNumber++;
				messages.text = "";
			}
		}
	}
}
