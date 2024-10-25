using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{

    [SerializeField] GameObject Enemy;
    [SerializeField] Camera cam;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] float spawnDis = 10f;
    Vector2 screenBound;
    Vector2 spawnPos;
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void spawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenBound = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-screenBound.x, screenBound.x), screenBound.y+ spawnDis);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenBound.x, screenBound.x), -screenBound.y - spawnDis);
                break;
            case 2:
                spawnPos = new Vector2(screenBound.x + spawnDis, Random.Range(-screenBound.y, screenBound.y));
                break;
            case 3:
                spawnPos = new Vector2(-screenBound.x - spawnDis, Random.Range(-screenBound.y, screenBound.y));
                break;

        }
        Instantiate(Enemy, spawnPos, transform.rotation);
        Invoke("spawnEnemy", spawnTime);
    }
}
