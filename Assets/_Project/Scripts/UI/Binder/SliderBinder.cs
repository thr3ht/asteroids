using System;
using MVVM;
using UniRx;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Binder
{
    public sealed class SliderBinder : IBinder, IObserver<float>
    {
        private readonly Slider _view;
        private readonly IReadOnlyReactiveProperty<float> _property;
        private IDisposable _handle;
        private IObserver<float> _observerImplementation;

        public SliderBinder(Slider view, IReadOnlyReactiveProperty<float> property)
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

        public void OnNext(float value)
        {
            _view.value = value;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
    }
}