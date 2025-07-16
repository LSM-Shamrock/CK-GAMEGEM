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
    [SerializeField] private float _followRange = 10f;
    [SerializeField] private float _moveSpeed = 5f;

    private Transform _followTarget;

    private Vector3 _pos1;
    private Vector3 _pos2;

    private EnemyMoveState _moveState;

    private void Awake()
    {
        _pos1 = transform.position;
        _pos2 = transform.position + (Vector3)_moveVector;
    }

    private void Update()
    {
        UpdateFollowTarget();
        UpdateMovestate(Time.deltaTime);
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
        if (_isFollowP1 && !_isFollowP2)
        {
            if (Vector3.Distance(transform.position, Manager.Game.P1.transform.position) <= _followRange)
            {
                _followTarget = Manager.Game.P1.transform;
            }
        }
        if (!_isFollowP1 && _isFollowP2)
        {
            if (Vector3.Distance(transform.position, Manager.Game.P2.transform.position) <= _followRange)
            {
                _followTarget = Manager.Game.P2.transform;
            }
        }
        if (_isFollowP1 && _isFollowP2)
        {
            float p1Dist = Vector3.Distance(transform.position, Manager.Game.P1.transform.position);
            float p2Dist = Vector3.Distance(transform.position, Manager.Game.P2.transform.position);
            if (Mathf.Min(p1Dist, p2Dist) <= _followRange)
            {
                _followTarget = p1Dist < p2Dist ? Manager.Game.P1.transform : Manager.Game.P2.transform;
            }
        }
    }
}
