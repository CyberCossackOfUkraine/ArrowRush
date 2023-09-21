using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _resetSaveButton;
    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Text _highscoreText;
    [SerializeField] private Text _coinsText;

    private void Start()
    {
        DataInfo.Load();
        _highscoreText.text = "Highscore: " + DataInfo.highscore;
        _coinsText.text = "Coins: " + DataInfo.money;
        _startButton.onClick.AddListener(delegate { SceneManager.LoadScene("level"); });
        _shopButton.onClick.AddListener(delegate { _shopPanel.gameObject.SetActive(!_shopPanel.gameObject.activeSelf); });
        _resetSaveButton.onClick.AddListener(delegate { DataInfo.ResetSave(); });
        _addCoinsButton.onClick.AddListener(delegate { DataInfo.money += 9999; DataInfo.Save(); });
    }
}
