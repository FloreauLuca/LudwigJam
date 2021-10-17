using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    [Header("Input")]
    private Camera mainCamera;
    [ReadOnly] [SerializeField] private Vector2 startPoint;
    [ReadOnly] [SerializeField] private Vector2 endPoint;
    [ReadOnly] [SerializeField] private bool pressed;
    [ReadOnly] [SerializeField] private Vector2 direction;

    [Header("Display")] 
    [SerializeField] private Transform startPointTransform;
    [SerializeField] private Transform endPointTransform;
    [SerializeField] private Transform middlePointTransform;
    private SpriteRenderer middlePointRenderer;

    private void Start()
    {
        mainCamera = Camera.main;
        middlePointRenderer = middlePointTransform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
            startPoint = mousePosition;
        }
        endPoint = mousePosition;
        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
            direction = startPoint - endPoint;
        }

        if (pressed)
        {
            startPointTransform.position = startPoint;
            endPointTransform.position = endPoint;
            middlePointTransform.position = (startPoint + endPoint)/2;

            Vector2 direction =   startPointTransform.position - endPointTransform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            angle = 180 - angle;
            startPointTransform.localEulerAngles = Vector3.forward * angle;
            endPointTransform.localEulerAngles = Vector3.forward * angle;
            middlePointTransform.localEulerAngles = Vector3.forward * angle;

            middlePointRenderer.size =  new Vector2(middlePointRenderer.size.x , direction.magnitude / middlePointTransform.lossyScale.x);

        }
    }
}
