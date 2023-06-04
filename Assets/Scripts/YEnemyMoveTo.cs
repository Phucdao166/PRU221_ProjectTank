using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEnemyMoveTo : MonoBehaviour
{
    public GameObject pointD;
    public GameObject pointC;
    private Rigidbody2D rb;
    private Transform curentPoint;
    public float speed;
    private static int enemyTankInstanceCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curentPoint = pointC.transform;

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 point = curentPoint.position - transform.position;
        Debug.Log("nhay vao dau" + rb.velocity);
        if (curentPoint == pointC.transform)
        {
            rb.velocity = new Vector2(0, speed);
            Debug.Log("nhay vao dau" + rb.velocity);
        }
        else
        {
            rb.velocity = new Vector2(0, -speed);
        }
        if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == pointC.transform)
        {
            Flip();
            curentPoint = pointD.transform;
        }
        if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == pointD.transform)
        {
            Flip();
            curentPoint = pointC.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;
    }
 /*   private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }*/
}
