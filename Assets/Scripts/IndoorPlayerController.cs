using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndoorPlayerController : MonoBehaviour {
	public float maxSpeed = 1.0f;
	public Animator animator;
	private Rigidbody2D rb;
	private Vector3 initialScale;
	private Transform ld, rt;
	private enum Status { idle, side, front, back }
	private Status status = Status.idle;
	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		initialScale = transform.localScale;
		ld = GameObject.Find("LD").transform;
		rt = GameObject.Find("RT").transform;
		//Debug.Log(ld.position.x);
	}

	// Update is called once per frame
	void FixedUpdate() {
		Move();
	}

	private void Move() {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
		if(rb.velocity.sqrMagnitude < 1 && status!=Status.idle) 
			status = Status.idle;

		if (horizontalInput != 0) {
			rb.velocity = new Vector3(horizontalInput * maxSpeed * Time.fixedDeltaTime, 0, 0);
			transform.localScale = new Vector3(initialScale.x * horizontalInput, initialScale.y, initialScale.z);
			if ((transform.position.x > rt.position.x && horizontalInput > 0) || (transform.position.x < ld.position.x && horizontalInput < 0))
				rb.velocity = Vector3.Scale(new Vector3(0, 1, 1), rb.velocity);
			if (status != Status.side) 
				status = Status.side;

		} else if (verticalInput != 0) {
			rb.velocity = new Vector3(0, verticalInput * maxSpeed * Time.fixedDeltaTime, 0);
			if ((transform.position.y > rt.position.y && verticalInput > 0) || (transform.position.y < ld.position.y && verticalInput < 0))
				rb.velocity = Vector3.Scale(new Vector3(1, 0, 1), rb.velocity);
			if (rb.velocity.y > 0 && status != Status.back) 
				status = Status.back;
			else if (rb.velocity.y < 0 && status != Status.front) 
				status = Status.front;
		}
		if (animator.GetInteger("status") != (int)status)
			animator.SetInteger("status", (int)status);
	}

}
