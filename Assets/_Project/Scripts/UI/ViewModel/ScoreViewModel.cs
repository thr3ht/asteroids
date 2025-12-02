using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class ScoreViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("Score")] public readonly ReactiveProperty<string> Score = new();

        private readonly ScoreStorage _scoreStorage;

        public ScoreViewModel(ScoreStorage scoreStorage)
        {
            _scoreStorage = scoreStorage;
        }

        public void Initialize()
        {
            OnScoreChanged(_scoreStorage.Score);
            _scoreStorage.OnScoreChanged += OnScoreChanged;
        }

        public void Dispose()
        {
            _scoreStorage.OnScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            Score.Value = "Score: " + score;
        }
    }
}