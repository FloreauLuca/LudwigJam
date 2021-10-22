using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteIdle;
    [SerializeField] private Sprite[] spriteUp;
    [SerializeField] private Sprite[] spriteDown;
    private int colorIndex = 0;
    private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Transform spriteTransform;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteTransform = spriteRenderer.transform;
    }
    
    void Update()
    {
        Vector2 velocity = rigidbody.velocity;
        float angle = Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg;
        angle  = (angle + 180) % 180;
        angle *= -1;
        angle -= 90;
        if (velocity.x != 0)
            spriteRenderer.flipX = (velocity.x > 0);

        if (velocity.y > 0.1f)
        {
            spriteRenderer.sprite = spriteUp[colorIndex];
            spriteTransform.localEulerAngles = new Vector3(0, 0, angle);
            spriteRenderer.flipY = true;
        }
        else if(velocity.y < -0.1f)
        {
            spriteRenderer.sprite = spriteDown[colorIndex];
            spriteTransform.localEulerAngles = new Vector3(0, 0, angle);
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.sprite = spriteIdle[colorIndex];
            spriteTransform.localEulerAngles = new Vector3(0, 0, 0);
            spriteRenderer.flipY = false;
        }
    }

    public void ChangeColor(int restingJump)
    {
        colorIndex = restingJump;
    }
}
