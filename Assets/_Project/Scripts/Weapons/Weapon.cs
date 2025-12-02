namespace _Project.Scripts.Weapons
{
    public abstract class Weapon
    {
        public abstract void Fire();

        public virtual void Update(float deltaTime)
        {
        }
    }
}