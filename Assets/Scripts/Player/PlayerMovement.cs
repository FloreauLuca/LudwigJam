using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private InputScript inputScript;
    private Collision collision;

    [SerializeField] private float inputStrength = 100.0f;

    [SerializeField] private int maxJump = 1;
    private int currentJump = 0;

    private PlayerSprite playerSprite;

    void Start()
    {
        playerSprite = GetComponent<PlayerSprite>();
        rigidbody = GetComponent<Rigidbody2D>();
        inputScript = FindObjectOfType<InputScript>();
        collision = GetComponent<Collision>();
        inputScript.OnInputUpEvent += OnInputUp;
    }

    void Update()
    {
        if (collision.OnGround)
        {
            currentJump = 0;
            playerSprite.ChangeColor(currentJump);
        }
    }

    private void OnInputUp(Vector2 direction)
    {
        if (currentJump < maxJump)
        {
            rigidbody.AddForce(direction * inputStrength);
            if (!collision.OnGround)
            {
                currentJump++;
                playerSprite.ChangeColor(currentJump);
            }
        }
    }
}
