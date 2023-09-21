using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private GameObject _laserObject;
    [SerializeField] private float _secondsBetweenShots;
    [SerializeField] private int _shotCounts;
    public static LaserGun instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    private bool _isLaserStarted;
    public void StartLaser()
    {
        if (!_isLaserStarted)
        {
            _isLaserStarted = true;
            StartCoroutine(Laser());
        } 
    }

    IEnumerator Laser()
    {
        int x = _shotCounts;
        while (x > 0)
        {
            GameObject newLaser = Instantiate(_laserObject);
            newLaser.transform.position = transform.position;
            x--;
            yield return new WaitForSeconds(_secondsBetweenShots);
        }
        _isLaserStarted = false;
    }

}
