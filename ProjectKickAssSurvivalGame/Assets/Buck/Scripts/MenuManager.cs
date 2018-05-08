using UnityEngine;
using UnityEngine.AI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;

    public GameObject OptionsMenu;

    public GameObject CreditsMenu;

    void Start()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        //Load Level name when created
    }

    public void OptionsButon()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void CreditsButton()
    {
        //Hide all other menues and enable credits menu
    }

    public void BackButton()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }
}
