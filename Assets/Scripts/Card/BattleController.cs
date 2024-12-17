using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    [HideInInspector] public int startingMana;
    public int maxMana;
    [HideInInspector] public int playerMana;
    public int minStartingMana;
    public int maxStartingMana;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        startingMana = Random.Range(minStartingMana,maxStartingMana);
        playerMana = startingMana;

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
