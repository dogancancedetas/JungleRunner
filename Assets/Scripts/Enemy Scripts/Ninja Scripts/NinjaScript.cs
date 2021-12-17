using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaScript : MonoBehaviour
{
    public GameObject shuriken;

    public float moveSpeed = 5;
    private float cameraY;
    private bool attackedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        cameraY = Camera.main.transform.position.y - 10;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Deactivate();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (transform.position.y < 0)
        {
            //When the ninja reaches middle of the screen
            if (!attackedPlayer)
            {
                //if we are in the middle of the screen and whe did not attack the player
                attackedPlayer = true;

                Instantiate(shuriken, transform.position, Quaternion.identity);
            }
        }
    }

    void Deactivate()
    {
        if (transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
