using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Slider QTE;
	public Canvas overlay;

	public float difficulty = 0.01f;
	bool complete;

	// Use this for initialization
	void Start () {
		QTE = QTE.GetComponent<Slider> ();
		overlay.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			QTE.value += 0.1f;
		}
		QTE.value -= difficulty * Time.deltaTime;

		if (QTE.value >= 0.98) {
			overlay.enabled = false;
		}
	}
}
