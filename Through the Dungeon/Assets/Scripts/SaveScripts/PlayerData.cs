using Player;

namespace SaveScripts
{
    [System.Serializable]
    public class PlayerData
    {
        public string levelName;
        public float health;
        public float[] position;

        public PlayerData(string levelName, PlayerController player)
        {
            this.levelName = levelName;
            health = player.GETPlayerHealth();
            position = new float[3];
            for (int i = 0;i < 3;i++){
                position[i] = player.GETPlayerTransform().position[i];
            }
        }
        
        
    }
}