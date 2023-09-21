using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Text _coinsText;
    [Header("Prices Text")]
    [SerializeField] private Text _upgradeSpeedText;
    [Header("Prices")]
    [SerializeField] private int _startSpeedPrice;
    [Header("Buttons")]
    [SerializeField] private Button _exitShopButton;
    [SerializeField] private Button _upgradeSpeedButton;


    private void Awake()
    {
        DataInfo.Load();
        UpdateInfo();
    }

    private void Start()
    {
        _exitShopButton.onClick.AddListener(delegate { _shopPanel.gameObject.SetActive(!_shopPanel.activeSelf); });
        _upgradeSpeedButton.onClick.AddListener(delegate { UpgradeSpeed(); });
    }

    private void Update()
    {
        _coinsText.text = DataInfo.money + " coins";

    }

    private void UpgradeSpeed()
    {
        if (DataInfo.speedUpgradeLevel >= 3)
        {
            return;
        }

        if (DataInfo.money >= CalcPrice(_startSpeedPrice, DataInfo.speedUpgradeLevel))
        {
            DataInfo.money -= CalcPrice(_startSpeedPrice, DataInfo.speedUpgradeLevel);
            DataInfo.speedUpgradeLevel++;
        }
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        _upgradeSpeedText.text = "Speed\n" + (DataInfo.speedUpgradeLevel) + "/3\n" + (DataInfo.speedUpgradeLevel >= 5 ? "MAX" : +CalcPrice(_startSpeedPrice, DataInfo.speedUpgradeLevel) + " coins");
        Debug.Log(DataInfo.speedUpgradeLevel);
        DataInfo.Save();
    }

    private int CalcPrice(int price, int level)
    {
        return (int)(price * Math.Pow(2, level));
    }
}
