using UnityEngine;
using System.Collections;

public class tutorial3 : MonoBehaviour {

	public GameObject instruction3;
	
	void OnTriggerEnter(Collider collider){
		GameObject collidedwith = collider.gameObject;
		if (collidedwith.CompareTag ("Soldier")) {
			instruction3.SetActive (true);
		}
	}
	
	void OnTriggerExit(Collider collider){
		GameObject collidedwith = collider.gameObject;
		if (collidedwith.CompareTag ("Soldier")) {
			instruction3.SetActive (false);
		}
	}
}
