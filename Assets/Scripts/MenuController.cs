using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using JetBrains.Annotations;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject dailyMenu;
    [SerializeField] private PauseController pauseController;

    private GameObject tasksMenu;
    private Animator tasksMenuAnim;
    private ButtonChangeToogle tasksMenuBtnScript;

    private bool pauseMenuIsOpen = false;
    private bool tasksMenuIsOpen = false;

    void Start()
    {

        pauseMenu.transform.Find("Resume Btn").gameObject.GetComponent<Button>().onClick.AddListener(pauseController.Resume);
        pauseMenu.transform.Find("Settings Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenSettings);
        pauseMenu.transform.Find("Exit Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenMainMenu);

        settingsMenu.transform.Find("Back Btn").gameObject.GetComponent<Button>().onClick.AddListener(CloseSettings);

        tasksMenu = HUD.transform.Find("Tasks").gameObject;

        tasksMenu.transform.Find("Btn").gameObject.GetComponent<Button>().onClick.AddListener(ToogleNotePopup);

        tasksMenuBtnScript = tasksMenu.transform.Find("Btn").gameObject.GetComponent<ButtonChangeToogle>();
        tasksMenuAnim = tasksMenu.GetComponent<Animator>();
    }

    void LateUpdate()
    {
        if (dailyMenu != null)
        {
            if (dailyMenu.activeSelf)
            {
                HUD.SetActive(false);
            }
            else
            {
                HUD.SetActive(true);
            }
        }
            
            
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenu.activeSelf)
            {
                CloseSettings();
            }
            else if (pauseController.gameIsPaused)
            {
                if (tasksMenuIsOpen)
                {
                    tasksMenuAnim.SetBool("open", false);
                    tasksMenuIsOpen = false;
                    pauseController.Pause();
                }
                else
                {
                    pauseController.Resume();
                }
            }
            else
            {
                pauseController.Pause();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        pauseMenuIsOpen = pauseMenu.activeSelf;
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CloseSettings() 
    { 
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(pauseMenuIsOpen);
    }

    public void OpenMainMenu() 
    { 
        SceneManager.LoadScene(0);
    }

    public void ToogleNotePopup()
    { 
        if (tasksMenuIsOpen)
        {
            pauseController.MenulessResume();
            tasksMenuBtnScript.UnpressButton();
            tasksMenuAnim.SetBool("open", false);
            tasksMenuIsOpen = false;
        }
        else
        {
            pauseController.MenulessPause();
            tasksMenuBtnScript.PressButton();
            tasksMenuAnim.SetBool("open", true);
            tasksMenuIsOpen = true;
        }
    }


    public AudioMixer audiomixer;

    public void SetMainVolume(float volume)
    {

        audiomixer.SetFloat("mastervolume", volume);
    }
    public void SetMusicVolume(float volume)
    {

        audiomixer.SetFloat("musicvolume", volume);
    }
    public void SetEffectVolume(float volume)
    {

        audiomixer.SetFloat("effectvolume", volume);
    }

    public GameObject BeaAnimated;
    public void QuitaDeAhi()
    {
        BeaAnimated.transform.position = new Vector3(2622, -1519, 0);
    }
    public void Vuelveahi()
    {
        BeaAnimated.transform.position = new Vector3(5, -14, 90);
    }

}
