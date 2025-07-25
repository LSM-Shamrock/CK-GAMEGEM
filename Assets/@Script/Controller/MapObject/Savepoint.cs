using UnityEngine;

public class Savepoint : MonoBehaviour
{
    [SerializeField] private Savemarker _marker1;
    [SerializeField] private Savemarker _marker2;
    [SerializeField] private Transform _wall;

    private bool _isOn = false;

    private void Awake()
    {
        _marker1.IsCheck = false;
        _marker2.IsCheck = false;
        Manager.Game.DeathAction.Add(this, () =>
        {
            _marker1.IsCheck = false;
            _marker2.IsCheck = false;
        });
    }

    private void Update()
    {
        if (Manager.Game.P1.transform.position.x >= transform.position.x)
            _marker1.IsCheck = true;
        if (Manager.Game.P2.transform.position.x >= transform.position.x)
            _marker2.IsCheck = true;

        if (!_isOn && _marker1.IsCheck && _marker2.IsCheck)
        {
            Manager.Game.P1.SavePoint = _marker1.transform.position;
            Manager.Game.P2.SavePoint = _marker2.transform.position;
            _wall.gameObject.SetActive(false);
            Manager.Game.CurLevel++;
            _isOn = true;
        }
    }
}
