using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInfo : BaseCharacter
{
    void Start()
    {
        TurnBaseManager.Instance.currentHero = transform;
    }
}
