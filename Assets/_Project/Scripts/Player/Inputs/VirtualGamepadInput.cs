using _Project.Scripts.Player.Inputs.VirtualGamepad;
using UnityEngine;

namespace _Project.Scripts.Player.Inputs
{
    public class VirtualGamepadInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private VirtualButton _buttonBoost;
        [SerializeField] private VirtualButton _buttonLeft;
        [SerializeField] private VirtualButton _buttonRight;
        [SerializeField] private VirtualButton _buttonPrimary;
        [SerializeField] private VirtualButton _buttonSecondary;

        public float GetBoost()
        {
            float boost = 0f;

            if (_buttonBoost.GetKey())
            {
                boost += 1f;
            }

            return Mathf.Clamp(boost, -1f, 1f);
        }

        public float GetRotation()
        {
            float rotation = 0f;

            if (_buttonLeft.GetKey())
            {
                rotation += 1f;
            }

            if (_buttonRight.GetKey())
            {
                rotation -= 1f;
            }

            return Mathf.Clamp(rotation, -1f, 1f);
        }

        public bool IsPrimaryFire()
        {
            return _buttonPrimary.GetKey();
        }

        public bool IsSecondaryFire()
        {
            return _buttonSecondary.GetKey();
        }
    }
}