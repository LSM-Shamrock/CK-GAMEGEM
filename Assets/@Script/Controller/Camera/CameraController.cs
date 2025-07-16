using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;

    private float _moveSpeed = 5f;

    [SerializeField] private CompositeCollider2D _cameraArea;

    private float HalfWidth
    {
        get { return _camera.aspect * _camera.orthographicSize; }
        set { _camera.orthographicSize = value / _camera.aspect; }
    }
    private float HalfHeight
    {
        get { return _camera.orthographicSize; }
        set { _camera.orthographicSize = value; }
    }

    private float Left
    {
        get { return transform.position.x - HalfWidth; }
        set
        {
            Vector3 p = transform.position;
            p.x = value + HalfWidth;
            transform.position = p;
        }
    }
    private float Right
    {
        get { return transform.position.x + HalfWidth; }
        set
        {
            Vector3 p = transform.position;
            p.x = value - HalfWidth;
            transform.position = p;
        }
    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 p1Pos = Manager.Game.P1.transform.position;
        Vector3 p2Pos = Manager.Game.P2.transform.position;

        Vector3 targetPos = Vector3.Lerp(p1Pos, p2Pos, 0.5f);
        targetPos.y = 0f;
        transform.position = Vector3.Lerp(transform.position, targetPos, _moveSpeed * Time.deltaTime);

        if (Left < _cameraArea.bounds.min.x && Right <= _cameraArea.bounds.max.x)
        {
            Left = _cameraArea.bounds.min.x;
        }
        if (Right > _cameraArea.bounds.max.x && Left >= _cameraArea.bounds.min.x)
        {
            Right = _cameraArea.bounds.max.x;
        }

    }
}
