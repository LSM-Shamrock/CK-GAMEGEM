using System.Collections;
using UnityEngine;

public class FrameAnim : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _frameSec = 0.1f;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(PlayAnim());
    }

    private IEnumerator PlayAnim()
    {
        while (true)
        {
            foreach (Sprite sprite in _sprites)
            {
                _sr.sprite = sprite;
                yield return new WaitForSeconds(_frameSec);
            }
        }
    }
}
