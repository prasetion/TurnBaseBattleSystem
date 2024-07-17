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

    // Start is called before the first frame update
    void Start()
    {
        attackSelected.onClick.AddListener(() => SelectMovement("Attack"));
        skillSelected.onClick.AddListener(() => SelectMovement("Skill"));

        selectMovementPanel.SetActive(false);
        selectEnemyPanel.SetActive(false);
    }

    void SelectMovement(string category)
    {
        selectMovementPanel.SetActive(false);
        selectEnemyPanel.SetActive(true);

        TurnBaseManager.Instance.SelectPreparation(true);
    }

    public void StartBattle()
    {
        selectMovementPanel.SetActive(true);
        selectEnemyPanel.SetActive(false);
    }

}
