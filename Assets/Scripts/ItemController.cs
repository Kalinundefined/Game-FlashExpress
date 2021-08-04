using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool isTriggered = false;
    private string[] dialogList;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        dialogList = new string[2]
        {
            "Hellow",
            "World"
        };       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            sprite.color = new Color32(120, 120, 120, 255);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey("e") && !isTriggered)
        {
            isTriggered = true;
            Trigger();
        }
    }

    public virtual void Trigger()
    {
        GameObject.FindGameObjectWithTag("DialogBox").GetComponent<DialogBoxController>().setText(dialogList);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite.color = new Color32(255, 255, 255, 255);
        }
    }
}
