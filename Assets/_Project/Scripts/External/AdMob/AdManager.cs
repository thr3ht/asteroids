using _Project.Scripts.Core;
using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.External.AdMob
{
    public class AdManager
    {
        private readonly string _rewardedUnitId = "ca-app-pub-3940256099942544/5224354917";

        private RewardedAd _rewardedAd;
        private SignalBus _signalBus;
        private bool _isRewardGranted;

        [Inject]
        public AdManager(SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            Initialize();
        }

        private void Initialize()
        {
            MobileAds.Initialize(initStatus =>
            {
                Debug.Log($"AdMob: initialized, {initStatus}");
            });

            LoadRewarded();
        }

        private void LoadRewarded()
        {
            var request = new AdRequest();

            RewardedAd.Load(_rewardedUnitId, request, (rewardedAd, error) =>
            {
                if (error != null)
                {
                    Debug.LogError($"AdMob: ERROR: {error}");
                    _rewardedAd = null;
                    return;
                }

                _rewardedAd = rewardedAd;
                _isRewardGranted = false;

                _rewardedAd.OnAdFullScreenContentClosed += OnAdClosed;
            });
        }

        private void OnAdClosed()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.OnAdFullScreenContentClosed -= OnAdClosed;
                _rewardedAd = null;
            }

            if (_isRewardGranted)
            {
                _signalBus.Fire<RewardedAdWatchedSignal>();
            }
            else
            {
                _signalBus.Fire<RewardedAdSkippedSignal>();
            }

            LoadRewarded();
        }

        public void ShowRewarded()
        {
            if (_rewardedAd == null)
            {
                Debug.Log("AdMob: Rewarded ad not loaded yet");
                _signalBus.Fire<RewardedAdSkippedSignal>();
                return;
            }

            _isRewardGranted = false;

            _rewardedAd.Show(reward =>
            {
                _isRewardGranted = true;
            });
        }
    }
}