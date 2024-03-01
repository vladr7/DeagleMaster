using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public float spawnInterval = 2.0f; // Time between each spawn

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        StartCoroutine(SpawnEnemyRoutine()); // Start the spawn routine
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true) // Infinite loop to keep spawning enemies
        {
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Calculate a random position within the camera's viewport
        Vector2 viewportPosition = new Vector2(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f));
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, mainCamera.nearClipPlane));

        // Instantiate the enemy at the calculated position
        // Note: You might need to adjust the Z position based on your camera setup and how your sprites are rendered.
        Instantiate(enemyPrefab, new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic here (if needed)
    }
}