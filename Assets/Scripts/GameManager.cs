using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private bool playable = false;
    public bool Playable => playable;
    private float timer = 0.0f;
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    
    void Update()
    {
        if (playable)
        {
            timer += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        playable = true;
    }

    public void EndGame()
    {
        uiManager.DisplayEnd(timer);
        playable = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
