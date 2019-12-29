
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutController : MonoBehaviour
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
        if (directionChangeTimer <= 0)
        {
            directionChangeTimer = Random.Range(0.5f, 1.0f);
            direction = Random.Range(0, 2);
        }

        Vector2 position = rigidbody2d.position;
        switch (direction)
        {
            case 0:
                position.x += Time.deltaTime * speed;
                break;
            case 1:
                position.x -= Time.deltaTime * speed;
                break;
        }
        if (rigidbody2d.position.x < -2.2)
        {
            position.x += Time.deltaTime * speed;
        }
        else if (rigidbody2d.position.x > 2.3)
            position.x -= Time.deltaTime * speed * 2;

        rigidbody2d.MovePosition(position);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.AddKcal(1000);
        }
    }
}