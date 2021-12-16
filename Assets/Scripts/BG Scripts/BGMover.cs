using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : MonoBehaviour
{
    public float moveSpeed = 5;

    private GameObject[] sideBounds;
    private float cameraY;
    private float boundHeight;

    void Awake()
    {
        sideBounds = GameObject.FindGameObjectsWithTag("SideBound");
        cameraY = Camera.main.gameObject.transform.position.y - 15;

        boundHeight = GetComponent<BoxCollider2D>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Reposition();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    void Reposition()
    {
        if (transform.position.y < cameraY)
        {
            float highestBoundsY = sideBounds[0].transform.position.y;

            for (int i = 1; i < sideBounds.Length; i++)
            {
                if (highestBoundsY < sideBounds[i].transform.position.y)
                {
                    highestBoundsY = sideBounds[i].transform.position.y;
                }
            }

            Vector3 temp = transform.position;
            temp.y = highestBoundsY + boundHeight;
            transform.position = temp;
        }
    }
}
