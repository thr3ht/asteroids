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
        private const string PLAYER_CONFIG_PATH = "Configs/PlayerConfig";
        private const string ENEMY_CONFIG_PATH = "Configs/EnemyConfig";
        private const string WEAPONS_CONFIG_PATH = "Configs/WeaponsConfig";
        
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
                .AsSingle()
                .NonLazy();

            Container
                .Bind<AdSettings>()
                .AsSingle()
                .WithArguments(_showAds);
        
            Container
                .Bind<FirebaseManager>()
                .AsSingle()
                .NonLazy();
        }
    
        private PlayerConfig LoadPlayerConfig()
        {
            TextAsset configFile = Resources.Load<TextAsset>(PLAYER_CONFIG_PATH);

            return JsonConvert.DeserializeObject<PlayerConfig>(configFile.text);
        }
    
        private EnemyConfig LoadEnemyConfig()
        {
            TextAsset configFile = Resources.Load<TextAsset>(ENEMY_CONFIG_PATH);

            return JsonConvert.DeserializeObject<EnemyConfig>(configFile.text);
        }
    
        private WeaponsConfig LoadWeaponsConfig()
        {
            TextAsset configFile = Resources.Load<TextAsset>(WEAPONS_CONFIG_PATH);

            return JsonConvert.DeserializeObject<WeaponsConfig>(configFile.text);
        }
    }
}