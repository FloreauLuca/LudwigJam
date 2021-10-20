using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [ReadOnly] [SerializeField] private bool onGround = false;
    public bool OnGround => onGround;

    [Header("Layers")]

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float collisionRadius = 0.25f;
    [SerializeField] private Vector2 bottomOffset;
    private Color debugCollision = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset * transform.lossyScale, collisionRadius * transform.lossyScale.x, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset * transform.lossyScale, collisionRadius * transform.lossyScale.x);
    }
}
