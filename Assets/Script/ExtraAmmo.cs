using UnityEngine;
using System.Collections;

public class ExtraAmmo : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;
		if (collidedWith.CompareTag ("Soldier")) {
			Soldier.ammo += 5;
			Destroy(gameObject);
		}
	}
}
