using UnityEngine;
using System.Collections;

public class OrbToggle : MonoBehaviour {
	public GameObject orb;
	private bool active = false;

	void Start(){
		
	}

	void OnTriggerStay2D(Collider2D col){
		active = true;
		if(orb != null) orb.SetActive (active);
	}

	void OnTriggerExit2D(Collider2D col){
		active = false;
		if(orb != null) orb.SetActive (active);
	}
}
