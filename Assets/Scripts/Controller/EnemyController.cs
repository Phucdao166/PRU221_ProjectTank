using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int timepoint;
    public Transform shortpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timepoint++;
        if (timepoint == 500)
        {
            Fire();
            this.timepoint = 0;
        }
    }
    private void Fire()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = shortpoint.position;
            bullet.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("on triggeer");
            Destroy(gameObject);
        }

    }
}
