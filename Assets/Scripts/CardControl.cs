using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    public bool isOnHand = false;
    public bool overlap = false;
    public GameObject overlapCard = null;
    public GameObject unitPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when mouse position in the card collider bounds then call OnMouseDown
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(GetComponent<Collider2D>().bounds.Contains((Vector2)mousePos)){
                isOnHand = true;
            }
        }
        if(Input.GetMouseButtonUp(0)){
            isOnHand = false;
        }
        if(isOnHand){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

        Tagging();
    }

    void Tagging(){
        if(isOnHand){
            gameObject.tag = "OnHandCard";
        }
        else{
            gameObject.tag = "NotOnHandCard";
        }
    }

    void toUnit(){
        GameObject newUnit = Instantiate(unitPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "NotOnHandCard" && isOnHand == false){
            if(GetComponent<Collider2D>().bounds.Contains(other.transform.position)){
                overlap = true;
                overlapCard = other.gameObject;
            }
        }

        if(other.gameObject.tag == "UnitZone" && isOnHand == false){
            toUnit();
        }
    }
}
