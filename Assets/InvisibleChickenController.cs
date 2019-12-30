
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleChickenController : MonoBehaviour
{
    public float speed = 2;

    public int direction = 0;
    public float directionChangeTimer = 0;
    public float chickTimer = 0;
    public int check1 = 0;

    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 position = rigidbody2d.position;

        chickTimer += Time.deltaTime;
        

        if ((chickTimer > 11) && (check1 == 0))
        {
            position.x = 0;
            position.y = 1;
            check1 = 1;
        }
        if ((chickTimer > 12) && (check1 == 1))
        {
            position.y = 20.5f;
            check1 = 2;
        }

        if ((chickTimer > 21) && (check1 == 2))
        {
            position.x = -1;
            position.y = -2;
            check1 = 3;
        }
        if ((chickTimer > 22) && (check1 == 3))
        {
            position.y = 20.5f;
            check1 = 4;
        }

        if ((chickTimer > 31) && (check1 == 4))
        {
            position.x = 2;
            position.y = 2;
            check1 = 5;
        }
        if ((chickTimer > 32) && (check1 == 5))
        {
            position.y = 20.5f;
            check1 = 6;
        }

        if ((chickTimer > 51) && (check1 == 6))
        {
            position.x = 0;
            position.y = 0;
            check1 = 7;
        }
        if ((chickTimer > 52) && (check1 == 7))
        {
            position.y = 20.5f;
            check1 = 8
;
        }

        if ((chickTimer > 71) && (check1 == 8))
        {
            position.x = -1;
            position.y = -3;
            check1 = 9;
        }
        if ((chickTimer > 72) && (check1 == 9))
        {
            position.y = 20.5f;
            check1 = 10;
        }

        rigidbody2d.MovePosition(position);
    }
}