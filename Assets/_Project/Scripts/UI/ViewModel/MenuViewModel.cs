using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class MenuViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("IsVisible")] public readonly ReactiveProperty<bool> IsVisible = new();
    
        private readonly MenuStorage _menuStorage;

        public MenuViewModel(MenuStorage menuStorage)
        {
            _menuStorage = menuStorage;
        }

        public void Initialize()
        {
            _menuStorage.OnMenuVisibleChanged += OnMenuVisibleChanged;
        }

        public void Dispose()
        {
            _menuStorage.OnMenuVisibleChanged -= OnMenuVisibleChanged;
        }

        private void OnMenuVisibleChanged(bool isVisible)
        {
            IsVisible.Value = isVisible;
        }
    }
}