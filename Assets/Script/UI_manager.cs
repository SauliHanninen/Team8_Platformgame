using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour {

	public Text ammoText;
	public GameObject selectLevelPanel;
	public GameObject gameOverScreen;
	static public UI_manager S;
	public GameObject instruction1;
	public GameObject instruction2;
	public GameObject instruction3;
	public GameObject winPanel;

	public void StartGame(){
		Goal.goalMet = false;
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
	public void StartLevel2(){
		Application.LoadLevel ("2_game");
	}
	public void StartLevel3(){
		Application.LoadLevel ("3_game");
	}
	public void StartTutorial(){
		Application.LoadLevel ("0_tutorial");
	}
	// Use this for initialization
	void Start () {
	
		if (Application.loadedLevelName.Equals ("0_menu")) {
			selectLevelPanel.SetActive (false);
		} else if (Application.loadedLevelName.Equals ("1_game")) {
			gameOverScreen.SetActive (false);
		} else if (Application.loadedLevelName.Equals ("0_tutorial")) {
			gameOverScreen.SetActive (false);
			instruction1.SetActive(false);
			instruction2.SetActive (false);
			instruction3.SetActive (false);
		} else if (Application.loadedLevelName.Equals ("2_game")) {
			gameOverScreen.SetActive (false);
		} else if (Application.loadedLevelName.Equals ("3_game")) {
			gameOverScreen.SetActive (false);
		} else if (Application.loadedLevelName.Equals ("4_finalscene"))
			gameOverScreen.SetActive (false);
			winPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		ShowTexts ();
	}
	void Awake(){
		S = this;
	}

	public void backToMainMenu(){
		Application.LoadLevel ("0_menu");
	}

	public void tryAgain(){
		if(Application.loadedLevelName.Equals ("1_game"))
			Application.LoadLevel ("1_game");
		if (Application.loadedLevelName.Equals ("2_game"))
			Application.LoadLevel ("2_game");
		if (Application.loadedLevelName.Equals ("3_game"))
			Application.LoadLevel ("3_game");
		if (Application.loadedLevelName.Equals ("0_tutorial"))
			Application.LoadLevel ("0_tutorial");
		if (Application.loadedLevelName.Equals ("4_finalscene"))
			Application.LoadLevel ("4_finalscene");
	}
	void ShowTexts(){
		ammoText.text =  " "+Soldier.ammo ;
	}
	 public void ShowGameOverScreen(){
		gameOverScreen.SetActive (true);
	}
	public void ShowWinPanel(){
		winPanel.SetActive (true);
	}

}
