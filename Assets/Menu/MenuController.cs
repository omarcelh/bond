using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public GameObject main;
	public GameObject credit;
	public GameObject option;

	// Use this for initialization
	void Start () {
		credit.SetActive (false);
		option.SetActive (false);
		main.SetActive (true);
	}

	public void NewGame() {
		SceneManager.LoadScene ("Stage-1");
	}

	public void Option(){
		credit.SetActive (false);
		option.SetActive (true);
		main.SetActive (false);
	}

	public void Credit(){
		option.SetActive (false);
		credit.SetActive (true);
		main.SetActive (false);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ShowMain(){
		option.SetActive (false);
		credit.SetActive (false);
		main.SetActive (true);
	}
}
