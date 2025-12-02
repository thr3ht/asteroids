using _Project.Scripts.UI.ViewModel;
using Zenject;

namespace _Project.Scripts.UI.Installer
{
    public sealed class ViewModelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerSpeedViewModel>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<PlayerAngleViewModel>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<PlayerPositionViewModel>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<LaserReloadViewModel>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<PlayerHealthViewModel>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<ScoreViewModel>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<LaserChargeViewModel>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<MenuViewModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}