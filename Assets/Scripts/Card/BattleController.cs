using System.Collections;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    [HideInInspector] public int startingMana;
    public int maxMana;
    /*[HideInInspector]*/ public int playerMana;

    public int minStartingMana;
    public int maxStartingMana;

    public int startCardCount;
    public float betweenCardDraw;

    public int drawCardPerRound;

    public int addManaPerRound;

    [HideInInspector] public int turnCount;
    public enum TurnOrder { playerActive,enemyActive,allCardAttack}
    public TurnOrder currentOrder;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        fillPlayerMana();

        DeckController.instance.StartCardDraw(startCardCount,betweenCardDraw);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            AdvanceTurn();
        }
    }

    public void SpendPlayerMana(int amountToSpend)
    {
        playerMana -= amountToSpend;
        if(playerMana < 0)
        {
            playerMana = 0;
        }

        UiController.instance.SetPlayerManaText(playerMana);
    }

    public void AdvanceTurn()
    {
        //currentOrder++;
        turnCount++;
        if(turnCount == 8)
        {
            currentOrder = TurnOrder.allCardAttack;
        }
        //if((int)currentOrder >= System.Enum.GetValues(typeof(TurnOrder)).Length)
        //{
        //    currentOrder = 0;
        //}

        switch (currentOrder)
        {
            case TurnOrder.playerActive:

                UiController.instance.endTurnButton.SetActive(true);
                UiController.instance.drawCardButton.SetActive(true);

                DeckController.instance.DrawCardPerRound(drawCardPerRound);

                break;
            case TurnOrder.enemyActive:
                for (int i = 0; i < 2; i++)
                {
                    EnemyController.instance.StartAction();

                    playerMana += addManaPerRound;

                    UiController.instance.SetPlayerManaText(playerMana);
                }
                break;
            case TurnOrder.allCardAttack:
                turnCount = -1;
                StartCoroutine(AttackStartIE());
                break;
        }
    }
    IEnumerator AttackStartIE()
    {
        AudioSource audiosource = GetComponent<AudioSource>();
        DeckController.instance.AudioSource.Stop();
        audiosource.Play();
        yield return new WaitForSeconds(2f);
        DeckController.instance.AudioSource.Play();
        CardPointsController.instance.CardsAttack();
    }

    

    public void fillPlayerMana()
    {
        startingMana = Random.Range(minStartingMana, maxStartingMana);
        playerMana = startingMana;

        UiController.instance.SetPlayerManaText(startingMana);

        UiController.instance.endTurnButton.SetActive(true);
        UiController.instance.drawCardButton.SetActive(true);
    }
}
