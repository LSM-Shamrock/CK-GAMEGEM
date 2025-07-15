using UnityEngine;

public class DeathObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == Manager.Obj.P1.transform || collision.transform == Manager.Obj.P2.transform)
        {
            Manager.Game.DeathAction?.Invoke();
        }
    }
}
