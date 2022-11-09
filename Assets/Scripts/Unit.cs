using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // unit preferences
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int attack = 10;
    public int defense = 10;
    public int speed = 10;
    public int range = 1;
    
    Vector2 GetTargetDir(Vector2 targetPosition){
        Vector2 targetDir = targetPosition - (Vector2)transform.position;
        return targetDir.normalized;
    }

    void Move(Vector2 targetDir){
        transform.Translate(targetDir * speed * Time.deltaTime);
    }

    void Attack(Unit target){
        target.TakeDamage(attack);
    }

    void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }    
}
