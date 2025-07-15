using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    protected abstract float _moveSpeed { get; set; }

    protected abstract bool _isSwim { get; set; }
    protected abstract int _maxJumpCount { get; set; }
    protected abstract int _curJumpCount { get; set; }
    protected abstract float _jumpPower { get; set; }
    protected abstract float _fallSpeed { get; set; }

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (this is P1_Paper)
            Manager.Obj.P1 = (P1_Paper)this;

        if (this is P2_Ink)
            Manager.Obj.P2 = (P2_Ink)this;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        _curJumpCount = 0;
    }

    protected void UpdateMove(int dir)
    {
        _rb.linearVelocityX = dir * _moveSpeed;
    }

    protected void UpdateJump(bool jump)
    {
        if (jump && _curJumpCount < _maxJumpCount && _rb.linearVelocityY <= _jumpPower / 2f)
        {
            _rb.linearVelocityY = _jumpPower;
            _curJumpCount++;
        }
    }

    protected void UpdateFall(float deltaTime)
    {
        _rb.linearVelocityY -= deltaTime * _fallSpeed;
    }

    protected void UpdateSwim()
    {
        if (_isSwim)
            _curJumpCount = 0;
    }
}
