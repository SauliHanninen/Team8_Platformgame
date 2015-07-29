using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour {
	public GameObject gameOverScreen;
	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;
		
		if (collidedWith.CompareTag ("Soldier")) {
			Destroy (collidedWith);
			Destroy (gameObject);
			UI_manager.S.ShowGameOverScreen();
		} else if (collider && !collidedWith.CompareTag ("Final_boss") && !collidedWith.CompareTag ("Ammo")) {
			Destroy (gameObject);
		}
		
	}
	// Use this for initialization
	void Start () {
		gameOverScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
