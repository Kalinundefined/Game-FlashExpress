using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hospitalinner : MonoBehaviour {
	// Start is called before the first frame
	// 
	public Eventhandler eventhandler;
	private DialogBoxController dialogBox;
	void Start() {
		dialogBox = GameObject.Find("UI/Canvas/DialogBox").GetComponent<DialogBoxController>();
		eventhandler = GameObject.Find("eventSystem").GetComponent<Eventhandler>();
		eventhandler.SetEvent("hospital");
	}

	// Update is called once per frame
	void Update() {		
		if (Input.GetKeyDown("e")) {
			dialogBox.setDialog(new string[] { "要离开吗" }, afterDialog);
		}
	}

	void afterDialog() {
		SceneManager.LoadScene("World");
	}
}
