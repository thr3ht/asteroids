using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class BootstrapLoader : IInitializable
    {
        private const string GAME_SCENE_ID = "GameSceneName";
        
        private readonly string _gameSceneName;

        [Inject]
        public BootstrapLoader([Inject(Id = GAME_SCENE_ID)] string gameSceneName)
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