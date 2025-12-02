using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Core.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions;

        public void Enter()
        {
            if (!enabled)
            {
                enabled = true;

                foreach (Transition transition in _transitions)
                {
                    transition.enabled = true;
                }
            }
        }

        public State GetNextState()
        {
            foreach (Transition transition in _transitions)
            {
                if (transition.NeedTransit)
                {
                    transition.ResetTransit();
                    return transition.TargetState;
                }
            }

            return null;
        }

        public void Exit()
        {
            if (enabled)
            {
                foreach (Transition transition in _transitions)
                {
                    transition.enabled = false;
                }

                enabled = false;
            }
        }
    }
}