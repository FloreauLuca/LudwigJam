using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    
    void Update()
    {
        
    }

    public void StartGame()
    {

    }

    public void EndGame()
    {
        uiManager.DisplayEnd();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
