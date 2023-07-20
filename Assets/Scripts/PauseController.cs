using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenu;
    private Animator pauseMenuAnim;

    private IEnumerator coroutine;

    void Start()
    {
        pauseMenuAnim = pauseMenu.GetComponent<Animator>();
    }

    public void Resume()
    {
        pauseMenuAnim.Play("Escape menu popdown");
        StartCoroutine((IEnumerator)ResumeCoroutine(pauseMenuAnim, pauseMenu));
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public IEnumerator ResumeCoroutine(Animator anim, GameObject menu)
    {
        yield return new WaitForSeconds(0.55f);
        menu.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseMenuAnim.Play("Escape menu popup");
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void PauseToogle()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }
}
