using UnityEngine;
using System.Collections;

public class Bgm : MonoBehaviour {
	public AudioClip bgm;
	private AudioSource source;
	public static bool isOn = true;

	// Use this for initialization
	void Start () {
		source = GameObject.Find ("Audio Source").GetComponent<AudioSource> ();
		source.clip = bgm;

		if(isOn) source.Play ();
	}

}
