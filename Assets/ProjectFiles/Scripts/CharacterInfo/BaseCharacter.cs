using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, ICharacterInfo
{

    [SerializeField] protected int health;
    [SerializeField] protected string characterName;

    public void GetHealth()
    {
        Debug.Log("Health: " + health);
    }

    public void SetHealth(int amount)
    {
        health -= amount;
    }


}
