namespace _Project.Scripts.Player.Inputs
{
    public interface IPlayerInput
    {
        float GetBoost();
        float GetRotation();
        bool IsPrimaryFire();
        bool IsSecondaryFire();
    }
}
