using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
{
   public Transform[] Points;
    public float moveSpeed;
    private int pointIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pointIndex < Points.Length) {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointIndex].transform.position, moveSpeed * Time.deltaTime);
            if(transform.position == Points[pointIndex].transform.position)
            {
                pointIndex += 1;
            }
            if(pointIndex == Points.Length)
            {
               
                    pointIndex =0;
                
            }
        }
    }
}
