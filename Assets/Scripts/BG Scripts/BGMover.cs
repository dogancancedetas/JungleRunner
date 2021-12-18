using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : MonoBehaviour
{
    public float moveSpeed = 5;

    private GameObject[] sideBounds;
    private float cameraY;
    private float boundHeight;

    public GameObject[] enemies;
    public GameObject[] spawnPositions;
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
                    highestBoundsY = sideBounds[i].transform.position.y;
            }

            Vector3 temp = transform.position;
            temp.y = highestBoundsY + boundHeight;
            transform.position = temp;

            //Spawn enemies
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        //Frequency of spawning enemies
        if (Random.Range(0,10) > 0)
        {
            int randomEnemyIndex = Random.Range(0, enemies.Length);

            if (randomEnemyIndex == 0)
            {
                //Flag enemy - needs to be spawned in the middle
                Instantiate(enemies[randomEnemyIndex], new Vector3(0, transform.position.y, 3), Quaternion.identity);
            }
            else
            {
                GameObject enemyObj = Instantiate(enemies[randomEnemyIndex]);
                Vector3 enemyScale = enemyObj.transform.localScale;

                if (Random.Range(0,2) > 0)
                {
                    //Spawn right
                    enemyObj.transform.position = spawnPositions[0].transform.position;
                    enemyScale.x = -Mathf.Abs(enemyScale.x);
                }
                else
                {
                    //Spawn left
                    enemyObj.transform.position = spawnPositions[1].transform.position;
                    enemyScale.x = Mathf.Abs(enemyScale.x);
                }

                enemyObj.transform.localScale = enemyScale;
            }
        }
    }
}
