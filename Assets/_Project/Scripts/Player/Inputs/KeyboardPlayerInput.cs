using UnityEngine;

namespace _Project.Scripts.Player.Inputs
{
    public class KeyboardPlayerInput : IPlayerInput
    {
        public float GetBoost()
        {
            float boost = 0f;

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                boost += 1f;
            }

            return Mathf.Clamp(boost, -1f, 1f);
        }

        public float GetRotation()
        {
            float rotation = 0f;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rotation += 1f;
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rotation -= 1f;
            }

            return Mathf.Clamp(rotation, -1f, 1f);
        }

        public bool IsPrimaryFire() => Input.GetKey(KeyCode.Q);

        public bool IsSecondaryFire() => Input.GetKey(KeyCode.E);
    }
}