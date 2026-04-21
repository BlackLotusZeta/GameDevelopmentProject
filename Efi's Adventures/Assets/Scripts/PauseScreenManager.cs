using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseScreenManager : MonoBehaviour
{
    // opens whenever game is paused
    public GameObject pauseScreen;

    
    public Button continueButton;
    public Button saveGame;
    public Button quitButton;

    private bool paused;

    void Start()
    {
        pauseScreen.SetActive(false);
    }


    void Update()
    {
        Paused();
    }

    public void Paused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if(paused == true)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;

            if(EventSystem.current.currentSelectedGameObject == null)
            {
                continueButton.Select();
            }
        }
        else
        {
            pauseScreen.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
        else
        {
            Application.Quit();
        }
    }

    public void UnPaused()
    {
        paused = false;
    }
}
