using UnityEngine;
using System.Collections;

public class OrbToggle : MonoBehaviour {
	public GameObject orb;
	private bool active = false;

	void Start(){
		orb.SetActive (active);
	}

	void Update(){
		orb.SetActive (active);
	}

	void OnTriggerStay2D(Collider2D col){
		active = true;
		orb.SetActive (active);
	}

	void OnTriggerExit2D(Collider2D col){
		Debug.Log("CCC");
		active = false;
		orb.SetActive (active);
	}
}
