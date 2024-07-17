using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    Animator playerAnimator;
    const string ATTACK = "Attack";
    const string MOVEMENT = "Movement";
    const string HIT = "GetHit";

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void OnAttack()
    {
        playerAnimator.SetTrigger(ATTACK);
        OnMove(0);
    }

    public void OnMove(float moveValue)
    {
        playerAnimator.SetFloat(MOVEMENT, moveValue);
    }


    public void OnGetHit()
    {
        playerAnimator.SetTrigger(HIT);
    }

}
