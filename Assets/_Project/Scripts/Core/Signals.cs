namespace _Project.Scripts.Core
{
    public sealed class AsteroidDiedSignal
    {
        public int Score { get; }

        public AsteroidDiedSignal(int score)
        {
            Score = score;
        }
    }

    public sealed class ShipDiedSignal
    {
        public int Score { get; }

        public ShipDiedSignal(int score)
        {
            Score = score;
        }
    }

    public sealed class PlayerHitSignal
    {
    }

    public sealed class PlayerDiedSignal
    {
    }

    public sealed class RestartGameSignal
    {
    }

    public sealed class RewardedAdWatchedSignal
    {
    }

    public sealed class RewardedAdSkippedSignal
    {
    }
}