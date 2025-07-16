using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float _power = 40f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rb) && rb.bodyType == RigidbodyType2D.Dynamic)
        {
            rb.linearVelocityY += _power;
        }
    }
}
