using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuAnim.Play("Escape menu popdown");
        coroutine = (IEnumerator)ResumeCoroutine(pauseMenuAnim, pauseMenu);
        StartCoroutine(coroutine);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public IEnumerator ResumeCoroutine(Animator anim, GameObject menu)
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => !(anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f));
        menu.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseMenuAnim.Play("Escape menu popup");
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MenulessPause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void PauseToogle()
    {
        if(gameIsPaused)
        {
            Resume();
        }
        else
        {
            MenulessPause();
        }
    }
}
