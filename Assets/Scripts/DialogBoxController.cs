using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour {
	int curIndex = 0;
	public Text dialogText;
	private string[] dialogList;
	public ItemController curItem;
	// Start is called before the first frame update
	void Start() {
		gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (curIndex < dialogList.Length - 1) {
				curIndex += 1;
				dialogText.text = dialogList[curIndex];
			} else {
				if (curItem != null) {
					curItem.afterDialog();
					curItem.isTriggered = false;
					curItem = null;
				}
				curIndex = -1;
				gameObject.SetActive(false);
			}
		}
	}

	public void setDialog(string[] _dialogList) {
		dialogList = _dialogList;
		gameObject.SetActive(true);
		curIndex = 0;
		dialogText.text = dialogList[curIndex];
	}

	public void setItem(ItemController item) {
		curItem = item;
		setDialog(item.dialogList);
	}
}
