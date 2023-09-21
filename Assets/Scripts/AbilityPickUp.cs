using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickUp : MonoBehaviour
{
    public enum ThisAbility
    {
        Shield,
        Gun
    }

    public ThisAbility thisAbility;

    void Update()
    {
        if (Time.timeScale == 0) return;
        transform.Translate(0, -PlayerController.instance.playerSpeed * Time.deltaTime, 0, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (thisAbility == ThisAbility.Shield)
            {
                Player.instance.isArmorActive = true;
                Player.instance.armorIcon.SetActive(true);
                Player.instance.armorObject.SetActive(true);
            } else
            {
                LaserGun.instance.StartLaser();
            }
            Destroy(gameObject);
        }
    }
}
