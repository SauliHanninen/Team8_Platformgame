using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		GameObject collidedWith = collider.gameObject;

		if (collidedWith.CompareTag ("Enemy")) {
			Destroy (collidedWith);
			Destroy (gameObject);

			Soldier.ammo += 1;
		} else if (collider && !collidedWith.CompareTag ("Soldier") && !collidedWith.CompareTag ("Final_boss")) {
			Destroy (gameObject);
		} else if (collidedWith.CompareTag ("Final_boss")) {
			if(Final_boss.life>0)
				Final_boss.life--;
			if(Final_boss.life<=0){
				Final_boss.S.createGoal();
				Destroy (collidedWith);

			}
		}

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
