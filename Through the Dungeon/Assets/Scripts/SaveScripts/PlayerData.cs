using Player;

namespace SaveScripts
{
    [System.Serializable]
    public class PlayerData
    {
        public string levelPath;
        public float health;
        public float fireCooldown;
        public float fireDamage;
        public float windCooldown;
        public float windDamage;
        public float earthCooldown;
        public float earthDamageReduction;
        public float waterCooldown;
        public float waterHealingAmount;

        public PlayerData(string levelPath, PlayerController player)
        {
            this.levelPath = levelPath;
            health = player.GETPlayerHealth();
            fireCooldown = player.getFireCooldown();
            fireDamage = player.getFireDamage();
            windCooldown = player.getWindCooldown();
            windDamage = player.getWindDamage();
            earthCooldown = player.getEarthCooldown();
            earthDamageReduction = player.getEarthDamageReduction();
            waterCooldown = player.getWaterCooldown();
            waterHealingAmount = player.getWaterHealingAmount();
        }
        
        
    }
}