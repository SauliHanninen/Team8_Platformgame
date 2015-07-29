using UnityEngine;
using System.Collections;

public class tutorial2 : MonoBehaviour {

	public GameObject instruction2;
	
	void OnTriggerEnter(Collider collider){
		GameObject collidedwith = collider.gameObject;
		if (collidedwith.CompareTag ("Soldier")) {
			instruction2.SetActive (true);
		}
	}
	
	void OnTriggerExit(Collider collider){
		GameObject collidedwith = collider.gameObject;
		if (collidedwith.CompareTag ("Soldier")) {
			instruction2.SetActive (false);
		}
	}
}
