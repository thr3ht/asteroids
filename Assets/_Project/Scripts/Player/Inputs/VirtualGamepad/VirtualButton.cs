using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Player.Inputs.VirtualGamepad
{
    public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isPressed;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }

        public bool GetKey()
        {
            return _isPressed;
        }
    }
}