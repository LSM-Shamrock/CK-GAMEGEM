using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _moveSpeed = 5f;

    private void LateUpdate()
    {
        Vector3 targetPos = Vector3.Lerp(Manager.Obj.P1.transform.position, Manager.Obj.P2.transform.position, 0.5f);
        targetPos.y = 0f;

        transform.position = Vector3.Lerp(transform.position, targetPos, _moveSpeed * Time.deltaTime);
    }
}
