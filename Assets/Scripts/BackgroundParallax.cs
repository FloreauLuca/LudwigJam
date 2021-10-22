using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private Transform camera;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform startPoint;
    private Vector2 startPos;
    private Vector2 endPos;
    [SerializeField] private float verticalBound;
    [SerializeField] private Vector2 minPos;
    [SerializeField] private Vector2 maxPos;

    private void Start()
    {
        camera = Camera.main.transform;
        startPos = startPoint.position;
        endPos = endPoint.position;
    }

    void Update()
    {
        Vector2 localPos;
        localPos.x = Mathf.Lerp(minPos.x, maxPos.x, camera.position.x / (verticalBound + verticalBound));
        localPos.y = Mathf.Lerp(maxPos.y, minPos.y, camera.position.y / (endPos.y - startPos.y));
        transform.localPosition = new Vector3(localPos.x, localPos.y, transform.localPosition.z);
    }
}
