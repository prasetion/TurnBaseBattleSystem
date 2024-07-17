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

    [Header("Finish")]
    [SerializeField] GameObject finishPanel;
    [SerializeField] TMPro.TextMeshProUGUI finishText;
    [SerializeField] Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        TurnBaseManager.Instance.OnSelectEnemy += EnemySelected;
        TurnBaseManager.Instance.OnRestartSelectMovement += RestartSelectMovement;
        TurnBaseManager.Instance.OnWin += ShowResult;

        attackSelected.onClick.AddListener(() => SelectMovement("Attack"));
        skillSelected.onClick.AddListener(() => SelectMovement("Skill"));

        proceedButton.onClick.AddListener(() =>
        {
            TurnBaseManager.Instance.Proceed();
            proceedButton.gameObject.SetActive(false);
            selectEnemyPanel.SetActive(false);
        });

        restartButton.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        });

        selectMovementPanel.SetActive(false);
        selectEnemyPanel.SetActive(false);
        proceedButton.gameObject.SetActive(false);
        finishPanel.SetActive(false);


    }


    void OnDestroy()
    {
        TurnBaseManager.Instance.OnSelectEnemy -= EnemySelected;
        TurnBaseManager.Instance.OnRestartSelectMovement -= RestartSelectMovement;
        TurnBaseManager.Instance.OnWin -= ShowResult;
    }

    private void ShowResult(bool isWin)
    {
        finishText.text = isWin ? "You Win!" : "You Lose!";
        finishPanel.SetActive(true);
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
