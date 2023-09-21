using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private GameObject _pauseMenu;

    private void Start()
    {
        _pauseButton.onClick.AddListener(delegate { ShowPauseMenu(); });
        _resumeButton.onClick.AddListener(delegate { HidePauseMenu(); });
        _backToMainMenuButton.onClick.AddListener(delegate { OpenMainMenu(); });
    }

    private void ShowPauseMenu()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void HidePauseMenu()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void OpenMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
