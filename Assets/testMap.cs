using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMap : MonoBehaviour
{
    public GameObject boxPrefab; // tham chiếu đến Prefab cho hộp

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M))
        {
          
            GameObject newBox = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        }
    }
}
