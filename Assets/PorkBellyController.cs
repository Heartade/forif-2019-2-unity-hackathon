using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorkBellyController : MonoBehaviour
{
	public float speed = 2;

	public int direction = 0;
	public float directionChangeTimer = 0;

	private Rigidbody2D rigidbody2d;
	// Start is called before the first frame update
	void Start()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		directionChangeTimer -= Time.deltaTime;
		if ( directionChangeTimer <= 0 )
		{
			directionChangeTimer = Random.Range(0.5f, 1.0f);
			direction = Random.Range(0, 2);
		}

		Vector2 position = transform.position;
		switch ( direction )
		{
			case 0:
				position.x += Time.deltaTime * speed;
				break;
			case 1:
				position.x -= Time.deltaTime * speed;
				break;
		}
		if ( transform.position.x < -2.2 )
		{
			position.x += Time.deltaTime * speed;
		}
		else if ( transform.position.x > 2.3 )
			position.x -= Time.deltaTime * speed * 2;

		transform.position = position;

	}

}
