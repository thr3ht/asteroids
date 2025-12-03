using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.External.Firebase
{
    public class FirebaseManager
    {
        private bool _isInitialized = false;
        
        public FirebaseManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            FirebaseApp.CheckAndFixDependenciesAsync()
                .ContinueWithOnMainThread(result =>
                {
                    if (result.Result == DependencyStatus.Available)
                    {
                        _isInitialized = true;
                        Debug.Log("Firebase: initialized");

                        LogEvent("app_launched");
                    }
                    else
                    {
                        _isInitialized = false;
                        Debug.Log($"Firebase: ERROR: {result.Result}");
                    }
                });
        }

        public void LogEvent(string eventName, string paramName, int paramValue)
        {
            if (!_isInitialized)
            {
                Debug.Log($"Firebase: ERROR: Firebase not initialized, {eventName} skipped");
                return;
            }

            FirebaseAnalytics.LogEvent(eventName, paramName, paramValue);
            Debug.Log($"Firebase: {eventName} sent");
        }
        
        public void LogEvent(string eventName)
        {
            if (!_isInitialized)
            {
                Debug.Log($"Firebase: ERROR: Firebase not initialized, {eventName} skipped");
                return;
            }

            FirebaseAnalytics.LogEvent(eventName);
            Debug.Log($"Firebase: {eventName} sent");
        }
    }
}