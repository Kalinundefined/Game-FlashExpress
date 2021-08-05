using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Home : MonoBehaviour
{
    private BoxCollider2D collider;
    public Eventhandler eventhandler;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        eventhandler = GameObject.Find("eventSystem").GetComponent<Eventhandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
            eventhandler.SetEvent("home");
		}
	}
	private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown("e"))
            SceneManager.LoadScene("Home");
    }
}
