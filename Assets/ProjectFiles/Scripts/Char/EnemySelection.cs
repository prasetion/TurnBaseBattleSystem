using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EPOOutline;

public class EnemySelection : MonoBehaviour, IPointerClickHandler
{

    ICharacterInfo charInfo;
    [SerializeField] Outlinable outlinable;
    [SerializeField] GameObject selectableObjectMarker;
    bool isClickable;

    // Start is called before the first frame update
    void Start()
    {
        TurnBaseManager.Instance.OnPrepareSelection += PrepareSelection;
        TurnBaseManager.Instance.OnSelectEnemy += SelectedEnemy;
        charInfo = GetComponent<ICharacterInfo>();
    }

    void OnDestroy()
    {
        TurnBaseManager.Instance.OnPrepareSelection -= PrepareSelection;
        TurnBaseManager.Instance.OnSelectEnemy -= SelectedEnemy;
    }

    private void SelectedEnemy(string selectedEnemy, Transform selectedTransform)
    {
        if (selectedEnemy != charInfo.GetName())
        {
            if (outlinable)
                outlinable.enabled = false;
        }
    }

    private void PrepareSelection(bool isActive)
    {
        Debug.Log($"isActive {isActive}");
        selectableObjectMarker.SetActive(isActive);
        isClickable = isActive;

        if (isActive == false)
        {
            if (outlinable)
                outlinable.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClickable == false)
            return;

        // throw new NotImplementedException();
        Debug.Log("click " + charInfo.GetName());
        if (outlinable)
            outlinable.enabled = true;

        TurnBaseManager.Instance.SelectEnemy(charInfo.GetName(), transform);
    }
}
