using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelSlider : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endFlag;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = playerTransform.position.y;
        slider.maxValue = endFlag.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Clamp(playerTransform.position.y, slider.minValue, slider.maxValue);
    }
}
