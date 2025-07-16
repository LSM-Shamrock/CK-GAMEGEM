using System.Collections;
using UnityEngine;

public enum EnemyMoveState
{
    Follow,
    MovePos1,
    MovePos2,
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Vector2 _moveVector = new Vector2(3f, 0f);
    [SerializeField] private bool _isFollowP1 = true;
    [SerializeField] private bool _isFollowP2 = true;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private BoxCollider2D _followArea;

    private Bounds _followAreaBounds;
    private Transform _followTarget;

    private Vector3 _pos1;
    private Vector3 _pos2;

    private EnemyMoveState _moveState;

    private void Awake()
    {
        _pos1 = transform.position;
        _pos2 = transform.position + (Vector3)_moveVector;

        _followAreaBounds = _followArea.bounds;

        Manager.Game.DeathAction.Add(this, () =>
        {
            transform.position = _pos1;
        });
    }

    private void Update()
    {
        UpdateFollowTarget();
        UpdateMovestate(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            if (player.OrangeItems.Count > 0)
            {
                player.OrangeItems.Dequeue().OnUse();
                OnDead();
            }
            else
            {
                Manager.Game.DeathAction.Call();
            }
        }
    }

    public void OnDead()
    {
        Destroy(gameObject);
    }

    private bool Move(Vector3 position, float moveAmount)
    {
        if (Vector3.Distance(transform.position, position) <= moveAmount)
        {
            transform.position = position;
            return true;
        }
        else
        {
            transform.position += (position - transform.position).normalized * moveAmount;
            return false;
        }
    }

    private void UpdateMovestate(float deltaTime)
    {
        switch (_moveState)
        {
            case EnemyMoveState.Follow:
                if (_followTarget == null)
                    _moveState = EnemyMoveState.MovePos1;
                else
                    Move(_followTarget.position, deltaTime * _moveSpeed);
                break;
            case EnemyMoveState.MovePos1:
                if (_followTarget != null)
                    _moveState = EnemyMoveState.Follow;
                else if (Move(_pos1, deltaTime * _moveSpeed))
                    _moveState = EnemyMoveState.MovePos2;
                break;
            case EnemyMoveState.MovePos2:
                if (_followTarget != null)
                    _moveState = EnemyMoveState.Follow;
                else if (Move(_pos2, deltaTime * _moveSpeed))
                    _moveState = EnemyMoveState.MovePos1;
                break;
        }
    }

    private void UpdateFollowTarget()
    {
        _followTarget = null;
        if (_isFollowP1 && _followAreaBounds.Contains(Manager.Game.P1.transform.position))
        {
            _followTarget = Manager.Game.P1.transform;
        }
        if (_isFollowP2 && _followAreaBounds.Contains(Manager.Game.P2.transform.position))
        {
            _followTarget = Manager.Game.P2.transform;
        }
    }
}
