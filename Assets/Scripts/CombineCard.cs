using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineCard : MonoBehaviour
{
    public GameObject cardPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //array to list
        GameObject[] cardArray = GameObject.FindGameObjectsWithTag("NotOnHandCard");

        List<Transform> cardList = new List<Transform>();
        
        foreach (GameObject card in cardArray)
        {
            cardList.Add(card.transform);
        }

        foreach(Transform card in cardList){
            if(card.GetComponent<CardControl>().overlap == true){
                RemoveCards(card.gameObject, card.GetComponent<CardControl>().overlapCard);
                GenerateNewCard(card.transform.position);
                break;
            }
        }
        
    }
    void GenerateNewCard(Vector2 cardPosition){
        GameObject newCard = Instantiate(cardPrefab, cardPosition, Quaternion.identity);
        newCard.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void RemoveCards(GameObject card1, GameObject card2){
        Destroy(card1);
        Destroy(card2);
    }
}
