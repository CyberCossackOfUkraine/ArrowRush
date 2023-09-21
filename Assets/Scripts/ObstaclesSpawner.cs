using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;
    private Camera _camera;
    private float _xMin, _xMax;
    [Header("Random Variables")]
    [SerializeField] private float _minTimeBetweenSpawn;
    [SerializeField] private float _maxTimeBetweenSpawn;
    [Space]
    [SerializeField] private float _minObjectScale;
    [SerializeField] private float _maxObjectScale;
    [Space]
    [SerializeField] [Range(0f, 1f)] private float _coinChance;
    [SerializeField] [Range(0f, 1f)] private float _armorChance;
    [SerializeField] [Range(0f, 1f)] private float _laserGunChance;
    private float spawnTime;
    GameObject newObstacle;

    private void Start()
    {
        _camera = Camera.main;
        spawnTime = Time.time + _maxTimeBetweenSpawn;
    }

    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            float randomTime = Random.Range(_minTimeBetweenSpawn, _maxTimeBetweenSpawn);
            spawnTime = Time.time + (randomTime / PlayerController.instance.playerSpeed);
        }
    }

    private void Spawn()
    {
        // Set random spawn position
        _xMin = _camera.ViewportToWorldPoint(new Vector3(0.07f, 0f, 0f)).x;
        _xMax = _camera.ViewportToWorldPoint(new Vector3(0.93f, 0f, 0f)).x;
        float randomX = Random.Range(_xMin, _xMax);
        // Randomize object (coin or obstacle)

        // Spawn Object
        if (Random.value < _laserGunChance)
        {
            // Spawn Laser Gun
            newObstacle = Instantiate(_obstacles[4], new Vector3(randomX, _camera.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y, 0), transform.rotation);

        }
        else if (Random.value < _armorChance)
        {
            //Spawn armor
            newObstacle = Instantiate(_obstacles[3], new Vector3(randomX, _camera.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y, 0), transform.rotation);

        } else if (Random.value < _coinChance)
        {
            //Spawn coin
            newObstacle = Instantiate(_obstacles[2], new Vector3(randomX, _camera.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y, 0), transform.rotation);
        }
        else
        {
            //Spawn obstacle
            int random = Random.Range(0, 1);
            newObstacle = Instantiate(_obstacles[random], new Vector3(randomX, _camera.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y, 0), transform.rotation);
            // Set random scale
            float randomScale = Random.Range(_minObjectScale, _maxObjectScale);
            newObstacle.transform.localScale = new Vector3(randomScale, randomScale, 1);
        }


    }
}
