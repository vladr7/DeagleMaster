using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManagerScript : MonoBehaviour
{
    public TextMeshProUGUI enemiesKilledText;
    
    public void UpdateEnemiesKilled(int enemiesKilled)
    {
        enemiesKilledText.text = enemiesKilled.ToString();
    }
}
