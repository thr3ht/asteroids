using Newtonsoft.Json;

namespace _Project.Scripts.Core.Config
{
    public class PlayerConfig
    {
        [JsonProperty("health")] public int Health { get; private set; }
        [JsonProperty("maxSpeed")] public float MaxSpeed { get; private set; }
        [JsonProperty("acceleration")] public float Acceleration { get; private set; }
        [JsonProperty("rotationSpeed")] public float RotationSpeed { get; private set; }
        [JsonProperty("shieldDuration")] public float ShieldDuration { get; private set; }
    }
}