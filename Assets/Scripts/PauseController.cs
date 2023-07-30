using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenu;
    private PauseMenuAnimation pauseMenuAnim;

    void Start()
    {
        pauseMenuAnim = pauseMenu.GetComponent<PauseMenuAnimation>();
    }

    public void Resume()
    {
        pauseMenuAnim.Hide();
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuAnim.Show();
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void PauseToogle()
    {
        if(gameIsPaused)
        {
            MenulessResume();
        }
        else
        {
            MenulessPause();
        }
    }

    public void MenulessResume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void MenulessPause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ShowMenu()
    {
        pauseMenuAnim.Show();
    }
    public void HideMenu()
    {
        pauseMenuAnim.Hide();
    }
}
