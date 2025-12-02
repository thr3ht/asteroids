using _Project.Scripts.Core;
using _Project.Scripts.Core.Physics;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        private SignalBus _signalBus;
        private PlayerFacade _facade;
    
        public PhysicsBody GetPhysicsBody() => _facade.GetPhysicsBody();

        [Inject]
        private void Construct(
            SignalBus signalBus,
            PlayerFacade facade)
        {
            _signalBus = signalBus;
            _facade = facade;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerHitSignal>(OnPlayerHit);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerHitSignal>(OnPlayerHit);
        }

        private void Update()
        {
            _facade.Update(Time.deltaTime);
        }

        private void OnPlayerHit()
        {
            _facade.OnHit();
        }
    }
}