using UnityEngine;
using System.Collections;

public class deathfloor : MonoBehaviour {

	//if player hits this platform, kill player character
	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;
		if (collidedWith.CompareTag ("Soldier")) {
			print("You died!");
			Destroy(collidedWith);
			//Soldier.lives--;
		}
	}


}
