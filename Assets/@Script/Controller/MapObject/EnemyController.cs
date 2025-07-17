using System.Collections;
using UnityEngine;

public enum EnemyMoveState
{
    None,
    Random,
    Follow,
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool _isFollowP1 = true;
    [SerializeField] private bool _isFollowP2 = true;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private BoxCollider2D _followArea;
    [SerializeField] private BoxCollider2D _randomMoveArea;

    SpriteRenderer _sr;

    private Transform _followTarget;

    private Vector3 _originPos;

    Coroutine _moveRoutine;

    private EnemyMoveState _moveState;
    private EnemyMoveState MoveState
    {
        get { return _moveState; } 
        set
        {
            if (_moveState == value)
                return;

            _moveState = value;
            if (_moveRoutine != null)
                StopCoroutine(_moveRoutine);

            if (_moveState == EnemyMoveState.Follow)
                _moveRoutine = StartCoroutine(FollowRoutine());
            else 
                _moveRoutine = StartCoroutine(RandomMoveRoutine());
        }
    }

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();

        _originPos = transform.position;

        Manager.Game.DeathAction.Add(this, () =>
        {
            transform.position = _originPos;
        });

        MoveState = EnemyMoveState.Random;
    }

    private void Update()
    {
        _followTarget = null;
        if (_isFollowP1 && _followArea.bounds.Contains(Manager.Game.P1.transform.position))
        {
            _followTarget = Manager.Game.P1.transform;
        }
        if (_isFollowP2 && _followArea.bounds.Contains(Manager.Game.P2.transform.position))
        {
            _followTarget = Manager.Game.P2.transform;
        }

        if (_followTarget != null) 
            MoveState = EnemyMoveState.Follow;
        else
            MoveState = EnemyMoveState.Random;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            if (player.OrangeItems.Count > 0)
            {
                player.OrangeItems.Dequeue().OnUse();
                Destroy(gameObject);
            }
            else
            {
                Manager.Game.DeathAction.Call();
            }
        }
    }

    private bool Move(Vector3 dest, float moveAmount)
    {
        Vector3 dir = (dest - transform.position).normalized;

        if (dir.x > 0f)
            _sr.flipX = true;
        if (dir.x < 0f)
            _sr.flipX = false;

        if (moveAmount >= Vector3.Distance(dest, transform.position))
        {
            transform.position = dest;
            return true;
        }
        else
        {
            transform.position += dir * moveAmount;
            return false;
        }
    }

    private IEnumerator FollowRoutine()
    {
        while (true)
        {
            yield return null;

            if (_followTarget == null)
                continue;

            Move(_followTarget.transform.position, _moveSpeed * Time.deltaTime);
        }
    }

    private IEnumerator RandomMoveRoutine()
    {
        while (true)
        {
            float wait = Random.Range(0f, 0.5f);
            yield return new WaitForSeconds(wait);

            Vector3 pos = new Vector3();
            pos.x = Random.Range(_randomMoveArea.bounds.min.x, _randomMoveArea.bounds.max.x);
            pos.y = Random.Range(_randomMoveArea.bounds.min.y, _randomMoveArea.bounds.max.y);
            Vector3 dir = (pos - transform.position).normalized;
            while (true)
            {
                yield return null;

                if (Move(pos, _moveSpeed * Time.deltaTime))
                    break;
            }
        }
    }
}
