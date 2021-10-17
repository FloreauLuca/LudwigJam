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

    private void Start()
    {
        mainCamera = Camera.main;
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
        }
    }
}
