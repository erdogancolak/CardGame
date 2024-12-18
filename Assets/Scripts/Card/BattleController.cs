using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    [HideInInspector] public int startingMana;
    public int maxMana;
    [HideInInspector] public int playerMana;

    public int minStartingMana;
    public int maxStartingMana;

    public int startCardCount;
    public float betweenCardDraw;
    public enum TurnOrder { playerActive, playerCardAttack,enemyActive,enemyCardAttack}
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
        currentOrder++;

        if((int)currentOrder >= System.Enum.GetValues(typeof(TurnOrder)).Length)
        {
            currentOrder = 0;
        }

        switch (currentOrder)
        {
            case TurnOrder.playerActive:
                fillPlayerMana();
                break;

            case TurnOrder.playerCardAttack:
                break;

            case TurnOrder.enemyActive:
                break;

            case TurnOrder.enemyCardAttack:
                break;

        }
    }

    public void fillPlayerMana()
    {
        startingMana = Random.Range(minStartingMana, maxStartingMana);
        playerMana = startingMana;

        UiController.instance.SetPlayerManaText(startingMana);
    }
}
