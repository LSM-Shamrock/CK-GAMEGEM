using UnityEngine;

public class Savemarker : MonoBehaviour
{
    private Color _checkColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    private Color _nonCheckColor = new Color(1.0f, 1.0f, 0.0f, 0.5f);

    [SerializeField]
    SpriteRenderer _circle;

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
            _circle.color = _isCheck ? _checkColor : _nonCheckColor;
        }
    }
}
