using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {
	Vector3 position;
	public Vector3 speed;
	public Vector3 acceleration;
	public static int lives;
	private bool isFalling;

	// Use this for initialization
	void Start () {

		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {



		Vector3 soldierPosition = this.transform.position;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			soldierPosition.x-=0.1F;
			this.transform.position=soldierPosition;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			soldierPosition.x+=0.1F;
			this.transform.position=soldierPosition;
		}


		if (Input.GetKeyDown(KeyCode.UpArrow) && isFalling == false) {
			GetComponent<Rigidbody>().AddForce(new Vector3 (0, 500, 0));
			isFalling = true;
		}

	}

	void OnCollisionStay(){
		isFalling = false;

	}






}
