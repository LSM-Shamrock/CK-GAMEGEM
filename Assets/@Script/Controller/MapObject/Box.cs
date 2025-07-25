using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class Box : MonoBehaviour
{
    private float _teleportCool = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_teleportCool <= 0f && collision.TryGetComponent(out Teleport teleport))
        {
            Vector3 delta = transform.position - collision.transform.position;
            transform.position = teleport.Target.transform.position + delta;
            _teleportCool = 1f;
        }
    }

    private void Update()
    {
        _teleportCool -= Time.deltaTime;
    }
}
