using UnityEngine;
using System.Collections;

public class UI_manager : MonoBehaviour {

	public GameObject selectLevelPanel;
	public GameObject gameOverScreen;

	public void StartGame(){
		Application.LoadLevel ("1_game");
	}
	public void QuitGame(){
		Application.Quit ();
	}
	public void showSelectLevelPanel(){
		selectLevelPanel.SetActive (true);
	}
	public void hideSelectLevelPanel(){
		selectLevelPanel.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName.Equals ("0_menu")) {
			selectLevelPanel.SetActive (false);
		}else if(Application.loadedLevelName.Equals ("1_game")){
			gameOverScreen.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void backToMainMenu(){
		Application.LoadLevel ("0_menu");
	}

	public void tryAgain(){
		Application.LoadLevel ("1_game");
	}

}
