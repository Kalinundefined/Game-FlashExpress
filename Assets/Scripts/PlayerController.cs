using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float maxSpeed = 400f;
    public Animator animator;
    public Transform rt, ld;
    private Vector3 initScale;
    private Rigidbody2D rb;
    private Eventhandler eventhandler;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        initScale = transform.localScale;
        /*eventhandler =*/ //GameObject.Find("eventSystem").GetComponent<Eventhandler>().SetEvent("world");
    }

    // Update is called once per frame
    void FixedUpdate() {
        Move();
        GameObject.Find("eventSystem").GetComponent<Eventhandler>().SetEvent("world");
    }

    private void Move() {
        /*float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * maxSpeed * Time.deltaTime);
  if (verticalInput!=0) {
            animator.SetBool("isTop", true);
  } else {
            animator.SetBool("isTop", false);
            if (horizontalInput * this.transform.localScale.x < 0) {
                this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            }
        }*/

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput != 0) {
            animator.SetBool("isTop", false);
            rb.velocity = new Vector3(horizontalInput * maxSpeed * Time.fixedDeltaTime, 0, 0);
            transform.localScale = Vector3.Scale(new Vector3(horizontalInput, 1, 1), initScale);
        } else if (verticalInput != 0) {
            animator.SetBool("isTop", true);
            rb.velocity = new Vector3(0, verticalInput * maxSpeed * Time.fixedDeltaTime, 0);
            transform.localScale = Vector3.Scale(new Vector3(1, verticalInput, 1), initScale);
        }
    }

}