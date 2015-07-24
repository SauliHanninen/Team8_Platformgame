using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {
	Vector3 position;
	public Vector3 speed;
	public Vector3 acceleration;
	public static int lives;
	private bool isFalling;

	//projectile features
	public GameObject prefabProjectile;
	//public Vector3 launchPos;
	public GameObject projectile;
	public float velocityMult = 6f;

	// Use this for initialization
	void Start () {

		lives = 3;
	}

	void Awake(){
		//launchPos = transform.position;
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
		if (Input.GetKeyDown (KeyCode.Space)) {
			// Instantiate a projectile
			projectile = Instantiate (prefabProjectile) as GameObject;
			// Start it at the launch point
			projectile.transform.position = transform.position;
			// Set it to isKinematic for now
			projectile.GetComponent<Rigidbody>().isKinematic = true;
			projectile.transform.Translate(Time.deltaTime*velocityMult,0,0); 
			//projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
			//transform.Translate(Vector3.forward Time.deltaTime velocityMult);;
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
