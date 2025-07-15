using UnityEngine;

public class MoverObject : MonoBehaviour
{
    [SerializeField] private int _switchChannel;
    [SerializeField] private Vector2 _moveVector;
    [SerializeField] private float _moveSpeed;

    private Vector3 _onPosition;
    private Vector3 _offPosition;

    private void Awake()
    {
        _offPosition = transform.position;
        _onPosition = transform.position + (Vector3)_moveVector;
    }

    private void Update()
    {
        Vector3 movePos = Manager.Game.switchChannels[_switchChannel] ? _onPosition : _offPosition;
        transform.position = Vector3.Lerp(transform.position, movePos, _moveSpeed * Time.deltaTime);

    }

}
