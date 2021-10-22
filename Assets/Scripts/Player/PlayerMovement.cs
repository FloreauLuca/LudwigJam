using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private InputScript inputScript;
    private Collision collision;

    [SerializeField] private float inputStrength = 100.0f;

    [SerializeField] private float jumpCoolDown = 0.1f;
    private float timer = 0.0f;
    [SerializeField] private int maxJump = 1;
    private int currentJump = 0;
    public int CurrentJump => currentJump;


    private PlayerSprite playerSprite;

    void Start()
    {
        playerSprite = GetComponent<PlayerSprite>();
        rigidbody = GetComponent<Rigidbody2D>();
        inputScript = FindObjectOfType<InputScript>();
        collision = GetComponent<Collision>();
        inputScript.OnInputUpEvent += OnInputUp;
        currentJump = maxJump;
    }

    void Update()
    {
        if (timer < jumpCoolDown)
        {
            timer += Time.deltaTime;
        }

        if (collision.OnGround && jumpCoolDown < timer)
        {
            currentJump = maxJump;
            playerSprite.ChangeColor(currentJump);
        }
    }

    private void OnInputUp(Vector2 direction)
    {
        if (currentJump > 0)
        {
            rigidbody.AddForce(direction * inputStrength);
            currentJump--;
            playerSprite.ChangeColor(currentJump);
            timer = 0;
        }
    }
}
