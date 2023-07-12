using UnityEngine;

public class CollisionHandlerBuilder : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) // Thay "Player" bằng tag của vật thể còn lại
        {
            rb.isKinematic = true; // Vô hiệu hóa physics cho vật thể hiện tại
            Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                otherRb.isKinematic = true; // Vô hiệu hóa physics cho vật thể va chạm
            }
        }
    }
}