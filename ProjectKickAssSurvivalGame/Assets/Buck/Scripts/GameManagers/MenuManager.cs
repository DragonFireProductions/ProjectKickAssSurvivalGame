using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> menus = new List<GameObject>();

    void Start()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
    }

    public void PlayButton()
    {

    }

    public void OptionsButton()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(true);
        menus[2].SetActive(false);
    }

    public void CreditsButton()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(false);
        menus[2].SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
    }
}
