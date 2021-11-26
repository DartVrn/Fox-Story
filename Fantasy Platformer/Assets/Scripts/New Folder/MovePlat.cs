using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    float dirX;
    public float speed = 1f;

    bool moveingRight = true;



    void Update()
    {
        if (transform.position.x > 62.156f)
        {
            moveingRight = false;
        }
        else if (transform.position.x < 60.687f)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
