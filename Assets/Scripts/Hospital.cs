using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hospital : ItemController
{
    private BoxCollider2D collider;
    public Eventhandler eventhandler;
    // Start is called before the first frame update
    void Start() {
        base.Start();
        collider = GetComponent<BoxCollider2D>();
        eventhandler = GameObject.Find("eventSystem").GetComponent<Eventhandler>();
        dialogList = new string[] { "要进去吗" };
    }

    // Update is called once per frame
    override public void afterDialog() {
        SceneManager.LoadScene("Hospital");
    }
}
