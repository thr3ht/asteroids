using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        private const string GAME_SCENE_ID = "GameSceneName";
        
        [SerializeField] private string _gameSceneName = "GameScene";

        public override void InstallBindings()
        {
            Container
                .Bind<string>()
                .WithId(GAME_SCENE_ID)
                .FromInstance(_gameSceneName)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BootstrapLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}