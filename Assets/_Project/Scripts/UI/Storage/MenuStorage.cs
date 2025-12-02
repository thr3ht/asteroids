using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class MenuStorage
    {
        public event Action<bool> OnMenuVisibleChanged;

        public bool IsVisible { get; private set; }

        public void SetMenuVisible(bool isVisible)
        {
            IsVisible = isVisible;
            OnMenuVisibleChanged?.Invoke(IsVisible);
        }
    }
}