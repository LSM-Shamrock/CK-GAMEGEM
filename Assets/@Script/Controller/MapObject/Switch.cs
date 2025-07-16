using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private int _switchChannel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Manager.Game.P1.transform || collision.transform == Manager.Game.P2.transform)
        {
            Manager.Game.SwitchChannels[_switchChannel] = !Manager.Game.SwitchChannels[_switchChannel];
        }
    }
}
