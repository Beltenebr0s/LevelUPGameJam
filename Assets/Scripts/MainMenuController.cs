using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using JetBrains.Annotations;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private float blinkRange = 0.005f;
    [SerializeField] private AudioSource buttonPress;

    private GameObject mainMenu;
    private GameObject settingsMenu;
    private GameObject introPanel;
    private GameObject playerSprite;

    public AudioMixer audiomixer;
    public bool isaudioOn = true;
    public float mainvolume;

    void Start()
    {
        GetComponents();
        AddListeners();
        AdjustSettings();

        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        introPanel.SetActive(false);
        playerSprite.SetActive(true);

        playerSprite.GetComponent<Animator>().Play("PTitleScreen");
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsMenu.activeSelf)
        {
            CloseSettings();
        }

        if (Random.value < blinkRange)
        {
            playerSprite.GetComponent<Animator>().SetTrigger("blink");
        }
    }

    private void GetComponents()
    {
        mainMenu = canvas.transform.Find("Main menu").gameObject;
        settingsMenu = canvas.transform.Find("Settings menu").gameObject;
        introPanel = canvas.transform.Find("Intro panel").gameObject;
        playerSprite = canvas.transform.Find("Main Character").gameObject;
    }

    private void AddListeners()
    {
        mainMenu.transform.Find("Start Btn").gameObject.GetComponent<Button>().onClick.AddListener(ShowIntro);
        mainMenu.transform.Find("Start Btn").gameObject.GetComponent<Button>().onClick.AddListener(buttonPress.Play);
        mainMenu.transform.Find("Settings Btn").gameObject.GetComponent<Button>().onClick.AddListener(OpenSettings);
        mainMenu.transform.Find("Settings Btn").gameObject.GetComponent<Button>().onClick.AddListener(buttonPress.Play);
        mainMenu.transform.Find("Quit Btn").gameObject.GetComponent<Button>().onClick.AddListener(QuitGame);
        mainMenu.transform.Find("Quit Btn").gameObject.GetComponent<Button>().onClick.AddListener(buttonPress.Play);

        settingsMenu.transform.Find("Back Btn").gameObject.GetComponent<Button>().onClick.AddListener(CloseSettings);
        settingsMenu.transform.Find("Back Btn").gameObject.GetComponent<Button>().onClick.AddListener(buttonPress.Play);
        settingsMenu.transform.Find("Slider1").gameObject.GetComponent<Slider>().onValueChanged.AddListener(SetMainVolume);
        settingsMenu.transform.Find("Toggle1").gameObject.GetComponent<Toggle>().onValueChanged.AddListener(ToggleAudio);
        settingsMenu.transform.Find("Slider2").gameObject.GetComponent<Slider>().onValueChanged.AddListener(SetEffectVolume);
        //settingsMenu.transform.Find("Toggle2").gameObject.GetComponent<Toogle>().onValueChanged.AddListener();
        settingsMenu.transform.Find("Slider3").gameObject.GetComponent<Slider>().onValueChanged.AddListener(SetBossSize);
        settingsMenu.transform.Find("Toggle3").gameObject.GetComponent<Toggle>().onValueChanged.AddListener(ToggleGooglyEyes);

        introPanel.transform.Find("Start Btn").gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
        introPanel.transform.Find("Start Btn").gameObject.GetComponent<Button>().onClick.AddListener(buttonPress.Play);
    }

    private void AdjustSettings()
    {
        settingsMenu.transform.Find("Slider1").gameObject.GetComponent<Slider>().SetValueWithoutNotify(Settings.mainVolume);
        SetMusicVolume(Settings.mainVolume);
        settingsMenu.transform.Find("Toggle1").gameObject.GetComponent<Toggle>().SetIsOnWithoutNotify(Settings.isSoundOff);
        ToggleAudio(Settings.isSoundOff);
        settingsMenu.transform.Find("Slider2").gameObject.GetComponent<Slider>().SetValueWithoutNotify(Settings.effectsVolume);
        SetEffectVolume(Settings.effectsVolume);
        //settingsMenu.transform.Find("Toggle2").gameObject.GetComponent<Toogle>().onValueChanged.AddListener();
        settingsMenu.transform.Find("Slider3").gameObject.GetComponent<Slider>().SetValueWithoutNotify(Settings.bossSize);
        settingsMenu.transform.Find("Toggle3").gameObject.GetComponent<Toggle>().SetIsOnWithoutNotify(Settings.googlyEyes);
    }

    public void ShowIntro()
    {
        introPanel.SetActive(true);
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
        playerSprite.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        playerSprite.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SetMainVolume(float volume)
    {
        if(!Settings.isSoundOff)
        {
            audiomixer.SetFloat("mastervolume", volume);
        }
        Settings.mainVolume = volume;
        mainvolume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        Settings.musicVolume = volume;
        audiomixer.SetFloat("musicvolume", volume);
    }
    public void SetEffectVolume(float volume)
    {
        Settings.effectsVolume = volume;
        audiomixer.SetFloat("effectvolume", volume);
    }
    public void ToggleAudio(bool mute)
    {
        Settings.isSoundOff = mute;
        if (mute)
        {
            audiomixer.SetFloat("mastervolume", -100f);
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
        Settings.bossSize = size;
    }

    public void ToggleGooglyEyes(bool bolean)
    {
        Settings.googlyEyes = bolean;
    }
}
