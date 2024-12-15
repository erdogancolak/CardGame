using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    public int startingMana;
    public int maxMana;
    [HideInInspector] public int playerMana;
    private void Awake()
    {
        instance = this;
        playerMana = startingMana;
    }
    void Start()
    {
        UiController.instance.SetPlayerManaText(startingMana);
    }

    void Update()
    {
        
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
}
