using _Project.Scripts.Core;
using Zenject;

namespace _Project.Scripts.Enemies.Ship
{
    public class ShipFactory : _Project.Scripts.Core.Factory<global::_Project.Scripts.Enemies.Ship.Ship>
    {
        public ShipFactory(DiContainer container, global::_Project.Scripts.Enemies.Ship.Ship prefab, ObjectPool<global::_Project.Scripts.Enemies.Ship.Ship> objectPool) : base(container,
            prefab, objectPool)
        {
        }
    }
}