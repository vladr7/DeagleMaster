using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    private int _enemiesKilled = 0;
    
    public void AddEnemyKilled()
    {
        _enemiesKilled++;
    }
    
    public int GetEnemiesKilled()
    {
        return _enemiesKilled;
    }
}
