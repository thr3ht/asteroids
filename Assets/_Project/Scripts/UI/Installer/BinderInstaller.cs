using _Project.Scripts.UI.Binder;
using MVVM;
using Zenject;

namespace _Project.Scripts.UI.Installer
{
    public sealed class BinderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BinderFactory.RegisterBinder<TextBinder>();
            BinderFactory.RegisterBinder<SliderBinder>();
            BinderFactory.RegisterBinder<ArrayBinder>();
            BinderFactory.RegisterBinder<VisibleBinder>();
        }
    }
}