using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cavanmap : MonoBehaviour
{
    public GameObject[] prefab = null;
    public Camera cam = null;
    public GameObject taget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstantiateObject();
    }
    public void Object1() { 
         taget = prefab[0];
        Debug.Log("nay ra gì?" + taget);
    }
    public void lala()
    {
        taget = prefab[1];
        Debug.Log("nay ra gì?" + taget);
    }
    public void nuoc()
    {
        taget = prefab[2];
    }
    public void khieng()
    {
        taget = prefab[3];
    }
    public void InstantiateObject()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log("abc + " +Input.GetMouseButtonDown(0));
            if (Input.GetMouseButtonDown(0))
            {
                /*Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                Debug.Log(ray);
                
                RaycastHit hit;
                Debug.Log(Physics.Raycast(ray, out hit));
                if (Physics.Raycast(ray, out hit))
                {*/
                    Debug.Log(taget);
                Debug.Log(Input.mousePosition);
                    Instantiate(taget, Input.mousePosition, Quaternion.identity);
                /*}*/
            }
        }
    }
}
