using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public static HandController instance;

    public List<Card> heldCards = new List<Card>();

    public Transform minPos;
    public Transform maxPos;

    public List<Vector3> cardPositions = new List<Vector3>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        SetCardPositionInHands();
    }

    void Update()
    {
        
    }
    public void SetCardPositionInHands()
    {
        cardPositions.Clear();

        Vector3 distanceBetweenPoints = Vector2.zero;
        if(heldCards.Count > 1)
        {
            distanceBetweenPoints = (maxPos.position - minPos.position) / (heldCards.Count - 1);
        }
        for(int i = 0;i < heldCards.Count;i++)
        {
            cardPositions.Add(minPos.position + (distanceBetweenPoints * i));
            
            heldCards[i].MoveToPoint(cardPositions[i],minPos.rotation);

            heldCards[i].isHand = true;
            heldCards[i].handPosition = i;
        }
    }
    public void RemoveCardFromHand(Card cardToRemove)
    {
        if (heldCards.Contains(cardToRemove))
        {
            int removedCardPosition = cardToRemove.handPosition;

            heldCards.Remove(cardToRemove);

            SetCardPositionInHands();

            for (int i = removedCardPosition; i < heldCards.Count; i++)
            {
                heldCards[i].handPosition = i;
            }
        }
    }
    public void AddToCardToHand(Card AddToCard)
    {
        heldCards.Add(AddToCard);
        SetCardPositionInHands();
    }
}
