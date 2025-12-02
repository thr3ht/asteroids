using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class ScoreStorage
    {
        public event Action<int> OnScoreChanged;

        public int Score { get; private set; }

        public void SetScore(int score)
        {
            Score = score;
            OnScoreChanged?.Invoke(Score);
        }
    }
}