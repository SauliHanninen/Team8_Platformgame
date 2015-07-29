using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	static public Camera S;
	public float camZ;
	public GameObject character;


	void Awake(){
		S = this;
		camZ = this.transform.position.z;
	}

	void Update(){
		if (character != null) {
			Vector3 destination = character.transform.position;
			destination.z = camZ;
			// Set the camera to the destination
			transform.position = destination;
		}
	}

}
