using System.Collections;
using UnityEngine;

public class CardPointsController : MonoBehaviour
{
    public static CardPointsController instance;

    public CardPlacePoint[] playerCardPoints;
    public CardPlacePoint[] enemyCardPoints;

    public float timeBetweenAttack;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayerAttack()
    {
        StartCoroutine(PlayerAttackIE());
    }

    IEnumerator PlayerAttackIE()
    {
        yield return new WaitForSeconds(timeBetweenAttack);

        for(int i = 0 ; i < playerCardPoints.Length ; i++)
        {
            if (playerCardPoints[i].activeCard != null)
            {
                if (enemyCardPoints[i].activeCard != null)
                {
                    enemyCardPoints[i].activeCard.GetDamage(playerCardPoints[i].activeCard.attackPower);
                    playerCardPoints[i].activeCard.animator.SetTrigger("CardAttack");
                }
                else
                {
                    
                }
                yield return new WaitForSeconds(timeBetweenAttack);
            }
        }
        CheckAssignedCards();

        BattleController.instance.AdvanceTurn();
    }

    public void CheckAssignedCards()
    {
        foreach(CardPlacePoint point in enemyCardPoints)
        {
            if (point.activeCard != null)
            {
                if(point.activeCard.health <= 0)
                {
                    point.activeCard = null;
                }
            }
        }

        foreach (CardPlacePoint point in playerCardPoints)
        {
            if (point.activeCard != null)
            {
                if (point.activeCard.health <= 0)
                {
                    point.activeCard = null;
                }
            }
        }
    }
}
