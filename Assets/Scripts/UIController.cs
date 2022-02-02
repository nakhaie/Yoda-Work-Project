using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider HpBar;
    public GameObject GameOverPanel;
    public GameObject PausePanel;

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetHp(float curHp, float maxHp)
    {
        HpBar.value = (curHp / maxHp);
    }

    public void SetPause(bool isPause)
    {
        PausePanel.SetActive(isPause);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        SetPause(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
}
