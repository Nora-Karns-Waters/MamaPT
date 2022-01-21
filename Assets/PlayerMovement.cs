using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerMaxSpeed = 5;
    public float playerSpeed = 0;
    public float playerAcceleration = 0.05f;
    public float playerBrakeSpeed = 0.1f;

    bool isGrounded = true;

    public int playerJump = 1;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && isGrounded)
        {
            if (playerSpeed + playerAcceleration > playerMaxSpeed)
                playerSpeed = playerMaxSpeed;

            else
                playerSpeed += playerAcceleration;
            
        }


        else if (Input.GetKey(KeyCode.A) && isGrounded)
        {
            if (playerSpeed - playerBrakeSpeed < 0)
                playerSpeed = 0;

            else
                playerSpeed -= playerBrakeSpeed;
        }

        PlayerJump();

        transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);     
    }

    void PlayerJump()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerJump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded && collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
