using UnityEngine;

public class Move1 : MonoBehaviour
{
    public GameObject childPrefab; // Inspector에서 자식 프리팹 할당
    public Transform childTransform; // 자식 Transform을 할당할 변수
    public float childDistance = 2f; // 부모로부터 자식까지의 거리
    public float shootPower = 10f;   // 발사 속도

    void Update()
    {
        // 자식의 위치를 항상 부모의 정면(childDistance만큼)에 위치
        Vector3 pos = transform.position + transform.forward * childDistance;
        pos.y += 3f;
        childTransform.position = pos;
        childTransform.rotation = transform.rotation;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject clone = Instantiate(childPrefab, childTransform.position, childTransform.rotation);
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = childTransform.forward * shootPower;
            }
        }
    }
}