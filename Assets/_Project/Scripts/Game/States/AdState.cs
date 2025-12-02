using _Project.Scripts.Core.StateMachine;
using _Project.Scripts.External.AdMob;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Game.States
{
    public class AdState : State
    {
        private AdManager _adManager;

        [Inject]
        public void Construct(AdManager adManager)
        {
            _adManager = adManager;
        }

        private async void OnEnable()
        {
            Time.timeScale = 0f;
            
            await UniTask.NextFrame();
            
            _adManager.ShowRewarded();
        }
    }
}