using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector2 _moveVector;
    [SerializeField] private float _moveSpeed;

    private IEnumerator Start()
    {
        float moveTime = _moveVector.magnitude / _moveSpeed;
        Vector3 pos1 = transform.position;
        Vector3 pos2 = transform.position + (Vector3)_moveVector;

        while (true)
        {
            for (float t = 0f; t < moveTime; t += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(pos1, pos2, t / moveTime);
                yield return null;
            }
            for (float t = 0f; t < moveTime; t += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(pos2, pos1, t / moveTime);
                yield return null;
            }
        }
    }
}
