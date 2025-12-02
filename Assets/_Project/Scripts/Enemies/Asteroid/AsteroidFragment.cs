using _Project.Scripts.Core;
using _Project.Scripts.Core.Physics;

namespace _Project.Scripts.Enemies.Asteroid
{
    public class AsteroidFragment : AsteroidBase
    {
        protected override float GetSpeed()
        {
            return _config.AsteroidFragmentSpeed;
        }
    
        protected override void HandleDeath()
        {
            _signalBus.Fire(new AsteroidDiedSignal(_config.AsteroidScore));
            Deactivate();
        }

        public PhysicsBody GetPhysicsBody()
        {
            return _movement.Body;
        }
    }
}