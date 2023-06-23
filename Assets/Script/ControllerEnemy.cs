using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PuntoA;
    public Transform PuntoB;
    
    public bool MoveA = false;
    public bool MoveB = false;
    public float speed;
    private Rigidbody2D rb;

    public float distanceTolerance = 0.1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveA = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveA)
        {
            rb.transform.position = Vector2.MoveTowards(transform.position, PuntoA.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, PuntoA.position) <= distanceTolerance)
            {
                MoveA = false;
                MoveB = true;
            }
        }
        else if (MoveB)
        {
            rb.transform.position = Vector2.MoveTowards(transform.position, PuntoB.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, PuntoB.position) <= distanceTolerance)
            {
                MoveA = true;
                MoveB = false;
            }
        }
    }
}
