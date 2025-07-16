using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    protected abstract float MoveSpeed { get; set; }

    protected abstract bool IsSwim { get; set; }
    protected abstract int MaxJumpCount { get; set; }
    protected abstract int CurJumpCount { get; set; }
    protected abstract float JumpPower { get; set; }
    protected abstract float FallSpeed { get; set; }

    public Vector3 SavePoint { get; set; }

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();

        if (this is P1_Paper)
        {
            Manager.Game.P1 = (P1_Paper)this;
        }
        if (this is P2_Ink)
        {
            Manager.Game.P2 = (P2_Ink)this;
        }

        SavePoint = transform.position;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        CurJumpCount = 0;
    }

    public virtual void Dead()
    {
        transform.position = SavePoint;
    }

    protected void UpdateMove(int dir)
    {
        _rb.linearVelocityX = dir * MoveSpeed;

        if (dir > 0) _sr.flipX = false;
        if (dir < 0) _sr.flipX = true;
    }

    protected void UpdateJump(bool jump)
    {
        if (jump && CurJumpCount < MaxJumpCount && _rb.linearVelocityY <= JumpPower / 2f)
        {
            _rb.linearVelocityY = JumpPower;
            CurJumpCount++;
        }
    }

    protected void UpdateFall(float deltaTime)
    {
        _rb.linearVelocityY -= deltaTime * FallSpeed;
    }

    protected void UpdateSwim()
    {
        if (IsSwim)
            CurJumpCount = 0;
    }
}
