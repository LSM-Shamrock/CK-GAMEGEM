using UnityEngine;

public class OrangeItem : MonoBehaviour
{
    private PlayerController _master;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_master == null && collision.TryGetComponent(out PlayerController player))
        {
            player.OrangeItems.Enqueue(this);
            _master = player;
        }
    }

    private void LateUpdate()
    {
        if (_master != null)
        {
            Vector3 targetPos = _master.transform.position - _master.LookDirection * 2f;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
        }
    }

    public void OnUse()
    { 
        Destroy(gameObject);
    }
}
