using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePaused = false;
    bool gameOver = false;
    [SerializeField] Spaceship player;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] int numAnimales;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && gameOver==false)
        PauseGame();
       
    }
    public void StarGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void NextLevelTwo()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void NextLevelThree()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    void PauseGame()
  
    {
        gamePaused = gamePaused ? false : true;
        player.gamePaused = gamePaused;
        pauseMenu.SetActive(gamePaused);
        Time.timeScale = gamePaused ? 0 : 1;
    }

        public void numeroanimales()
    {
        numAnimales--;
        if(numAnimales<1)
        {
            Ganar();

        }
    }
    void Ganar()
    {
        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        gameOverMenu.SetActive(true);
    }
}

