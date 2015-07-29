using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {
	Vector3 position;
	public Vector3 speed;
	public Vector3 acceleration;
	public static int lives;
	private bool isFalling;

	static public int ammo;
	//boolean to see the direction
	bool direction;
	bool moving;
	public bool jumping;
	//projectile features
	public GameObject prefabProjectile;
	//public Vector3 launchPos;
	public GameObject projectile;
	public float velocityMult = 6f;
	static public Soldier S;

	// Use this for initialization
	void Start () {
		direction = true;
		lives = 3;
	}

	void Awake(){
		ammo = 10;
		S = this;		
	}
	// Update is called once per frame
	void Update () {



		Vector3 soldierPosition = this.transform.position;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			soldierPosition.x-=0.1F;
			this.transform.position=soldierPosition;
			direction=false;
			GetComponent<Animator>().SetBool("direction",direction);
			moving=true;
			GetComponent<Animator>().SetBool ("moving",moving);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			soldierPosition.x+=0.1F;
			this.transform.position=soldierPosition;
			direction=true;
			GetComponent<Animator>().SetBool("direction",direction);
			moving=true;
			GetComponent<Animator>().SetBool ("moving",moving);
		}
		if (Input.GetKeyDown (KeyCode.Space) && ammo>0) {
			// Instantiate a projectile
			projectile = Instantiate (prefabProjectile) as GameObject;
			// Start it at the launch point
			projectile.transform.position = transform.position;
			// Set the speed for the bullet
			if(direction)
			projectile.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
			if(!direction)
				projectile.GetComponent<Rigidbody>().velocity=new Vector3(-10,0,0);
			ammo--;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && isFalling == false) {
			GetComponent<Rigidbody>().AddForce(new Vector3 (0, 350, 0));
			isFalling = true;
			jumping=true;
			GetComponent<Animator>().SetBool ("jumping",jumping);
		}
		if (!Input.anyKey) {
			moving=false;
			GetComponent<Animator>().SetBool ("moving",moving);
			jumping=false;
			GetComponent<Animator>().SetBool ("jumping",jumping);
		}




	}

	void OnCollisionStay(){
		isFalling = false;

	}






}
