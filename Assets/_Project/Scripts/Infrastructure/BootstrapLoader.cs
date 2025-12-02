using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class BootstrapLoader : IInitializable
    {
        private readonly string _gameSceneName;

        [Inject]
        public BootstrapLoader([Inject(Id = "GameSceneName")] string gameSceneName)
        {
            _gameSceneName = gameSceneName;
        }

        public async void Initialize()
        {
            await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);

            SceneManager.LoadSceneAsync(_gameSceneName);
        }
    }
}