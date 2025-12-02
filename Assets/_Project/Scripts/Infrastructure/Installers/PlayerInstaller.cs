using _Project.Scripts.Core.Physics;
using _Project.Scripts.Player;
using _Project.Scripts.Player.Inputs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<KeyboardPlayerInput>()
                .AsSingle();
        
            Container
                .Bind<VirtualGamepadInput>()
                .FromComponentInHierarchy()
                .AsSingle();
        
            Container
                .Bind<IPlayerInput>()
                .To<PlayerInput>()
                .AsSingle();

            Container
                .Bind<Player.Player>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<PlayerHealth>()
                .AsSingle();

            Container
                .Bind<PhysicsBody>()
                .AsSingle()
                .WithArguments(Vector2.zero);

            Container
                .Bind<PlayerMovement>()
                .AsSingle();

            Container
                .Bind<PlayerShooting>()
                .AsSingle();

            Container
                .Bind<PlayerUpdater>()
                .AsSingle();

            Container
                .Bind<PlayerShield>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlayerFacade>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<AdRewardHandler>()
                .AsSingle();
        }
    }
}