using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator playerAnimator;
    const string ATTACK = "Attack";
    const string MOVEMENT = "Movement";

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void OnAttack()
    {
        playerAnimator.SetTrigger(ATTACK);
    }

    public void OnMove(float moveValue)
    {
        playerAnimator.SetFloat(MOVEMENT, moveValue);
    }

}
