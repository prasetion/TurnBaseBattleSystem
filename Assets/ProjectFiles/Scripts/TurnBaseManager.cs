using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBaseManager : Singleton<TurnBaseManager>
{

    public System.Action<bool> OnPrepareSelection;
    public System.Action<string> OnSelectEnemy;

    public void SelectPreparation(bool isReady)
    {
        OnPrepareSelection?.Invoke(isReady);
    }

    public void SelectEnemy(string enemyName)
    {
        OnSelectEnemy?.Invoke(enemyName);
    }

}
