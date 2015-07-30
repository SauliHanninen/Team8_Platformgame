using UnityEngine;
using System.Collections;

public class ExtraAmmo : MonoBehaviour {

	public AudioClip charging;
	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;
		if (collidedWith.CompareTag ("Soldier")) {
			Soldier.ammo += 5;
			AudioSource.PlayClipAtPoint(charging, transform.position);
			Destroy(gameObject);
		}
	}
}
