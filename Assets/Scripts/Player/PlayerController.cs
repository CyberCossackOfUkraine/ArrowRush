using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    // Components
    [HideInInspector] public static PlayerController instance;
    private Rigidbody2D _rb2d;
    private Camera _camera;

    [Header("Player Stats")]
    [SerializeField] private int _playerStrafeSpeed = 1;
    public float playerSpeed = 1;

    // Timer
    [SerializeField] private float _timeToIncreaseSpeed;
    private float timer;

    // Other
    private Vector2 _playerDirection;
    private float xMin, xMax;


    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }

        _rb2d = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        xMin = _camera.ViewportToWorldPoint(new Vector3(0.07f, 0, 0)).x;
        xMax = _camera.ViewportToWorldPoint(new Vector3(0.93f, 0, 0)).x;
    }

    private void Update()
    {
        if (Time.time > timer)
        {
            if (DistanceCalculator.distance <= 250)
            {
                playerSpeed += 0.17f;
            } else if (DistanceCalculator.distance <= 500)
            {
                playerSpeed += 0.07f;
            } else
            {
                playerSpeed += 0.05f;
            }
            timer = Time.time + _timeToIncreaseSpeed;
        }
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(0))
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width/2)
            {
                _playerDirection = new Vector2(-1, 0).normalized;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 45f), 2f);
            } else if (touch.position.x > Screen.width/2)
            {
                _playerDirection = new Vector2(1, 0).normalized;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -45f), 2f);

            }
        } 
        else
        {
            _playerDirection = new Vector2(0, 0).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 2f);

        }
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(new Vector2(Mathf.Clamp(_rb2d.position.x + _playerDirection.x * (CalcSpeed(_playerStrafeSpeed, DataInfo.speedUpgradeLevel)) * Time.fixedDeltaTime, xMin, xMax),
            -3.25f));
              //_rb2d.position.y + playerSpeed * Time.fixedDeltaTime));
    }

    private int CalcSpeed(int defaultSpeed, int level)
    {
        return (int)(defaultSpeed * Math.Pow(1.4, level));
    }
}
