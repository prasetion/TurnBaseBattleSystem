using UnityEngine;

public interface ICharacterInfo
{
    public int GetHealth();
    public void SetHealth(int amount);
    public int GetAttack();
    public string GetName();
    public Transform GetTransform();
    public string GetCharType();
}