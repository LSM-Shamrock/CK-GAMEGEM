using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;

    private float _moveSpeed = 5f;

    [SerializeField] private float dist1 = 20f;
    [SerializeField] private float dist2 = 40f;
    [SerializeField] private float size1 = 10f;
    [SerializeField] private float size2 = 20f;

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

        float dist = Mathf.Abs(p1Pos.x - p2Pos.x);

        float size = Mathf.Lerp(size1, size2, Mathf.Clamp01((dist - dist1) / (dist2 - dist1)));
        _camera.orthographicSize = size;
    }
}
