using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject LPoint;
    public GameObject RPoint;
    public Rigidbody2D rb;
    public float speed;
    private Transform currentPoint;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = RPoint.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == RPoint.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }


        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == RPoint.transform)
        {
            currentPoint = LPoint.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == LPoint.transform)
        {
            currentPoint = RPoint.transform;
        }
    }
}
