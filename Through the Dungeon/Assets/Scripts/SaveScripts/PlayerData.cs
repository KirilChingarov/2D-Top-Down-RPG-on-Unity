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

        public string[] levels;
        public int nextLevel;

        public PlayerData(string levelPath, PlayerController player, GameStateController gameStateController)
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
            
            levels = new string[gameStateController.levels.Length];
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = gameStateController.levels[i];
            }
            nextLevel = gameStateController.nextLevel;
        }
    }
}