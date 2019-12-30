using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBellyBehaviour : MonoBehaviour
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
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
		if ( player != null )
		{
			player.AddKcal(100);
		}
	}
}
