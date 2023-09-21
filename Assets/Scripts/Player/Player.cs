using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isRewardLifeUsed;
    public bool isDead;
    public bool isArmorActive;
    public GameObject armorObject;
    public GameObject armorIcon;
    public static Player instance;

    private void Awake()
    {
        Coin.coins = 0;
        isRewardLifeUsed = false;
        if (instance != this && instance != null)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerKilled += PlayerIsDead;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerKilled -= PlayerIsDead;
    }

    private void PlayerIsDead()
    {
        isDead = true;
    }

    public void Resurrect()
    {
        isDead = false;
        gameObject.SetActive(true);
        DistanceCalculator.instance.isStopMoving = false;

    }
}
