using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] 
    private int _switchChannel;

    [SerializeField]
    private GameObject _switchOffHandle;
    [SerializeField]
    private GameObject _switchOnHandle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Manager.Game.P1.transform || collision.transform == Manager.Game.P2.transform)
        {
            Manager.Game.SwitchChannels[_switchChannel] = !Manager.Game.SwitchChannels[_switchChannel];
        }
    }

    private void Update()
    {
        _switchOffHandle.SetActive(!Manager.Game.SwitchChannels[_switchChannel]);
        _switchOnHandle.SetActive(Manager.Game.SwitchChannels[_switchChannel]);
    }
}
