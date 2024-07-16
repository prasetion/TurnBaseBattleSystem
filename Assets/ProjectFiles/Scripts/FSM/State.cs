using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prasetion
{

    public abstract class State : MonoBehaviour
    {
        public bool isComplete { get; protected set; }
        float startTime;

        float time => Time.time - startTime;

        public virtual void Enter()
        {

        }

        public virtual void Do()
        {

        }

        public virtual void FixedDo()
        {

        }

        public virtual void Exit()
        {

        }
    }
}
