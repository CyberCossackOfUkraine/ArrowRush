using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public static int distance;
    public bool isStopMoving;
    public static DistanceCalculator instance;

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

    private void OnEnable()
    {
        Obstacle.OnPlayerKilled += StopMoving;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerKilled -= StopMoving;
    }

    private void StopMoving()
    {
        isStopMoving = true;
    }

    void Update()
    {
        if (!isStopMoving)
        {
            transform.position += new Vector3(0, PlayerController.instance.playerSpeed * Time.deltaTime, 0);
            distance = (int) transform.position.y;
        }
    }
}
