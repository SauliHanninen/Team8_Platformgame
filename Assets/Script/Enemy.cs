using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// spped at which the enemy moves (meter/second)
	public float speed = 1f;
	// Distance where the enemy turns around
	public float leftEdge;
	public float rightEdge;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 savedEnemyPosition = transform.position;
		savedEnemyPosition.x += speed * Time.deltaTime; 
		transform.position = savedEnemyPosition; 
		// Changing direction
		if (savedEnemyPosition.x < leftEdge) { // left edge
			speed = Mathf.Abs (speed); // Move right
		} else if (savedEnemyPosition.x > rightEdge) { // right edge
			speed = -Mathf.Abs (speed); // move left
		}
	}
	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;
		if (collidedWith.CompareTag ("Soldier") && (collidedWith.transform.position.y <= (transform.position.y+0.2 ))) {
			print ("You died!");
			print (transform.position.y);
			Destroy (collidedWith);
			//Soldier.lives--;
		} else if (collidedWith.CompareTag ("Soldier") && (collidedWith.transform.position.y > (transform.position.y+0.2))){

			Destroy(gameObject);
			//Destroy (collider);
		}
	}
}
