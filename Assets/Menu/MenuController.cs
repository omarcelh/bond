using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public GameObject main;
	public GameObject credit;
	public GameObject dial_1;
	public GameObject dial_2;
	public GameObject dial_3;
	public GameObject option;
	public GameObject tutorial;

	// Use this for initialization
	void Start () {
		credit.SetActive (false);
		option.SetActive (false);
		main.SetActive (true);
		tutorial.SetActive (false);
	}

	public void NewGame() {
		StartCoroutine (Tutorial());
	}

	public void bgmToggle(){
		Bgm.isOn = !Bgm.isOn;
	}

	IEnumerator Tutorial() {
		credit.SetActive (false);
		option.SetActive (false);
		main.SetActive (false);
		tutorial.SetActive (true);

		dial_1.SetActive (true);
		dial_2.SetActive (false);
		dial_3.SetActive (false);
		yield return new WaitForSeconds (3);

		dial_1.SetActive (false);
		dial_2.SetActive (true);
		dial_3.SetActive (false);
		yield return new WaitForSeconds (3);

		dial_1.SetActive (false);
		dial_2.SetActive (false);
		dial_3.SetActive (true);
		yield return new WaitForSeconds (3);

		dial_3.SetActive (false);
		dial_1.SetActive (false);
		dial_2.SetActive (false);
		SceneManager.LoadScene ("Stage-1");
	}

	public void Option(){
		credit.SetActive (false);
		option.SetActive (true);
		main.SetActive (false);
		tutorial.SetActive (false);
	}

	public void Credit(){
		option.SetActive (false);
		credit.SetActive (true);
		main.SetActive (false);
		tutorial.SetActive (false);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ShowMain(){
		option.SetActive (false);
		credit.SetActive (false);
		main.SetActive (true);
		tutorial.SetActive (false);
	}
}
