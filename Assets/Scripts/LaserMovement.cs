using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [SerializeField] private int _laserSpeed;
    [SerializeField] private GameObject _coinObject;

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void Update()
    {
        transform.Translate(0, _laserSpeed * Time.deltaTime, 0);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            GameObject newCoin = Instantiate(_coinObject);
            newCoin.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
