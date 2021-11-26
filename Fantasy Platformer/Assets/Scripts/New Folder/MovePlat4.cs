using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlat4 : MonoBehaviour
{
    float dirX;
    public float speed = 2f;

    bool moveingRight = true;



    void Update()
    {
        if (transform.position.x > 71.469)
        {
            moveingRight = false;
        }
        else if (transform.position.x < 69.427)
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
