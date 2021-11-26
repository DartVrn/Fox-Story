using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlat3 : MonoBehaviour
{
    float dirX;
    public float speed = 1f;

    bool moveingRight = true;



    void Update()
    {
        if (transform.position.x > 72.991f)
        {
            moveingRight = false;
        }
        else if (transform.position.x < 70.469)
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
