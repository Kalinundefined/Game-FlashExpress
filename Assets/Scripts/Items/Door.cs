using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : ItemController {
	private void Start() {
		base.Start();
		dialogList = new string[] { "要离开吗" };
	}
	override public void afterDialog() {
		SceneManager.LoadScene("World");
	}
}
