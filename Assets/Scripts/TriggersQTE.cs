using UnityEngine;
using System.Collections;

public class TriggersQTE : MonoBehaviour {

	GameManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		gm.overlay.enabled = true;
		gm.difficulty = 0.3f;
	}
}
