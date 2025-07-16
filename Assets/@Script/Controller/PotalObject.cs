using UnityEngine;

public class PotalObject : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player) && player.PotalCool <= 0f)
        {
            player.PotalCool = 0.1f;
            player.transform.position = _target.position;
        }
    }
}
