using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using _Project.Scripts.Core.Physics;
using _Project.Scripts.Enemies.Asteroid;
using _Project.Scripts.Enemies.Ship;
using _Project.Scripts.Weapons;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Game
{
    public class Collisions : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosionPrefab;

        private WeaponsConfig _config;
        private Repulsion _repulsion;
        private SignalBus _signalBus;
        private Player.Player _myPlayer;
        private Bullet _myBullet;
        private Laser _myLaser;

        [Inject]
        public void Construct(WeaponsConfig config, Repulsion repulsion, SignalBus signalBus)
        {
            _config = config;
            _repulsion = repulsion;
            _signalBus = signalBus;
        }

        private void Awake()
        {
            _myPlayer = GetComponent<Player.Player>();
            _myBullet = GetComponent<Bullet>();
            _myLaser = GetComponent<Laser>();
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject otherObject = other.gameObject;

            Asteroid otherAsteroid = otherObject.GetComponent<Asteroid>();
            AsteroidFragment otherAsteroidFragment = otherObject.GetComponent<AsteroidFragment>();
            Ship otherShip = otherObject.GetComponent<Ship>();

            ResolveCollision(otherAsteroid, otherAsteroidFragment, otherShip);

            if (_explosionPrefab != null)
            {
                HandleExplosion(transform.position);
            }
        }

        private void ResolveCollision(Asteroid otherAsteroid, AsteroidFragment otherAsteroidFragment, Ship otherShip)
        {
            if (_myPlayer != null)
            {
                if (otherAsteroid != null)
                {
                    HandlePlayerAsteroid(_myPlayer, otherAsteroid);
                }

                if (otherAsteroidFragment != null)
                {
                    HandlePlayerAsteroidFragment(_myPlayer, otherAsteroidFragment);
                }

                if (otherShip != null)
                {
                    HandlePlayerShip(_myPlayer, otherShip);
                }
            }

            else if (_myBullet != null)
            {
                if (otherAsteroid != null)
                {
                    HandleBulletAsteroid(_myBullet, otherAsteroid);
                }

                if (otherAsteroidFragment != null)
                {
                    HandleBulletAsteroidFragment(_myBullet, otherAsteroidFragment);
                }

                if (otherShip != null)
                {
                    HandleBulletShip(_myBullet, otherShip);
                }
            }

            else if (_myLaser != null)
            {
                if (otherAsteroid != null)
                {
                    HandleLaserAsteroid(_myLaser, otherAsteroid);
                }

                if (otherAsteroidFragment != null)
                {
                    HandleLaserAsteroidFragment(_myLaser, otherAsteroidFragment);
                }

                if (otherShip != null)
                {
                    HandleLaserShip(_myLaser, otherShip);
                }
            }
        }

        private void HandlePlayerAsteroid(Player.Player player, Asteroid asteroid)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 asteroidPosition = asteroid.transform.position;

            _repulsion.ApplyRepulsion(player.GetPhysicsBody(), playerPosition, asteroid.GetPhysicsBody(), asteroidPosition);

            _signalBus.Fire<PlayerHitSignal>();
        }

        private void HandlePlayerAsteroidFragment(Player.Player player, AsteroidFragment asteroidFragment)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 asteroidFragmentPosition = asteroidFragment.transform.position;

            _repulsion.ApplyRepulsion(player.GetPhysicsBody(), playerPosition, asteroidFragment.GetPhysicsBody(),
                asteroidFragmentPosition);

            _signalBus.Fire<PlayerHitSignal>();
        }

        private void HandlePlayerShip(Player.Player player, Ship ship)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 shipPosition = ship.transform.position;

            _repulsion.ApplyRepulsion(player.GetPhysicsBody(), playerPosition, ship.GetPhysicsBody(), shipPosition);
            ship.SetRepulsionCooldown(3f);

            _signalBus.Fire<PlayerHitSignal>();
        }

        private void HandleBulletAsteroid(Bullet bullet, Asteroid asteroid)
        {
            bullet.Deactivate();
            asteroid.TakeDamage(_config.BulletDamage);
        }

        private void HandleBulletAsteroidFragment(Bullet bullet, AsteroidFragment asteroidFragment)
        {
            bullet.Deactivate();
            asteroidFragment.TakeDamage(_config.BulletDamage);
        }

        private void HandleBulletShip(Bullet bullet, Ship ship)
        {
            bullet.Deactivate();
            ship.TakeDamage(_config.BulletDamage);
        }

        private void HandleLaserShip(Laser laser, Ship ship)
        {
            ship.TakeDamage(_config.LaserDamage);
        }

        private void HandleLaserAsteroid(Laser laser, Asteroid asteroid)
        {
            asteroid.TakeDamage(_config.LaserDamage);
        }

        private void HandleLaserAsteroidFragment(Laser laser, AsteroidFragment asteroidFragment)
        {
            asteroidFragment.TakeDamage(_config.LaserDamage);
        }

        private void HandleExplosion(Vector2 position)
        {
            ParticleSystem explosion = Instantiate(_explosionPrefab, position, Quaternion.identity);
            explosion.Play();

            Destroy(explosion.gameObject, 1f);
        }
    }
}