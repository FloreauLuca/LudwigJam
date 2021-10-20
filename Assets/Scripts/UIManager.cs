using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;
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
    
    public void DisplayEnd()
    {
        gameManager.StartGame();
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void Restart()
    {
        gameManager.RestartGame();
    }
}
