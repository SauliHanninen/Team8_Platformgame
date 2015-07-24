using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {
	Vector3 position;
	public Vector3 speed;
	public Vector3 acceleration;

	private bool isFalling;

	// Use this for initialization
	void Start () {
		SetSpeed (0, 0);
		SetAcceleration (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A))
			SetSpeed (-1, 0);
		if (Input.GetKey (KeyCode.W))
			SetSpeed (0, 1);
		if (Input.GetKey (KeyCode.D))
			SetSpeed (1, 0);
		if (Input.GetKey (KeyCode.S))
			SetSpeed (0, 0);


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


	void SetSpeed(float a,float b){
		speed.x = a;
		speed.y = b;
		speed.z = 0;
	}
	void SetAcceleration(float a,float b){
		acceleration.x = a;
		acceleration.y = b;
		acceleration.z = 0;
	}


}
