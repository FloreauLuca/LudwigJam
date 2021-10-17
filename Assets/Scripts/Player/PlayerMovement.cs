using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private InputScript inputScript;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        inputScript = FindObjectOfType<InputScript>();
        inputScript.OnInputUpEvent += OnInputUp;
    }

    void Update()
    {
    }

    private void OnInputUp(Vector2 direction)
    {
        rigidbody.AddForce(direction * 10);
        Debug.Log(direction);
    }
}
