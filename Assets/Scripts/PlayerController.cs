using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * maxSpeed * Time.deltaTime);
		if (verticalInput!=0) {
            animator.SetBool("isTop", true);
		} else {
            animator.SetBool("isTop", false);
            if (horizontalInput * this.transform.localScale.x < 0) {
                Debug.Log(horizontalInput);
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            }
        }


    }
    
}
