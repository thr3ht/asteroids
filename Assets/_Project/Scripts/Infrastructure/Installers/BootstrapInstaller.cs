using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private string _gameSceneName = "GameScene";

        public override void InstallBindings()
        {
            Container
                .Bind<string>()
                .WithId("GameSceneName")
                .FromInstance(_gameSceneName)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BootstrapLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}