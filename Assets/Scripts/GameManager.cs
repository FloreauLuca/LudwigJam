using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private bool playable = false;
    public bool Playable => playable;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    
    void Update()
    {
        
    }

    public void StartGame()
    {
        playable = true;
    }

    public void EndGame()
    {
        uiManager.DisplayEnd();
        playable = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
