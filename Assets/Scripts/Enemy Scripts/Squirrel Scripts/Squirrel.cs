using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    private float moveSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "SideBound")
        {
            moveSpeed *= -1;

            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
}
