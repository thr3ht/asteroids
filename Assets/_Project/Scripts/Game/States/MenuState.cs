using _Project.Scripts.Core.StateMachine;
using _Project.Scripts.UI.Storage;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Game.States
{
    public class MenuState : State
    {
        private MenuStorage _menuStorage;

        [Inject]
        public void Construct(MenuStorage menuStorage)
        {
            _menuStorage = menuStorage;
        }

        private void OnEnable()
        {
            Time.timeScale = 0;

            _menuStorage.SetMenuVisible(true);
        }
    }
}