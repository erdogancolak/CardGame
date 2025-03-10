using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    public static UiController instance;

    public TMP_Text playerManaText;

    public GameObject manaWarning;
    public float manaWarningTime;
    private float manaWarningCounter;

    public int drawManaCost;
    public GameObject drawCardButton;

    public GameObject endTurnButton;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(manaWarningCounter > 0)
        {
            manaWarningCounter -= Time.deltaTime;
            if(manaWarningCounter <= 0)
            {
                manaWarning.SetActive(false);
            }
        }
    }

    public void SetPlayerManaText(int manaAmount)
    {
        playerManaText.text = "MANA = " + manaAmount.ToString();
    }

    public void ShowManaWarning()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        manaWarning.SetActive(true);
        manaWarningCounter = manaWarningTime;
    }

    public void DrawCard()
    {
        if(BattleController.instance.playerMana >= drawManaCost)
        {
            DeckController.instance.DrawCardToHand();
            BattleController.instance.SpendPlayerMana(drawManaCost);
            if(BattleController.instance.playerMana < 2)
            {
                drawCardButton.SetActive(false);
            }
        }
    }

    public void EndTurn()
    {
        endTurnButton.SetActive(false);
        drawCardButton.SetActive(false);

        BattleController.instance.currentOrder = BattleController.TurnOrder.enemyActive;
        BattleController.instance.AdvanceTurn();
    }
}
