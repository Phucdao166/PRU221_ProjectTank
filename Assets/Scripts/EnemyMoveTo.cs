using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class EnemyMoveTo : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform curentPoint;
    public float speed;
    public GameObject game;
    private static int enemyTankInstanceCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curentPoint = pointB.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 point = curentPoint.position - transform.position;
                 //Debug.Log("nhay vao dau" + rb.velocity);
        if (curentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed,0);
            //Debug.Log("nhay vao dau" + rb.velocity);
        }
        else
        {
            rb.velocity = new Vector2 (-speed,0);
        }
        if(Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == pointB.transform)
        {
            Flip();
            curentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == pointA.transform)
        {
            Flip();
            curentPoint = pointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);  
    }
/*    private IEnumerator EnemySpawn(float interval, GameObject enemy)
    {

        while (true)
        {
            yield return new WaitForSeconds(interval);
            if (enemyTankInstanceCount < 5)
            {
                GameObject newEnemy = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-5f, 5), UnityEngine.Random.Range(-6f, 6f), 0), Quaternion.identity);
                enemyTankInstanceCount++;
                //StartCoroutine(EnemySpawn( interval, newEnemy));
            }
        }
    }*/
   
}
