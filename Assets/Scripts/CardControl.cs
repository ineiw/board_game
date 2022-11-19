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
                if(SameNameCards(gameObject, other.gameObject)){
                    overlap = true;
                    overlapCard = other.gameObject;
                }
                else{
                    // avoid overlap position
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                }
            }
        }

        if(other.gameObject.tag == "UnitZone" && isOnHand == false){
            toUnit();
        }
    }
    bool SameNameCards(GameObject card1, GameObject card2){
        if(card1.name.Split("(")[0] == card2.name.Split("(")[0]){
            return true;
        }
        else{
            return false;
        }
    }
}