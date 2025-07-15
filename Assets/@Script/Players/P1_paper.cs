using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class P1_Paper : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 6f;
    public float maxSpeed   = 8f;

    [Header("Jump")]
    public float jumpForce  = 14f;
    public int   maxJumpCnt = 2;
    public float coyoteTime = .1f;

    Rigidbody2D rb;
    int   jumpCnt;
    float coyote;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        /* 좌우 이동 */
        float h = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
        Vector2 vel = rb.linearVelocity;
        vel.x = Mathf.MoveTowards(vel.x, h * moveSpeed, moveSpeed * 3f * Time.deltaTime);
        vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        rb.linearVelocity = vel;

        /* 점프 */
        if (coyote > 0f && Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCnt++;
            coyote = 0;                           // 점프 직후 리셋
        }

        /* 점프 끊기(짧게 누르면 낮게) */
        if (Input.GetKeyUp(KeyCode.W) && rb.linearVelocity.y > 0)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

        coyote -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PaperZone"))
        {
            jumpCnt = 0;
            coyote  = coyoteTime;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("PaperZone"))
            coyote = 0;                           // 공중으로 판정
    }
}
