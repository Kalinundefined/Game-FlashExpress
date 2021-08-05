using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private SpriteRenderer sprite;
    public bool isTriggered = false;
    DialogBoxController dialogBox;
    public string[] dialogList;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        dialogBox = GameObject.Find("UI/Canvas/DialogBox").GetComponent<DialogBoxController>();
        dialogList = new string[2]
        {
            "Hellow",
            "World"
        };       
    }
    public  virtual void afterDialog() { }
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
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E) && !isTriggered)
            Trigger();
    }

    public virtual void Trigger()
    {
        isTriggered = true;
        dialogBox.setItem(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite.color = new Color32(255, 255, 255, 255);
        }
    }
}
