using UnityEngine;
using System.Collections;
using System;
public class Final_boss : MonoBehaviour {

	public float speed=2.5f;
	static public int life;
	public GameObject goal, prefabGoal;
	public GameObject gameOverScreen;
	static public Final_boss S;
	//projectile features
	public GameObject prefabProjectile;
	//public Vector3 launchPos;
	public GameObject projectile;
	bool direction;
	bool moving;
	bool jumping;

	// Use this for initialization
	void Start () {
		life = 30;
		gameOverScreen.SetActive (false);
		InvokeRepeating ("shoot", 1, 3);
		direction = true;
		moving = true;
		GetComponent<Animator>().SetBool("moving",moving);
		jumping = false;
		InvokeRepeating ("CompareHeight", 1, 1);
		InvokeRepeating ("stopJump", 6, 5);
	}
	void Awake(){
		S = this;
	}
	
	// Update is called once per frame
	void Update () {
		//movement
		Vector3 savedEnemyPosition = transform.position;
		savedEnemyPosition.x += speed * Time.deltaTime; 
		transform.position = savedEnemyPosition;
		if (Soldier.S.transform.position.x < this.transform.position.x) {
			speed = -1.0f;
			direction = false;
			GetComponent<Animator>().SetBool("direction",direction);
		}
		if (Soldier.S.transform.position.x > this.transform.position.x) {
			speed = +1.0f;
			direction = true;
			GetComponent<Animator>().SetBool("direction",direction);
		}


	
	}
	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;
		if (collidedWith.CompareTag ("Bullet") && (life > 0)) {
			life--;
			Destroy (collidedWith);
		} else if (collidedWith.CompareTag ("Soldier")) {
			Destroy (collider.gameObject);
			UI_manager.S.ShowGameOverScreen();
		} else if (collidedWith.CompareTag ("Bullet") && (life <= 0)) {
			Destroy (collidedWith);
		} 
	}
	public void createGoal(){
		goal = Instantiate (prefabGoal) as GameObject;
		goal.transform.position = this.transform.position;
		goal.transform.Translate (0f, 0f, 0f);
	}
	public void shoot(){
		if (Soldier.S.transform.position.x > this.transform.position.x) {
			// Instantiate a projectile
			projectile = Instantiate (prefabProjectile) as GameObject;
			// Start it at the launch point
			projectile.transform.position = transform.position;
			// Set the speed for the bullet
			projectile.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
		}
		if (Soldier.S.transform.position.x < this.transform.position.x) {
			// Instantiate a projectile
			projectile = Instantiate (prefabProjectile) as GameObject;
			// Start it at the launch point
			projectile.transform.position = transform.position;
			// Set the speed for the bullet
			projectile.GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
		}

	}
	public void jump(){
		GetComponent<Rigidbody>().AddForce(new Vector3 (0, 350, 0));
		jumping=true;
		GetComponent<Animator>().SetBool ("jumping",jumping);
	}
	public void stopJump(){
		GetComponent<Rigidbody>().AddForce(new Vector3 (0, 0, 0));
		jumping = false;
		GetComponent<Animator> ().SetBool ("jumping", jumping);
	}
	void CompareHeight(){
		if (Soldier.S.transform.position.y > this.transform.position.y+0.2) {
			jump ();
			shoot ();
		}
		if (Soldier.S.transform.position.y <= this.transform.position.y+0.2)
			stopJump ();
	}
}
