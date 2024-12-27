using UnityEngine;
using TMPro;

public class TowerHealthController : MonoBehaviour
{
    public static TowerHealthController instance;

    [HideInInspector] public int playerHealth;
    [HideInInspector] public int enemyHealth;
    public int maxPlayerTowerHealth;
    public int maxEnemyTowerHealth;
    public TMP_Text playerHealthText;
    public TMP_Text enemyHealthText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerHealth = maxPlayerTowerHealth;
        enemyHealth = maxEnemyTowerHealth;
    }

    void Update()
    {
        
    }

    public void ChangePlayerTowerHealth(int damageAmount)
    {
        playerHealth -= damageAmount;

        if(playerHealth < 0)
        {
            playerHealth = 0;

            Debug.Log("Player Lose Game");
        }

        playerHealthText.text = playerHealth.ToString();

    }
    public void ChangeEnemyTowerHealth(int damageAmount)
    {
        enemyHealth -= damageAmount;

        if(enemyHealth < 0)
        {
            enemyHealth = 0;

            Debug.Log("Enemy Lose Game");
        }
        enemyHealthText.text = enemyHealth.ToString();
    }
}
