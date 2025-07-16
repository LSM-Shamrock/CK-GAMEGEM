using UnityEngine;

public class DeathObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player))
        {
            Manager.Game.DeathAction?.Invoke();
        }
    }
}
