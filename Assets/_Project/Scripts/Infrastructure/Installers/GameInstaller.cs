using _Project.Scripts.Core;
using _Project.Scripts.Core.Physics;
using _Project.Scripts.Game;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<WorldBounds>()
                .AsSingle();
        
            Container
                .Bind<Repulsion>()
                .FromInstance(new Repulsion(30f))
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<UIService>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<Score>()
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInterfacesAndSelfTo<GameResetService>()
                .AsSingle()
                .NonLazy();
        }
    }
}