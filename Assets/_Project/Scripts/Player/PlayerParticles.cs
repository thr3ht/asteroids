using _Project.Scripts.Player.Inputs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player
{
    public class PlayerParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _rightEngineParticles;
        [SerializeField] private ParticleSystem _leftEngineParticles;
        [SerializeField] private ParticleSystem _mainEngineParticles;
        [SerializeField] private ParticleSystem _shieldParticles;

        private IPlayerInput _input;

        [Inject]
        public void Construct(IPlayerInput input)
        {
            _input = input;
        }
    
        private void Update()
        {
            if (_input.GetBoost() > 0f)
            {
                _mainEngineParticles.Play();
            }
            else
            {
                _mainEngineParticles.Pause();
                _mainEngineParticles.Clear();
            }

            float rotation = _input.GetRotation();
        
            if (rotation > 0.01f)
            {
                _rightEngineParticles.Play();
            }
            else
            {
                _rightEngineParticles.Pause();
                _rightEngineParticles.Clear();
            }

            if (rotation < -0.01f)
            {
                _leftEngineParticles.Play();
            }
            else
            {
                _leftEngineParticles.Pause();
                _leftEngineParticles.Clear();
            }
        }

        public void ActivateShield()
        {
            _shieldParticles.Play();
        }

        public void DeactivateShield()
        {
            _shieldParticles.Stop();
            _shieldParticles.Clear();
        }
    }
}