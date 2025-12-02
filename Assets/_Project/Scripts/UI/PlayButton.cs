using _Project.Scripts.Core;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public class PlayButton : MonoBehaviour
    {
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void StartGame()
        {
            _signalBus.Fire<RestartGameSignal>();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}