using UnityEngine;

namespace _Project.Scripts.Core.StateMachine
{
    public abstract class Transition : MonoBehaviour
    {
        [SerializeField] private State _targetState;

        public State TargetState => _targetState;

        public bool NeedTransit { get; protected set; }

        public void ResetTransit()
        {
            NeedTransit = false;
        }
    }
}