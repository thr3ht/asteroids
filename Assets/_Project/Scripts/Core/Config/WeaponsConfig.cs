using Newtonsoft.Json;

namespace _Project.Scripts.Core.Config
{
    public class WeaponsConfig
    {
        [JsonProperty("bulletDamage")] public float BulletDamage { get; private set; }
        [JsonProperty("bulletSpeed")] public float BulletSpeed { get; private set; }
        [JsonProperty("bulletMaxLifeTime")] public float BulletMaxLifeTime { get; private set; }
        [JsonProperty("bulletCooldown")] public float BulletCooldown { get; private set; }
    
        [JsonProperty("laserDamage")] public float LaserDamage { get; private set; }
        [JsonProperty("laserMaxLifeTime")] public float LaserMaxLifeTime { get; private set; }
        [JsonProperty("laserWidth")] public float LaserWidth { get; private set; }
        [JsonProperty("laserLight")] public float LaserLight { get; private set; }
        [JsonProperty("laserMaxCharge")] public int LaserMaxCharge { get; private set; }
        [JsonProperty("laserCooldown")] public float LaserCooldown { get; private set; }
        [JsonProperty("laserReloadTime")] public float LaserReloadTime { get; private set; }
    }
}