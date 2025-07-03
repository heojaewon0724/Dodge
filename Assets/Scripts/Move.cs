using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject childPrefab; // Inspector에서 자식 프리팹 할당

    public Transform childTransform; // 자식 Transform을 할당할 변수
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, -1, 0);
        childTransform.localPosition = new Vector3(0, 2, 0); // 자식 Transform의 위치를 (0, 1, 0)으로 설정
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30)); // 회전값을 (0, 180, 0)으로 설정
        childTransform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0)); // 자식 Transform의 회전값을 (0, 180, 0)으로 설정

    }                                                         // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 위쪽 화살표 키를 누르면 부모 Transform의 위치를 (0, 1, 0)으로 설정
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 아래쪽 화살표 키를 누르면 부모 Transform의 위치를 (0, -1, 0)으로 설정
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 왼쪽 화살표 키를 누르면 자식 Transform만 회전
            childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 오른쪽 화살표 키를 누르면 자식 Transform만 회전
            childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            // 자식의 복사본 생성
            GameObject clone = Instantiate(childPrefab, childTransform.position, childTransform.rotation);

            // 부모 기준 자식이 있는 방향 계산
            Vector3 shootDir = (childTransform.position - transform.position).normalized;

            // Rigidbody가 있다면 해당 방향으로 발사
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float shootPower = 10f; // 원하는 속도
                rb.linearVelocity = shootDir * shootPower;
            }
        }
    }
    }