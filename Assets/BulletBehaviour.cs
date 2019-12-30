using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	public float speed;
	public float angle;
	public float angleCompensation;
	float lifetime = 0;
	public float lifespan;
	public int power = 2;
	public Vector2 preliminaryMovement;
	Rigidbody2D rb;
	Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.rotation = angle + angleCompensation;
		movement = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
		transform.position = new Vector2(
			transform.position.x + movement.x * preliminaryMovement.x - movement.y * preliminaryMovement.y, 
			transform.position.y + movement.y * preliminaryMovement.x + movement.x * preliminaryMovement.y);

	}

    // Update is called once per frame
    void Update()
    {
		lifetime += Time.deltaTime;
		if ( lifespan < lifetime ) GameObject.Destroy(gameObject);
    }

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * speed);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ( collision.gameObject.GetComponent<bullet>() == null && collision.gameObject.GetComponent<BulletBehaviour>() == null && collision.gameObject.GetComponent<EnemyBehaviour>() == null) GameObject.Destroy(gameObject);
		PlayerBehaviour temp = collision.gameObject.GetComponent<PlayerBehaviour>();
		if ( temp != null ) temp.AddKcal(power);
	}

}
