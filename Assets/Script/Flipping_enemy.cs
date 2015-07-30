using UnityEngine;
using System.Collections;

public class Flipping_enemy : MonoBehaviour {
	// spped at which the enemy moves (meter/second)
	public float speed = 1f;
	// Distance where the enemy turns around
	public float leftEdge;
	public float rightEdge;
	bool direction;
	public GameObject gameOverScreen;
	
	// Use this for initialization
	void Start () {
		direction = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 savedEnemyPosition = transform.position;
		savedEnemyPosition.x += speed * Time.deltaTime; 
		transform.position = savedEnemyPosition; 
		// Changing direction
		if (savedEnemyPosition.x < leftEdge) { // left edge
			speed = Mathf.Abs (speed); // Move right
			direction=true;
			GetComponent<Animator>().SetBool ("direction",direction);
		} else if (savedEnemyPosition.x > rightEdge) { // right edge
			speed = -Mathf.Abs (speed); // move left
			direction=false;
			GetComponent<Animator>().SetBool ("direction",direction);
		}
	}
	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;
		if (collidedWith.CompareTag ("Soldier") && (collidedWith.transform.position.y <= (transform.position.y+1 ))) {
			print ("You died!");
			print (transform.position.y);
			Destroy (collidedWith);
			UI_manager.S.ShowGameOverScreen ();
			//Soldier.lives--;
		} else if (collidedWith.CompareTag ("Soldier") && (collidedWith.transform.position.y > (transform.position.y+1))){
			Destroy(gameObject);
			//Destroy (collider);
		}
	}
}
