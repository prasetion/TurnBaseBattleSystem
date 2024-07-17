using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnBaseManager : Singleton<TurnBaseManager>
{

    public System.Action<bool> OnPrepareSelection;
    public System.Action OnRestartSelectMovement;
    public System.Action<string, Transform> OnSelectEnemy;
    public System.Action<string, bool, Transform> OnMove;
    public System.Action<string, float> OnGetHit;
    public System.Action<bool> OnWin;

    // Change order in this list
    public List<string> MovementOrder = new List<string> { "Ahmed", "Adam", "Eve" };
    public List<ICharacterInfo> CharacterInformationList = new List<ICharacterInfo>();

    bool isNormalAttack;

    int currentOrder = 0;
    float currentDamage = 0;
    string selectedEnemy;
    Transform currentTransformEnemy;

    public Transform currentHero;

    public float CurrentDamage { get => currentDamage; set => currentDamage = value; }

    public void RemoveEnemyFromList(string enemyName)
    {
        List<string> removeMovementOrder = new List<string>();
        List<ICharacterInfo> removeCharacterInfo = new List<ICharacterInfo>();

        foreach (var item in MovementOrder)
        {
            if (item != enemyName)
                removeMovementOrder.Add(item);
        }

        foreach (var item in CharacterInformationList)
        {
            if (item.GetName() != enemyName)
                removeCharacterInfo.Add(item);
        }

        MovementOrder = removeMovementOrder;
        CharacterInformationList = removeCharacterInfo;
    }

    public void SelectMovement(string movement)
    {
        isNormalAttack = movement.Contains("Attack") ? true : false;
    }

    public void SelectPreparation(bool isReady)
    {
        OnPrepareSelection?.Invoke(isReady);
    }

    public void SelectEnemy(string enemyName, Transform enemyTransform)
    {
        OnSelectEnemy?.Invoke(enemyName, enemyTransform);
        selectedEnemy = enemyName;
        currentTransformEnemy = enemyTransform;
    }

    public void GetHit(string target = "")
    {
        StartCoroutine(GetHitRoutine(target));
    }

    IEnumerator GetHitRoutine(string target = "")
    {
        yield return new WaitForSeconds(0.5f);
        OnGetHit?.Invoke(selectedEnemy, CurrentDamage);
    }

    public void Proceed()
    {
        Debug.Log("Proceed");
        SelectPreparation(false);
        // hero movement
        OnMove?.Invoke(Const.HERO_NAME, isNormalAttack, currentTransformEnemy);
    }

    public void FinishMovement()
    {
        if (!CharacterInformationList.Any(character => character.GetCharType().Contains("HERO")))
        {
            Debug.Log("There are no heroes in the list.");
            OnWin?.Invoke(false);
            return;
        }
        else if (CharacterInformationList.Any(character => character.GetCharType().Contains("HERO")) && CharacterInformationList.Count == 1)
        {
            OnWin?.Invoke(true);
            Debug.Log("There is at least one hero in the list.");
            return;
        }


        currentOrder++;
        Debug.Log($"Finish Movement {currentOrder}");

        if (currentOrder >= MovementOrder.Count)
        {
            currentOrder = 0;
            // TODO: player do selection again
            Debug.Log("do hit again");
            OnRestartSelectMovement?.Invoke();
            return;
        }

        if (currentOrder > 0)
        {
            // TODO: enemy movement
            Debug.Log("move enemy");
            selectedEnemy = Const.HERO_NAME;
            OnMove?.Invoke(MovementOrder[currentOrder], true, currentHero);
        }

    }


}
