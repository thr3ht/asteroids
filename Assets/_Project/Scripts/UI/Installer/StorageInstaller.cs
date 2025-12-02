using _Project.Scripts.UI.Storage;
using Zenject;

namespace _Project.Scripts.UI.Installer
{
    public sealed class StorageInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerSpeedStorage>()
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<PlayerAngleStorage>()
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<PlayerPositionStorage>()
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<LaserReloadStorage>()
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<PlayerHealthStorage>()
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<ScoreStorage>()
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<LaserChargeStorage>()
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<MenuStorage>()
                .AsSingle()
                .NonLazy();
        }
    }
}