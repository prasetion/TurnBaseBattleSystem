using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, ICharacterInfo
{

    [SerializeField] protected float health;
    [SerializeField] protected string characterName;
    [SerializeField] protected float attack;
    public enum CharType { HERO, ENEMY }
    [SerializeField] protected CharType charType;

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float amount)
    {
        health = amount;
    }

    public float GetAttack()
    {
        return attack;
    }

    public string GetName()
    {
        return characterName;
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

    public string GetCharType()
    {
        return charType.ToString();
    }

}
