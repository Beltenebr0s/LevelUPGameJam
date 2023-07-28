using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using JetBrains.Annotations;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private PauseController pauseController;

    private GameObject pauseMenu;
    private GameObject settingsMenu;
    private GameObject HUD;
    private GameObject dailyMenu;
    private GameObject tasksMenu;
    private Animator tasksMenuAnim;
    private ButtonChangeToogle tasksMenuBtnScript;

    private bool pauseMenuIsOpen = false;
    private bool tasksMenuIsOpen = false;
    
    public AudioMixer audiomixer;
    public bool isaudioOn;
    public float mainvolume;

    void Start()
    {
        pauseMenu = canvas.transform.Find("Pause menu").gameObject;
        settingsMenu = canvas.transform.Find("Settings menu").gameObject;
        HUD = canvas.transform.Find("HUD").gameObject;
        dailyMenu = canvas.transform.Find("DailyPopups").gameObject;

        tasksMenu = HUD.transform.Find("Tasks").gameObject;

        pauseMenu.transform.Find("Resume Btn").gameObject.GetComponent<Button>().onClick.AddListener(pauseController.Resume);
        pauseMenu.transform.Find("Settings Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenSettings);
        pauseMenu.transform.Find("Exit Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenMainMenu);

        settingsMenu.transform.Find("Back Btn").gameObject.GetComponent<Button>().onClick.AddListener(CloseSettings);
        settingsMenu.transform.Find("Slider1").gameObject.GetComponent<Slider>().onValueChanged.AddListener(SetMusicVolume);
        settingsMenu.transform.Find("Toggle1").gameObject.GetComponent<Toggle>().onValueChanged.AddListener(ToggleAudio);
        settingsMenu.transform.Find("Slider2").gameObject.GetComponent<Slider>().onValueChanged.AddListener(SetEffectVolume);
        //settingsMenu.transform.Find("Toggle2").gameObject.GetComponent<Toogle>().onValueChanged.AddListener();
        settingsMenu.transform.Find("Slider3").gameObject.GetComponent<Slider>().onValueChanged.AddListener(SetBossSize);
        settingsMenu.transform.Find("Toggle3").gameObject.GetComponent<Toggle>().onValueChanged.AddListener(ToggleGooglyEyes);

        tasksMenu.transform.Find("Btn").gameObject.GetComponent<Button>().onClick.AddListener(ToogleNotePopup);

        tasksMenuBtnScript = tasksMenu.transform.Find("Btn").gameObject.GetComponent<ButtonChangeToogle>();
        tasksMenuAnim = tasksMenu.GetComponent<Animator>();

        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        HUD.SetActive(true);
        dailyMenu.SetActive(false);
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

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (!pauseController.gameIsPaused)
            {
                ToogleNotePopup();
            }
            else if (pauseController.gameIsPaused && tasksMenuIsOpen)
            {
                ToogleNotePopup();
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
                    tasksMenuBtnScript.UnpressButton();
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

    public void SetMainVolume(float volume)
    {

        audiomixer.SetFloat("mastervolume", volume);
        mainvolume = volume;
    }
    public void SetMusicVolume(float volume)
    {

        audiomixer.SetFloat("musicvolume", volume);
    }
    public void SetEffectVolume(float volume)
    {

        audiomixer.SetFloat("effectvolume", volume);
    }
    public void ToggleAudio(bool mute)
    {
        if (mute) 
        {
            audiomixer.SetFloat("mastervolume", -40f);
            isaudioOn = false;
        }
        else
        {
            audiomixer.SetFloat("mastervolume", mainvolume);
            isaudioOn = true;
        }
    }

    public void SetBossSize(float size)
    {
        //bossBody.size = size;
        //bossBody.HacerChikito();
    }

    public void ToggleGooglyEyes(bool bolean)
    {
        //bossBody.googlyEyesOn = bolean;
        //bossBody.HacerChikito();
    }
}
