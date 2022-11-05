using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineCard : MonoBehaviour
{
    public GameObject parentCardPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if card collider bounds contains other card collider bounds then overlap
    // void OnTriggerStay2D(Collider2D other){
    //     if(other.gameObject.tag == "Card"){
    //         if(!other.gameObject.GetComponent<CardControl>().isOnHand){
    //             if(GetComponent<Collider2D>().bounds.Contains((Vector2)other.transform.position)){
    //                 if(!GetComponent<CardControl>().isOnHand){
    //                     CardOverlap(other.transform.position, other.gameObject.GetComponent<SpriteRenderer>().sortingOrder);
    //                 }
    //             }
    //         }
    //     }
    // }
    // overlap code here
    void CardOverlap(Vector2 targetCardPos, int targetSortOrder){
        // if card is on floor then combine
        transform.position = targetCardPos - new Vector2(0, 0.3f);
        transform.GetComponent<SpriteRenderer>().sortingOrder = targetSortOrder + 1;
        // if card is on hand then combine
    }
}
