using _Project.Scripts.Core;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
        
            Container.DeclareSignal<PlayerHitSignal>();
            Container.DeclareSignal<PlayerDiedSignal>();
        
            Container.DeclareSignal<AsteroidDiedSignal>();
            Container.DeclareSignal<ShipDiedSignal>();
        
            Container.DeclareSignal<RestartGameSignal>();

            Container.DeclareSignal<RewardedAdWatchedSignal>();
            Container.DeclareSignal<RewardedAdSkippedSignal>();
        }
    }
}