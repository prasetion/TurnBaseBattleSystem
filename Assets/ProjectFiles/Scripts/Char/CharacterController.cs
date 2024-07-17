using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    ICharacterInfo characterInfo;
    CharacterAnimationController characterAnimationController;

    float speedMovement = 1;

    Vector3 startPosition;
    Vector3 startRotation;

    string targetHit;

    [SerializeField] GameObject particleSkill;
    [SerializeField] EPOOutline.Outlinable outlinable;

    // Start is called before the first frame update
    void Start()
    {
        characterInfo = GetComponent<ICharacterInfo>();
        characterAnimationController = GetComponent<CharacterAnimationController>();
        outlinable = GetComponent<EPOOutline.Outlinable>();

        TurnBaseManager.Instance.CharacterInformationList.Add(characterInfo);

        TurnBaseManager.Instance.OnMove += StartMovement;
        TurnBaseManager.Instance.OnGetHit += GetHit;

        startPosition = transform.position;
        startRotation = transform.eulerAngles;

        // TurnBaseManager.Instance.
    }

    private void GetHit(string targetHit, float amount)
    {
        if (targetHit.Equals(characterInfo.GetName()))
        {
            Debug.Log($"target {characterInfo.GetName()}");
            characterAnimationController.OnGetHit();
        }
    }

    void OnDestroy()
    {
    }

    void OnDisable()
    {
        TurnBaseManager.Instance.OnMove -= StartMovement;
    }

    private void StartMovement(string charName, bool isNormalAttack, Transform target)
    {
        if (charName != characterInfo.GetName())
            return;

        StartCoroutine(MovementRoutine(charName, isNormalAttack, target));
    }

    IEnumerator MovementRoutine(string charName, bool isNormalAttack, Transform target)
    {
        // indicate this character is moving
        outlinable.OutlineParameters.Color = Color.blue;
        outlinable.enabled = true;

        bool isFinishAttack = false;
        TurnBaseManager.Instance.CurrentDamage = characterInfo.GetAttack();

        if (!isNormalAttack)
        {
            if (particleSkill)
                particleSkill.SetActive(true);
        }
        else
        {
            if (particleSkill)
                particleSkill.SetActive(false);
        }

        characterAnimationController.OnMove(1);
        transform.DOMove(target.position, speedMovement).OnComplete(() =>
        {
            // attack anim
            characterAnimationController.OnAttack();

            // get hit anim
            TurnBaseManager.Instance.GetHit();

            isFinishAttack = true;
        });

        transform.DOLookAt(new Vector3(target.position.x, transform.position.y, target.position.z), speedMovement);

        while (!isFinishAttack)
            yield return null;

        yield return new WaitForSeconds(1f);
        if (particleSkill)
            particleSkill.SetActive(false);
        bool isFinishBack = false;
        characterAnimationController.OnMove(1);
        transform.DOMove(startPosition, speedMovement).OnComplete(() =>
        {
            transform.DORotate(startRotation, 0.3f);
            characterAnimationController.OnMove(0);
            isFinishBack = true;
        });

        transform.DOLookAt(new Vector3(startPosition.x, transform.position.y, startPosition.z), speedMovement);

        while (!isFinishBack)
            yield return null;

        yield return new WaitForSeconds(1f);
        outlinable.enabled = false;
        outlinable.OutlineParameters.Color = Color.yellow;
        TurnBaseManager.Instance.FinishMovement();
    }

}
