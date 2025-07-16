using UnityEngine;

public class FitCameraToTargets : MonoBehaviour
{
    public float padding = 1f;         // 화면 가장자리 여유
    public float minSize = 2f;         // 최소 사이즈
    public float maxSize = 20f;        // 최대 사이즈
    public Transform[] targets;        // 보여야 할 모든 오브젝트

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (!cam.orthographic)
        {
            Debug.LogWarning("이 스크립트는 Orthographic 카메라에만 사용하세요!");
        }
    }

    void LateUpdate()
    {
        if (targets == null || targets.Length == 0) return;

        float requiredSize = CalculateRequiredSize();
        cam.orthographicSize = Mathf.Clamp(requiredSize, minSize, maxSize);
    }

    float CalculateRequiredSize()
    {
        Vector3 camPos = cam.transform.position;
        float aspect = cam.aspect;

        float maxHorizontal = 0f;
        float maxVertical = 0f;

        foreach (Transform t in targets)
        {
            Vector3 offset = t.position - camPos;

            maxHorizontal = Mathf.Max(maxHorizontal, Mathf.Abs(offset.x));
            maxVertical = Mathf.Max(maxVertical, Mathf.Abs(offset.y));
        }

        // 카메라의 세로 시야가 orthographicSize 기준이고,
        // 가로는 orthographicSize * aspect
        float sizeBasedOnWidth = maxHorizontal / aspect;
        float size = Mathf.Max(sizeBasedOnWidth, maxVertical);

        return size + padding;
    }
}
