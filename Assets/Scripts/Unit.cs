using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    const float EPS = 0.3f;
    public GameObject[] cardPrefabs = new GameObject[3];
    // unit preferences
    protected float power = 40f;
    protected Rigidbody2D rigidbody;
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float attack = 10;
    public float defense = 10;
    public float speed = 1;
    public float range = 1;
    
    protected List<Transform> GetEnemyUnitsList(){
        string enemyTag = "";
        if(gameObject.tag == "PlayerUnit")
            enemyTag = "EnemyUnit";
        else
            enemyTag = "PlayerUnit";
        
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag(enemyTag);
        List<Transform> enemyList = new List<Transform>();
        foreach (GameObject enemy in enemyArray)
        {
            enemyList.Add(enemy.transform);
        }
        return enemyList;
    }
    protected Vector2 GetNeariestTargetPosition(List<Transform> targets){
        Vector2 neariestTarget = Vector2.zero;
        float neariestDistance = 10000;
        foreach(Transform target in targets){
            float distance = Vector2.Distance(transform.position, target.position);
            if(distance < neariestDistance){
                neariestDistance = distance;
                neariestTarget = target.position;
            }
        }
        return neariestTarget;
    }

    protected GameObject GetNeariestTarget(List<Transform> targets){
        GameObject neariestTarget = null;
        float neariestDistance = 10000;
        foreach(Transform target in targets){
            float distance = Vector2.Distance(transform.position, target.position);
            if(distance < neariestDistance){
                neariestDistance = distance;
                neariestTarget = target.gameObject;
            }
        }
        return neariestTarget;
    }
    protected Vector2 GetTargetDir(Vector2 targetPosition){
        Vector2 targetDir = targetPosition - (Vector2)transform.position;
        return targetDir.normalized;
    }

    protected void Move(Vector2 targetDir){
        //move to target using dir
        rigidbody.AddForce(targetDir * speed * power);
    }

    protected void Attack(Unit target){
        target.TakeDamage(attack);
    }

    protected void TakeDamage(float damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    protected void Die(){
        if(gameObject.tag == "EnemyUnit" && EPS > Random.Range(0f, 1f)){
            Vector2 spawnPosition = new Vector2(Random.Range(-7f, -5f), Random.Range(-2f, 2f));
            Instantiate(cardPrefabs[int.Parse(gameObject.name.Split("(")[0].Split("t")[1])] , spawnPosition, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    protected bool IfInRange(Vector2 targetPosition){
        float distance = Vector2.Distance(transform.position, targetPosition);
        if(distance <= range)
            return true;
        else
            return false;
    }
}
