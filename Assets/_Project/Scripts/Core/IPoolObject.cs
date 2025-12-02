using UnityEngine;

namespace _Project.Scripts.Core
{
    public interface IPoolObject
    {
        void Activate(Vector2 position, Vector2 direction);
        void Deactivate();
    }
}