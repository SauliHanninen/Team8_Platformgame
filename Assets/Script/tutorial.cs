using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {

	public GameObject instruction1;

	void OnTriggerEnter(Collider collider){
		GameObject collidedwith = collider.gameObject;
		if (collidedwith.CompareTag ("Soldier")) {
			instruction1.SetActive (true);
		}
	}

	void OnTriggerExit(Collider collider){
		GameObject collidedwith = collider.gameObject;
		if (collidedwith.CompareTag ("Soldier")) {
			instruction1.SetActive (false);
		}
	}


}
