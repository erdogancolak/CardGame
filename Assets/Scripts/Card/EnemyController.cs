using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public List<CardScriptableObject> deckToUse = new List<CardScriptableObject>();
    public List<CardScriptableObject> activeCards = new List<CardScriptableObject>();

    public Card cardToSpawn;
    public Transform cardSpawnPoint;

    public int cardPlacePointIndex;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        SetupDeck();
    }

    void Update()
    {

    }
    public void SetupDeck()
    {
        activeCards.Clear();

        List<CardScriptableObject> cardsInDeck = new List<CardScriptableObject>();
        cardsInDeck.AddRange(deckToUse);

        while (cardsInDeck.Count > 0)
        {
            int selected = Random.Range(0, cardsInDeck.Count);
            activeCards.Add(cardsInDeck[selected]);
            cardsInDeck.RemoveAt(selected);
        }
    }
    public void StartAction()
    {
        StartCoroutine(StartActionIE());
    }
    IEnumerator StartActionIE()
    {
        if (cardPlacePointIndex < 5)
        {
            if (activeCards.Count == 0)
            {
                SetupDeck();
            }
            yield return new WaitForSeconds(.3f);

            List<CardPlacePoint> cardPoints = new List<CardPlacePoint>();
            cardPoints.AddRange(CardPointsController.instance.enemyCardPoints);

            CardPlacePoint selectedPoint = cardPoints[cardPlacePointIndex];

            while (selectedPoint.activeCard != null && cardPoints.Count > 0)
            {
                selectedPoint = cardPoints[cardPlacePointIndex];
                cardPoints.RemoveAt(cardPlacePointIndex);
            }
            cardPlacePointIndex++;

            if (selectedPoint.activeCard == null)
            {
                Card newCard = Instantiate(cardToSpawn, cardSpawnPoint.position, cardSpawnPoint.rotation);
                newCard.cardSO = activeCards[0];
                activeCards.RemoveAt(0);
                newCard.cardInfo();
                newCard.MoveToPoint(selectedPoint.transform.position, selectedPoint.transform.rotation);

                selectedPoint.activeCard = newCard;
                newCard.assignedPlace = selectedPoint;
            }
            BattleController.instance.currentOrder = BattleController.TurnOrder.playerActive;
            BattleController.instance.AdvanceTurn();
        }
        else
        {
            cardPlacePointIndex = 0;
        }
    }
}
