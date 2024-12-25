using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public static DeckController instance;

    public List<CardScriptableObject> deckToUse = new List<CardScriptableObject>();
    public List<CardScriptableObject> activeCards = new List<CardScriptableObject>();
    
    public Card cardToSpawn;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SetupDeck();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            DrawCardToHand();
        }
    }
    public void SetupDeck()
    {
        activeCards.Clear();

        List<CardScriptableObject> cardsInDeck = new List<CardScriptableObject>();
        cardsInDeck.AddRange(deckToUse);

        while(cardsInDeck.Count > 0)
        {
            int selected = Random.Range(0, cardsInDeck.Count);
            activeCards.Add(cardsInDeck[selected]);
            cardsInDeck.RemoveAt(selected);
        }
    }

    public void DrawCardToHand()
    {
        if(activeCards.Count == 0)
        {
            SetupDeck();
        }

        Card newCard = Instantiate(cardToSpawn, transform.position, transform.rotation);
        newCard.cardSO = activeCards[0];

        activeCards.RemoveAt(0);

        HandController.instance.AddToCardToHand(newCard);
    }
    public void DrawCardPerRound(int DrawCardCount)
    {
        StartCoroutine(DrawCardPerRoundIE(DrawCardCount));
    }
    public IEnumerator DrawCardPerRoundIE(int DrawCardCount)
    {
        for(int i = 0 ; i < DrawCardCount ; i++)
        {
            DrawCardToHand();
            yield return new WaitForSeconds(.3f);
        }
    }

    public void StartCardDraw(int startCardCount, float betweenCardDraw)
    {
        StartCoroutine(StartCardDrawIE(startCardCount, betweenCardDraw));
    }
    public IEnumerator StartCardDrawIE(int startCardCount, float betweenCardDraw)
    {
        for (int i = 0; i < startCardCount; i++)
        {
            DrawCardToHand();
            yield return new WaitForSeconds(betweenCardDraw);
        }
    }
}
