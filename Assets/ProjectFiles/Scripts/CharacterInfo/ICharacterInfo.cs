using UnityEngine;

public interface ICharacterInfo
{
    public float GetHealth();
    public void SetHealth(float amount);
    public float GetAttack();
    public string GetName();
    public Transform GetTransform();
    public string GetCharType();
}