using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Select Enemy")]
    [SerializeField] GameObject selectEnemyPanel;

    [Header("Movement Panel UI")]
    [SerializeField] GameObject selectMovementPanel;
    [SerializeField] Button attackSelected;
    [SerializeField] Button skillSelected;

    [Header("Proceed")]
    [SerializeField] Button proceedButton;

    // Start is called before the first frame update
    void Start()
    {
        TurnBaseManager.Instance.OnSelectEnemy += EnemySelected;
        TurnBaseManager.Instance.OnRestartSelectMovement += RestartSelectMovement;

        attackSelected.onClick.AddListener(() => SelectMovement("Attack"));
        skillSelected.onClick.AddListener(() => SelectMovement("Skill"));

        proceedButton.onClick.AddListener(() =>
        {
            TurnBaseManager.Instance.Proceed();
            proceedButton.gameObject.SetActive(false);
            selectEnemyPanel.SetActive(false);
        });

        selectMovementPanel.SetActive(false);
        selectEnemyPanel.SetActive(false);
        proceedButton.gameObject.SetActive(false);
    }


    void OnDestroy()
    {
        TurnBaseManager.Instance.OnSelectEnemy -= EnemySelected;
        TurnBaseManager.Instance.OnRestartSelectMovement -= RestartSelectMovement;
    }

    private void RestartSelectMovement()
    {
        selectMovementPanel.SetActive(true);
    }

    private void EnemySelected(string objName, Transform objTransform)
    {
        proceedButton.gameObject.SetActive(true);
    }

    void SelectMovement(string category)
    {
        selectMovementPanel.SetActive(false);
        selectEnemyPanel.SetActive(true);

        TurnBaseManager.Instance.SelectMovement(category);
        TurnBaseManager.Instance.SelectPreparation(true);
    }

    public void StartBattle()
    {
        selectMovementPanel.SetActive(true);
        selectEnemyPanel.SetActive(false);
    }

}
