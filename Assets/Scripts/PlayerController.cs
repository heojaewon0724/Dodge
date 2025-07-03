using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
<<<<<<< HEAD
        //수평과 수직 축 입력 값을 감지하여 저장
        float xinput = Input.GetAxis("Horizontal");
        Debug.Log("xinput: " + xinput);
        float zinput = Input.GetAxis("Vertical");
        Debug.Log("zinput: " + zinput);

        //실제 이동 속도를 입력 값과 이동 속력을 통해 결정
        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.linearVelocity = newVelocity;

    }
    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindAnyObjectByType<GameManager>();

        gameManager.EndGame();

=======
        float xInput = Input.GetAxis("Horizontal");
        Debug.Log("xInput: " + xInput);
        float yInput = Input.GetAxis("Vertical");
        Debug.Log("yInput: " + yInput);

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, ySpeed);
        playerRigidbody.linearVelocity = newVelocity;
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
>>>>>>> dev
    }
}

