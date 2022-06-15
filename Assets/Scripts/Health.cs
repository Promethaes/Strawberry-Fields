//Abstracts health to a base extendable class with events

using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHP = 100.0f;
    [SerializeField] protected float health = 0.0f;
    public UnityEvent OnTakeDamage, OnDie;
    public bool died { get; protected set; }
    protected bool canTakeDamage = true;
    private void Start()
    {
        InitHealth();
    }

    protected virtual void InitHealth()
    {
        health = maxHP;
    }
    public float GetHealth()
    {
        return health;
    }
    public void SetToMaxHealth()
    {
        health = maxHP;
    }
    protected bool CanTakeDamage()
    {
        return !died && canTakeDamage;
    }
    public void setHealth(float newHealth)
    {
        this.health = newHealth;
    }
    public virtual bool TakeDamage(float damage)
    {
        if (!CanTakeDamage())
            return false;
        OnTakeDamage.Invoke();
        health -= damage;
        if (health <= 0.0f)
        {
            OnDie.Invoke();
            died = true;
        }
        return true;
    }

}
