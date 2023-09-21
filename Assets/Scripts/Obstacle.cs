using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public delegate void PlayerKilled();

    public static event PlayerKilled OnPlayerKilled;

    [Header("Random Variables")]
    [SerializeField] private float _minObjectRotation;
    [SerializeField] private float _maxObjectRotation;
    private float randomRotation;
    [Space]
    [SerializeField] [Range(0f, 1f)] private float _movingChance;
    private float _randomValue;
    [SerializeField] private float _minObjectSpeed;
    [SerializeField] private float _maxObjectSpeed;

    private float randomSpeed;

    private void Start()
    {
        randomRotation = Random.Range(_minObjectRotation, _maxObjectRotation);
        randomSpeed = Random.Range(_minObjectSpeed, _maxObjectSpeed);
        _randomValue = Random.value;
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        transform.Rotate(0f, 0f, randomRotation * Time.deltaTime);
        transform.Translate(0, -PlayerController.instance.playerSpeed * Time.deltaTime, 0, Space.World);
        if (_randomValue < _movingChance)
        {
            transform.Translate(randomSpeed * Time.deltaTime, 0, 0, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(Player.instance.isArmorActive)
            {
                Player.instance.isArmorActive = false;
                Player.instance.armorIcon.SetActive(false);
                Player.instance.armorObject.SetActive(false);
                Destroy(gameObject);
                return;
            }
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            if (OnPlayerKilled != null)
                OnPlayerKilled();
        }
        else if (collision.gameObject.CompareTag("GarbageCollector")) 
        {
            Destroy(gameObject);
        }
    }
}
