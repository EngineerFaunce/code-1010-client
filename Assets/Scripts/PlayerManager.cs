using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public string playerTeam;
    public int score;

    public float stamina;
    public float maxStamina = 50f;

    public float health;
    public float maxHealth = 100f;

    public GameObject model;
    public GameObject weapon;

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        stamina = maxStamina;
        health = maxHealth;
        score = 0;
    }

    public void SetScore(int _score)
    {
        score = _score;
    }

    public void SetStamina(float _stamina)
    {
        stamina = _stamina;

        if (stamina <= 0f)
        {
            // TODO: UI element to show that player is fatigued
        }
    }

    public void SetHealth(float _health)
    {
        health = _health;

        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        model.SetActive(false);
        weapon.SetActive(false);
    }

    public void Respawn()
    {
        model.SetActive(true);
        weapon.SetActive(true);
        SetHealth(maxHealth);
    }
}
