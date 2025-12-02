using System;
using MVVM;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.UI.Binder
{
    public sealed class VisibleBinder : IBinder, IObserver<bool>
    {
        private readonly GameObject _view;
        private readonly IReadOnlyReactiveProperty<bool> _property;
        private IDisposable _handle;

        public VisibleBinder(GameObject view, IReadOnlyReactiveProperty<bool> property)
        {
            _view = view;
            _property = property;
        }

        public void Bind()
        {
            OnNext(_property.Value);
            _handle = _property.Subscribe(this);
        }

        public void Unbind()
        {
            _handle?.Dispose();
            _handle = null;
        }

        public void OnNext(bool value)
        {
            _view.SetActive(value);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
    }
}