using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputScript : MonoBehaviour
{
    [Header("Input")]
    private Camera mainCamera;
    [ReadOnly] [SerializeField] private Vector2 startPoint;
    [ReadOnly] [SerializeField] private Vector2 endPoint;
    [ReadOnly] [SerializeField] private bool pressed;
    public bool Pressed => pressed;
    [ReadOnly] [SerializeField] private Vector2 direction;

    [Header("Display")] 
    [SerializeField] private Transform startPointTransform;
    [SerializeField] private Transform endPointTransform;
    [SerializeField] private Transform middlePointTransform;
    private SpriteRenderer middlePointRenderer;
    [SerializeField] private Color firstJumpColor;
    [SerializeField] private Color secondJumpColor;

    public delegate void OnInputUp(Vector2 direction);
    public event OnInputUp OnInputUpEvent;

    private GameManager gameManager;
    private PlayerMovement playerMovement;

    private void Start()
    {
        mainCamera = Camera.main;
        middlePointRenderer = middlePointTransform.GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        startPointTransform.gameObject.SetActive(false);
        endPointTransform.gameObject.SetActive(false);
        middlePointTransform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameManager.Playable && playerMovement.CurrentJump > 0)
        {
            Vector2 mousePosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                pressed = true;
                startPoint = mousePosition;
            }

            endPoint = mousePosition;
            if (Input.GetMouseButtonUp(0) && pressed)
            {
                pressed = false;
                direction = endPoint - startPoint;
                if (OnInputUpEvent != null)
                {
                    OnInputUpEvent(direction);
                }
            }
            startPointTransform.gameObject.SetActive(pressed);
            endPointTransform.gameObject.SetActive(pressed);
            middlePointTransform.gameObject.SetActive(pressed);

            if (pressed)
            {
                middlePointRenderer.color = playerMovement.CurrentJump != 1 ? firstJumpColor : secondJumpColor;
                startPointTransform.position = mainCamera.ViewportToWorldPoint(startPoint);
                startPointTransform.position =
                    new Vector3(startPointTransform.position.x, startPointTransform.position.y, 0);
                endPointTransform.position = mainCamera.ViewportToWorldPoint(endPoint);
                endPointTransform.position =
                    new Vector3(endPointTransform.position.x, endPointTransform.position.y, 0);
                Vector2 middlePosition = (startPoint + endPoint) / 2;
                //middlePointTransform.position = mainCamera.ViewportToWorldPoint(middlePosition);
                //middlePointTransform.position =
                //    new Vector3(middlePointTransform.position.x, middlePointTransform.position.y, 0);
                middlePointTransform.position = startPointTransform.position;
                Vector2 relative = startPointTransform.position - endPointTransform.position;
                float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
                angle = 180 - angle;
                startPointTransform.localEulerAngles = Vector3.forward * angle;
                endPointTransform.localEulerAngles = Vector3.forward * angle;
                middlePointTransform.localEulerAngles = Vector3.forward * angle;

                middlePointRenderer.size = new Vector2(middlePointRenderer.size.x,
                    relative.magnitude / middlePointTransform.lossyScale.x);

            }
        }
    }
}
