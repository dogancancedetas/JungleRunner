using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    private bool attackRight;
    private float attackSpeed = 6;


    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-45, 45)));

        if (transform.position.x > 0)
            attackRight = false;
        else
            attackRight = true;

        Invoke("Deactivate", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackRight)
        {
            //Left
            transform.position -= Vector3.right * attackSpeed * Time.deltaTime;
        }
        else
        {
            //Right
            transform.position += Vector3.right * attackSpeed * Time.deltaTime;
        }
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
