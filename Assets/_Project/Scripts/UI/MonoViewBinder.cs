using System;
using System.Linq;
using MVVM;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public sealed class MonoViewBinder : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _view;
        [SerializeField] private string _viewModelTypeName;

        [Inject] private DiContainer _container;
        private IBinder _binder;

        private void Awake()
        {
            if (_view == null)
            {
                Debug.LogError($"[MonoViewBinder] View is null on {gameObject.name}");
                return;
            }

            if (string.IsNullOrEmpty(_viewModelTypeName))
            {
                Debug.LogError($"[MonoViewBinder] ViewModel type name is empty on {gameObject.name}");
                return;
            }

            Type viewModelType = GetTypeByName(_viewModelTypeName);
            if (viewModelType == null)
            {
                Debug.LogError($"[MonoViewBinder] ViewModel type '{_viewModelTypeName}' not found on {gameObject.name}");
                return;
            }

            object viewModel = _container.Resolve(viewModelType);
            _binder = BinderFactory.CreateComposite(_view, viewModel);
        }

        private void OnEnable()
        {
            _binder?.Bind();
        }

        private void OnDisable()
        {
            _binder?.Unbind();
        }

        private static Type GetTypeByName(string typeName)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .FirstOrDefault(type => type.Name == typeName);
        }
    }
}