using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, ICharacterInfo
{

    [SerializeField] protected int health;
    [SerializeField] protected string characterName;
    [SerializeField] protected int attack;

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int amount)
    {
        health -= amount;
    }

    public int GetAttack()
    {
        return attack;
    }

    public string GetName()
    {
        return characterName;
    }

}
