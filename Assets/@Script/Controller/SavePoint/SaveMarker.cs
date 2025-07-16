using UnityEngine;

public class SaveMarker : MonoBehaviour
{
    public bool IsCheck { get; private set; }

    [SerializeField] private Color changeColor;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Manager.Game.P1.transform || collision.transform == Manager.Game.P2.transform)
        {
            IsCheck = true;
            _sr.color = changeColor;
        }
    }
}
