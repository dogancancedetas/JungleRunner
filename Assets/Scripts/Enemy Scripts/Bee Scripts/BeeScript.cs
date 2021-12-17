using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private bool attackStarted;
    private bool moveAndAttack;
    private bool attackRight;

    private float attackSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
        {
            attackRight = false;
        }
        else
        {
            attackRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BeeAttack();
    }

    void BeeAttack()
    {
        if (transform.position.y > 0)
        {
            Vector3 temp = transform.position;
            temp.y -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            //we reached the center of the screen
            if (!attackStarted)
            {
                attackStarted = true;

                StartCoroutine(AttackPlayer());
            }
        }

        if (moveAndAttack)
        {
            if (!attackRight)
            {
                transform.position -= Vector3.right * attackSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * attackSpeed * Time.deltaTime;
            }
        }
    }
    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, -45)));

        moveAndAttack = true;
        Invoke("Deactivate", 5);
    }

    
}
