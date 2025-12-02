using Newtonsoft.Json;

namespace _Project.Scripts.Core.Config
{
    public class EnemyConfig
    {
        [JsonProperty("asteroidHealth")] public int AsteroidHealth { get; private set; }
        [JsonProperty("asteroidSpeed")] public float AsteroidSpeed { get; private set; }
        [JsonProperty("asteroidRotationSpeed")] public float AsteroidRotationSpeed { get; private set; }
        [JsonProperty("asteroidSpawnInterval")] public float AsteroidSpawnInterval { get; private set; }
        [JsonProperty("asteroidInitialCount")] public int AsteroidInitialCount { get; private set; }
        [JsonProperty("asteroidMaxCount")] public int AsteroidMaxCount { get; private set; }
        [JsonProperty("asteroidFragmentSpeed")] public float AsteroidFragmentSpeed { get; private set; }
        [JsonProperty("asteroidScore")] public int AsteroidScore { get; private set; }
    
        [JsonProperty("shipHealth")] public int ShipHealth { get; private set; }
        [JsonProperty("shipSpeed")] public float ShipSpeed { get; private set; }
        [JsonProperty("shipRotationSpeed")] public float ShipRotationSpeed { get; private set; }
        [JsonProperty("shipSpawnInterval")] public float ShipSpawnInterval { get; private set; }
        [JsonProperty("shipMaxCount")] public int ShipMaxCount { get; private set; }
        [JsonProperty("shipScore")] public int ShipScore { get; private set; }
    }
}