using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public Text dialogText;
    public GameObject dialogBox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ShowText();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * maxSpeed * Time.deltaTime);
    }

    private void ShowText()
    {
        if (Input.GetKey("e"))
        {
            dialogBox.SetActive(true);
            dialogText.text = "This is text.";
        }
    }
}
