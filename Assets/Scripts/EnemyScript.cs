using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public ParticleSystem enemyDeathVFX;
    public Transform enemyDeathVFXPosition;
    
    private ScoreManagerScript scoreManager;
    private TextManagerScript textManager;
    
    private Transform player; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
        textManager = GameObject.FindWithTag("TextManager").GetComponent<TextManagerScript>();
        enemyDeathVFX = GameObject.FindWithTag("EnemyDeathVFX").GetComponent<ParticleSystem>();
        enemyDeathVFX.transform.position = enemyDeathVFXPosition.position;
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
            enemyDeathVFX.Play();

            Destroy(other.gameObject, 0.03f);
            Destroy(gameObject);
        }
    }


}