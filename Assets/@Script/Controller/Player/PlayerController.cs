using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    [SerializeField] 
    protected float _moveSpeed = 14f;

    [SerializeField] 
    protected int _maxJumpCount = 2;

    protected int _curJumpCount = 0;

    [SerializeField] 
    protected float _jumpPower = 26;

    [SerializeField] 
    protected float _fallSpeed = 60;

    [SerializeField] 
    protected bool _isSwim = false;


    public Vector3 SavePoint { get; set; }

    public float PotalCool { get; set; }
    public Queue<OrangeItem> OrangeItems { get; set; } = new Queue<OrangeItem>();

    public Vector3 LookDirection => _sr.flipX ? Vector3.left : Vector3.right;

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

        Manager.Game.DeathAction.Add(this, () =>
        {
            transform.position = SavePoint;
        });
    }

    protected virtual void Update()
    {
        if (PotalCool > 0) 
            PotalCool -= Time.deltaTime;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        _curJumpCount = 0;
    }

    protected void UpdateMove(int dir)
    {
        _rb.linearVelocityX = dir * _moveSpeed;

        if (dir > 0)
        {
            _sr.flipX = false;
        }
        if (dir < 0)
        {
            _sr.flipX = true;
        }
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
