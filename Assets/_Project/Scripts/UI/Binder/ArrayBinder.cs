using System;
using MVVM;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.UI.Binder
{
    public sealed class ArrayBinder : IBinder, IObserver<int>
    {

        private readonly GameObject[] _view;
        private readonly IReadOnlyReactiveProperty<int> _property;
        private IDisposable _handle;

        public ArrayBinder(GameObject[] view, IReadOnlyReactiveProperty<int> property)
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

        public void OnNext(int value)
        {
            for (int i = 0; i < _view.Length; i++)
            {
                _view[i].SetActive(i < value);
            }
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
    }
}