using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> menus = new List<GameObject>();

    AudioSource menuAudio;
    [SerializeField]
    AudioClip menuClick;

    void Start()
    {
        menuAudio = GetComponent<AudioSource>();

        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsButton()
    {
        menuAudio.clip = menuClick;
        menuAudio.Play();

        menus[0].SetActive(false);
        menus[1].SetActive(true);
        menus[2].SetActive(false);
        
    }

    public void CreditsButton()
    {
        menuAudio.clip = menuClick;
        menuAudio.Play();

        menus[0].SetActive(false);
        menus[1].SetActive(false);
        menus[2].SetActive(true);
    }

    public void QuitButton()
    {
        menuAudio.clip = menuClick;
        menuAudio.Play();

        Invoke("QuitApplication", menuAudio.clip.length);
    }

    void QuitApplication()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        menuAudio.clip = menuClick;
        menuAudio.Play();

        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
    }
}
