using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineCard : MonoBehaviour
{
    public GameObject[] cardPrefabs = new GameObject[3];
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
            if(card.GetComponent<CardControl>().overlap == true && SameNameCards(card.gameObject, card.GetComponent<CardControl>().overlapCard) == true){
                RemoveCards(card.gameObject, card.GetComponent<CardControl>().overlapCard);
                GenerateNewCard(cardPrefabs[(int.Parse(card.name.Split("(")[0].Split("d")[1])+1) % 3],card.transform.position);
                break;
            }
        }
        
    }
    void GenerateNewCard(GameObject cardPrefab,Vector2 cardPosition){
        GameObject newCard = Instantiate(cardPrefab, cardPosition, Quaternion.identity);
    }

    void RemoveCards(GameObject card1, GameObject card2){
        Destroy(card1);
        Destroy(card2);
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
