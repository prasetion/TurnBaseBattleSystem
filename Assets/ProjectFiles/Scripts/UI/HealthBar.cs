using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] Transform canvasTarget;
    [SerializeField] Vector3 offset;

    [Header("UI Ref")]
    [SerializeField] Image healthUI;

    Camera mainCam;
    ICharacterInfo characterInfo;
    float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        characterInfo = GetComponent<ICharacterInfo>();
        TurnBaseManager.Instance.OnGetHit += GetHit;
        maxHealth = characterInfo.GetHealth();
    }

    void OnDestroy()
    {
        TurnBaseManager.Instance.OnGetHit -= GetHit;
    }

    private void GetHit(string charName, float damage)
    {
        // throw new NotImplementedException();
        if (charName.Equals(characterInfo.GetName()))
        {
            float damageAmount = characterInfo.GetHealth() - damage;
            Debug.Log($"{charName} get damage {damage}, now there is still Amount {damageAmount}");
            characterInfo.SetHealth(damageAmount);
            healthUI.DOFillAmount(damageAmount / maxHealth, 0.3f);

            if (characterInfo.GetHealth() <= 0)
                gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the screen position of the player
        Vector3 screenPosition = mainCam.WorldToScreenPoint(transform.position + offset);

        canvasTarget.position = screenPosition;
    }
}
