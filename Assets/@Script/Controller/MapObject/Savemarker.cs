using UnityEngine;

public class Savemarker : MonoBehaviour
{
    private Color _checkColor = Color.gray;
    private Color _nonCheckColor = Color.yellow;

    private SpriteRenderer _sr;

    private bool _isCheck;
    public bool IsCheck 
    { 
        get
        {
            return _isCheck;
        } 
        set
        {
            _isCheck = value;
            _sr.color = _isCheck ? _checkColor : _nonCheckColor;
        }
    }

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Manager.Game.P1.transform || collision.transform == Manager.Game.P2.transform)
        {
            IsCheck = true;
        }
    }
}
