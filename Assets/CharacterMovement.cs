using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public float moveSpeed = 0.5f;

	Rigidbody2D rb;
	public Camera cam;

	Vector2 movement;
	Vector2 mousepos;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

		Vector2 lookDir = mousepos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg - 90f;

		Debug.Log(angle);
		rb.rotation = angle;
	}
}
