using UnityEngine;

namespace _Project.Scripts.Player.Inputs
{
    public class PlayerInput : IPlayerInput
    {
        private readonly KeyboardPlayerInput _keyboardInput;
        private readonly VirtualGamepadInput _virtualInput;

        public PlayerInput(
            KeyboardPlayerInput keyboardInput, 
            VirtualGamepadInput virtualInput)
        {
           _keyboardInput = keyboardInput;
           _virtualInput = virtualInput;
        }

        public float GetBoost()
        {
            return Mathf.Max(_keyboardInput.GetBoost(), _virtualInput.GetBoost());
        }

        public float GetRotation()
        {
            float sum = _keyboardInput.GetRotation() +  _virtualInput.GetRotation();
            return Mathf.Clamp(sum, -1f, 1f);
        }

        public bool IsPrimaryFire()
        {
            return _keyboardInput.IsPrimaryFire() || _virtualInput.IsPrimaryFire();
        }

        public bool IsSecondaryFire()
        {
            return _keyboardInput.IsSecondaryFire() || _virtualInput.IsSecondaryFire();
        }
    }
}