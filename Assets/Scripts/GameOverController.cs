using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public void Yes() {
		SceneManager.LoadScene ("Stage-1");
	}

	public void No(){
		SceneManager.LoadScene ("Pre-game");
	}
}
