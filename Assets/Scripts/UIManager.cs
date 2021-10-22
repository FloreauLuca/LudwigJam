using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private GameObject gamePanel;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        gamePanel.SetActive(false);
    }
    
    public void StartGame()
    {
        gameManager.StartGame();
        startPanel.SetActive(false);
        endPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    
    public void DisplayEnd(float time)
    {
        gameManager.StartGame();
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        gamePanel.SetActive(false);
        textMesh.text = time + "s";
    }

    public void Restart()
    {
        gameManager.RestartGame();
    }
}
