using _Project.Scripts.Core.Config;
using _Project.Scripts.External.AdMob;
using _Project.Scripts.External.Firebase;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AdManager _adManagerPrefab;
        [SerializeField] private FirebaseManager _firebaseManagerPrefab;
        [SerializeField] private bool _showAds = false;
    
        public override void InstallBindings()
        {
            PlayerConfig playerConfig = LoadPlayerConfig();
            EnemyConfig enemyConfig = LoadEnemyConfig();
            WeaponsConfig weaponsConfig = LoadWeaponsConfig();
        
            Container
                .Bind<PlayerConfig>()
                .FromInstance(playerConfig)
                .AsSingle();
        
            Container
                .Bind<EnemyConfig>()
                .FromInstance(enemyConfig)
                .AsSingle();
        
            Container
                .Bind<WeaponsConfig>()
                .FromInstance(weaponsConfig)
                .AsSingle();
        
            Container
                .Bind<AdManager>()
                .FromComponentInNewPrefab(_adManagerPrefab)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<AdSettings>()
                .AsSingle()
                .WithArguments(_showAds);
        
            Container
                .Bind<FirebaseManager>()
                .FromComponentInNewPrefab(_firebaseManagerPrefab)
                .AsSingle()
                .NonLazy();
        }
    
        private PlayerConfig LoadPlayerConfig()
        {
            TextAsset configFile = Resources.Load<TextAsset>("Configs/PlayerConfig");

            return JsonConvert.DeserializeObject<PlayerConfig>(configFile.text);
        }
    
        private EnemyConfig LoadEnemyConfig()
        {
            TextAsset configFile = Resources.Load<TextAsset>("Configs/EnemyConfig");

            return JsonConvert.DeserializeObject<EnemyConfig>(configFile.text);
        }
    
        private WeaponsConfig LoadWeaponsConfig()
        {
            TextAsset configFile = Resources.Load<TextAsset>("Configs/WeaponsConfig");

            return JsonConvert.DeserializeObject<WeaponsConfig>(configFile.text);
        }
    }
}