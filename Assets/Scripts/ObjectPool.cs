using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> objects = new List<GameObject>();
    public int amountPool = 20;


    [SerializeField] private GameObject BulletPrefab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountPool; i++)
        {
            GameObject obj = Instantiate(BulletPrefab);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }
        return null;
    }
}
