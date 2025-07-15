using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class P2_Ink : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float waterDrag = 5f;

    Rigidbody2D rb;
    bool inWater;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        float h = 0, v = 0;
        if (Input.GetKey(KeyCode.LeftArrow))  h = -1;
        if (Input.GetKey(KeyCode.RightArrow)) h = 1;
        if (inWater)
        {
            if (Input.GetKey(KeyCode.UpArrow))    v = 1;
            if (Input.GetKey(KeyCode.DownArrow))  v = -1;
            rb.linearDamping = waterDrag;
            rb.linearVelocity = new Vector2(h, v).normalized * swimSpeed;
        }
        else
        {
            rb.linearDamping = 0;
            rb.linearVelocity = new Vector2(h * swimSpeed, rb.linearVelocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("InkZone"))
            inWater = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("InkZone"))
            inWater = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    }
}