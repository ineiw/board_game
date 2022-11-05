using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    bool isOnHand = false;

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
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.zero);
            if(hit.collider != null){
                if(hit.collider.gameObject.tag == "Card"){
                    isOnHand = true;
                }
            }
            Debug.Log(hit.collider.name);
        }
        if(Input.GetMouseButtonUp(0)){
            isOnHand = false;
        }
        if(isOnHand){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }
}
