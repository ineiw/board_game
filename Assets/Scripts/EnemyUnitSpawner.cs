using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitSpawner : MonoBehaviour
{
    const float SPAWN_INTERVAL = 2f;
    public GameObject enemyUnitPrefab = null;
    public float durationTime = SPAWN_INTERVAL;
    // Update is called once per frame
    void Update()
    {
        SpawnEnemyUnitWhenEnemyUnitIsDead();
    }

    public void SpawnEnemyUnit(int enemyCount){
        for(int i=0;i<enemyCount;i++){
            Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
            Instantiate(enemyUnitPrefab, spawnPosition, Quaternion.identity);
        }
        Debug.Log("Spawn enemy unit");
    }

    public void SpawnEnemyUnitWhenEnemyUnitIsDead(){
        if(GameObject.FindGameObjectsWithTag("EnemyUnit").Length == 0){
            if(durationTime <= 0){
                SpawnEnemyUnit(3);
                durationTime = SPAWN_INTERVAL;
            }
            else{
                durationTime -= Time.deltaTime;
            }
        }
    }
}
