using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text _distanceText;
    [SerializeField] private Text _coinsText;

    private void Update()
    {
        _distanceText.text = DistanceCalculator.distance + " km";
        _coinsText.text = Coin.coins + " coins"; 
    }
}
