using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hospitalinner : MonoBehaviour {
	// Start is called before the first frame
	// 
	public Eventhandler eventhandler;
	void Start() {
		eventhandler = GameObject.Find("eventSystem").GetComponent<Eventhandler>();
	}

	// Update is called once per frame
	void Update() {
		eventhandler.SetEvent("hospital");
		if (Input.GetKeyDown("e")) {
			SceneManager.LoadScene("World");
		}
	}
}
