using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator animator; // 추가
    public float speed = 8f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // 추가
    }

    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");

        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, playerRigidbody.linearVelocity.y, zSpeed);
        playerRigidbody.linearVelocity = newVelocity;

        // 이동 중이면 walk 애니메이션 실행
// 이동 중이면 walk 애니메이션 실행
bool isMoving = Mathf.Abs(xinput) > 0.01f || Mathf.Abs(zinput) > 0.01f;
animator.SetBool("isWalk", isMoving); // Animator에 isWalk 파라미터가 있어야 함
    }

    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.EndGame();
    }
}