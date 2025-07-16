using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport _target;
    public Teleport Target { get { return _target; } }

}
