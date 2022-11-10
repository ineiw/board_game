using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        List<Transform> enemyUnits = GetEnemyUnitsList();
        
        Vector2 neariestTargetPosition = GetNeariestTargetPosition(enemyUnits);
        GameObject neariestTarget = GetNeariestTarget(enemyUnits);
        Rigidbody2D neariestTargetRigidbody = neariestTarget.GetComponent<Rigidbody2D>();
        Unit neariestTargetUnit = neariestTarget.GetComponent<Unit>();
        
        if(IfInRange(neariestTargetUnit.transform.position)){
            neariestTargetRigidbody.AddForce(GetTargetDir(neariestTargetPosition) * attack * power);
            Attack(neariestTargetUnit);
        }
        else{
            Move(GetTargetDir(neariestTargetPosition));
        }
    }
}
