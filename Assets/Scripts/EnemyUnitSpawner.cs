using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitSpawner : MonoBehaviour
{
    const float SPAWN_INTERVAL = 2f;
    const float EPS = 0.3f;
    public GameObject[] enemyUnitPrefabs = new GameObject[3];
    public float durationTime = SPAWN_INTERVAL;
    // Update is called once per frame
    void Update()
    {
        SpawnEnemyUnitWhenEnemyUnitIsDead();
    }

    public void SpawnEnemyUnit(int enemyCount){

        for(int i=0;i<enemyCount;i++){
            Vector2 spawnPosition = new Vector2(Random.Range(-3f, 7f), Random.Range(-3f, 3f));
            Instantiate(enemyUnitPrefabs[returnIdx()], spawnPosition, Quaternion.identity);
        }
        Debug.Log("Spawn enemy unit");
    }

    int returnIdx(){
        float prop = Random.Range(0f,1f);
        int idx = 0;
        if(EPS > prop){
            idx = 1;
            if(0.5f > Random.Range(0f,1f)){
                idx = 2;
            }
        }
        return idx;
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
