using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image HealthBar;
    private float PlayerHealth = 100;
    private float MaxHealth = 100;
    private float ratio;

    // Use this for initialization
    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar() {
        ratio = PlayerHealth / MaxHealth;

        }

    void TakeDamage() {
        //call take damage
        PlayerHealth -= 10f;

        if (PlayerHealth < 0)
        {
            PlayerHealth = 0;
        }

        UpdateHealthBar();
    }
}