using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameOverRewardAdPanel;
    [SerializeField] private Text _distanceText;
    [SerializeField] private Text _coinsText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _openGameOverMenuRewardButton;
    public static GameOver instance;
    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        DataInfo.Load();
        _restartButton.onClick.AddListener(delegate { Restart(); });
        _mainMenuButton.onClick.AddListener(delegate { OpenMainMenu(); });
        _openGameOverMenuRewardButton.onClick.AddListener(delegate { ShowGameOverPanel(); });
        _gameOverPanel.gameObject.SetActive(false);
        
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerKilled += PlayerDead;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerKilled -= PlayerDead;
    }

    private void PlayerDead()
    {
        SoundManager.instance.ExplosionSound();
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ShowGameOverPanel();
        } 
        else if (Player.instance.isRewardLifeUsed == false)
        {
            ShowAdRewardPanel();
        } else
        {
            ShowGameOverPanel();
        }
    }

    private void ShowAdRewardPanel()
    {
        _gameOverRewardAdPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void RewardAdWatched()
    {
        _gameOverRewardAdPanel.gameObject.SetActive(false);
        Player.instance.isRewardLifeUsed = true;
        Time.timeScale = 1;
        Player.instance.Resurrect();
    }

    private void ShowGameOverPanel()
    {
        _gameOverRewardAdPanel.gameObject.SetActive(false);
        _gameOverPanel.gameObject.SetActive(true);
        if (DistanceCalculator.distance > DataInfo.highscore)
        {
            DataInfo.highscore = DistanceCalculator.distance;
        }
        DataInfo.money += Coin.coins;
        DataInfo.Save();
        _coinsText.text = "Coins: " + Coin.coins;
        _distanceText.text = "Distance - " + DistanceCalculator.distance + " km";
        Coin.coins = 0;
        Time.timeScale = 0;
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OpenMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
