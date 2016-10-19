using UnityEngine;
using System.Collections;

//This does nothing else other than moving the character and making it look around

public class PlayerControl : MonoBehaviour {

	GameManager gm;

	CharacterController cControl;

	const float lookSpeed = 250;
	const float moveSpeed = 250;

	// Use this for initialization
	void Start () {
		cControl = GetComponent<CharacterController> ();
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//No moving before the game starts and once it ends. Also no moving once QTE is up.
		if (gm.startCanvas.enabled == false && gm.endCanvas.enabled==false
			&& gm.overlayQTE.enabled == false) {
			//Getting inputs
			float moveX = Input.GetAxis ("Horizontal");
			float moveZ = Input.GetAxis ("Vertical");
			//To look left an right, rotate about the Y axis
			float lookX = -Input.GetAxis ("Mouse Y") * Time.deltaTime * lookSpeed;
			//To look up and down, rotate about the X axis
			float lookY = Input.GetAxis ("Mouse X") * Time.deltaTime * lookSpeed;

			//Move the character
			cControl.SimpleMove ((transform.forward * moveZ + transform.right * moveX) * Time.deltaTime * moveSpeed);

			//Turn the chatacter
			transform.Rotate (lookX, lookY, 0f);
			//Make sure transform.Rotate does not create any z axis rotation when the player
			//moves the mouse in a circle
			Vector3 zLock = new Vector3 (this.transform.eulerAngles.x, this.transform.eulerAngles.y, 0f);
			this.transform.eulerAngles = zLock;
		}
	}
}
