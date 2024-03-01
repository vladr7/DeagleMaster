using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f; 
    public GameObject deathSplatter;
    
    private ScoreManagerScript scoreManager;
    private TextManagerScript textManager;
    
    private Transform player; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
        textManager = GameObject.FindWithTag("TextManager").GetComponent<TextManagerScript>();
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy hit by bullet");
            scoreManager.AddEnemyKilled();
            textManager.UpdateEnemiesKilled(scoreManager.GetEnemiesKilled());

            GameObject splatterInstance = Instantiate(deathSplatter, transform.position, Quaternion.identity);
        
            Destroy(splatterInstance, 1f);
            Destroy(other.gameObject, 0.03f);
            Destroy(gameObject);
        }
    }


}