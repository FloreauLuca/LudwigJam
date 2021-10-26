using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowParticles : MonoBehaviour
{
    private ParticleSystem particles;
    [SerializeField] private float rate = 10.0f;
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        particles.emissionRate = rate * (slider.value - slider.minValue) / (slider.maxValue - slider.minValue);
    }
}
