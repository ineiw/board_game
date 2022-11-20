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

    public void SpawnEnemyUnit(){
        GameObject newEnemyUnit = Instantiate(enemyUnitPrefab, transform.position, Quaternion.identity);
        Debug.Log("Spawn enemy unit");
    }

    public void SpawnEnemyUnitWhenEnemyUnitIsDead(){
        if(GameObject.FindGameObjectsWithTag("EnemyUnit").Length == 0){
            if(durationTime <= 0){
                SpawnEnemyUnit();
                durationTime = SPAWN_INTERVAL;
            }
            else{
                durationTime -= Time.deltaTime;
            }
        }
    }
}
