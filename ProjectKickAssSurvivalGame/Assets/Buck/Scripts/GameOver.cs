using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverMenu;

    GameObject player;
    PlayerHealth playerHealth;

    GameObject fire;
    FireHealth fireHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        fire = GameObject.FindGameObjectWithTag("Fire");
        fireHealth = fire.GetComponent<FireHealth>();

        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if(playerHealth.curHealth <= 0 || fireHealth.curHealth <= 0)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Retry()
    {
        //Do the retry and stuff
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
