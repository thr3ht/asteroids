using UnityEngine;

namespace _Project.Scripts.Player.Inputs
{
    public class InputDetector : MonoBehaviour
    {
        [SerializeField] private GameObject _virtualGamepad;

        private void Update()
        {
            DetectInput();
        }

        private void DetectInput()
        {
            bool isKeyboard = Input.anyKey;
            bool isTouch = Input.touchCount > 0;

            if (isKeyboard && !isTouch)
            {
                _virtualGamepad.SetActive(false);
            }
            else if (isTouch)
            {
                _virtualGamepad.SetActive(true);
            }
        }
    }
}