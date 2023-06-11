using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldetEnemy : MonoBehaviour
{
    private float speed = 2f;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("brick"))
        {
            Debug.Log("enemy");
            Destroy(gameObject);
        }
    }*/
}
