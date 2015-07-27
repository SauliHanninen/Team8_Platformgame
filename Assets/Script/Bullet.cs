using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;

		if (collidedWith.CompareTag ("Enemy")) {
			Destroy (collidedWith);
			Destroy (gameObject);
			print ("I destroyed");
			Soldier.ammo+=1;
		} else if (collider && !collidedWith.CompareTag ("Soldier")){
			Destroy(gameObject);
			print ("i destroyed wrongly");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
