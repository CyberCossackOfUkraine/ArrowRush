using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coins;

    void Update()
    {
        if (Time.timeScale == 0) return;
        transform.Translate(0, -PlayerController.instance.playerSpeed * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.CoinSound();
            coins++;
            Destroy(gameObject);
        }
    }
}
