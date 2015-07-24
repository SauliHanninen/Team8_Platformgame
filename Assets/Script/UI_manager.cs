using UnityEngine;
using System.Collections;

public class UI_manager : MonoBehaviour {
	public void StartGame(){
		Application.LoadLevel ("1_game");
	}
	public void QuitGame(){
		Application.Quit ();
	}
	public GameObject selectLevelPanel;
	public void showSelectLevelPanel(){
		selectLevelPanel.SetActive (true);
	}
	public void hideSelectLevelPanel(){
		selectLevelPanel.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		selectLevelPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
