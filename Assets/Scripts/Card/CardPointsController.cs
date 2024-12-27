using System;
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

    public void CardsAttack()
    {
        StartCoroutine(PlayerAttackIE());
    }

    IEnumerator PlayerAttackIE()
    {
        yield return new WaitForSeconds(timeBetweenAttack);

        for(int i = 0 ; i < playerCardPoints.Length ; i++)
        {
            //CARD ABILITY
            if (playerCardPoints[i].activeCard != null)
            {
                if (playerCardPoints[i].activeCard.cardAbility != "Nature" && playerCardPoints[i].activeCard.cardAbility != "Fire" && enemyCardPoints[i].activeCard != null)
                {
                    playerCardPoints[i].activeCard.GetComponent<CardAbility>().playAbility(playerCardPoints[i].activeCard, enemyCardPoints[i].activeCard);
                }
                else
                {
                    int x = i + 1;
                    if (x != 5 && playerCardPoints[x].activeCard != null)
                    {
                        playerCardPoints[i].activeCard.GetComponent<CardAbility>().playAbility(playerCardPoints[i].activeCard, playerCardPoints[x].activeCard);
                    }
                }
                
            }
            if (enemyCardPoints[i].activeCard != null)
            {

                if (enemyCardPoints[i].activeCard.cardAbility != "Nature" && enemyCardPoints[i].activeCard.cardAbility != "Fire" && playerCardPoints[i].activeCard != null)
                {
                    enemyCardPoints[i].activeCard.GetComponent<CardAbility>().playAbility(enemyCardPoints[i].activeCard, playerCardPoints[i].activeCard);
                }
                else
                {
                    int x = i + 1;
                    if (x != 5)
                    {
                        enemyCardPoints[i].activeCard.GetComponent<CardAbility>().playAbility(enemyCardPoints[i].activeCard, enemyCardPoints[x].activeCard);
                    }
                }
            }
            //CARD ABILITY
            //------------------------
            //CARD ATTACKS 
            if (playerCardPoints[i].activeCard != null)
            {
                if (enemyCardPoints[i].activeCard != null)
                {
                    enemyCardPoints[i].activeCard.GetDamage(playerCardPoints[i].activeCard.attackPower);
                }
                else
                {
                    TowerHealthController.instance.ChangeEnemyTowerHealth(playerCardPoints[i].activeCard.attackPower);
                    playerCardPoints[i].activeCard.animator.SetTrigger("CardAttack");
                }
            }
            if (enemyCardPoints[i].activeCard != null)
            {
                if (playerCardPoints[i].activeCard != null)
                {
                    playerCardPoints[i].activeCard.GetDamage(enemyCardPoints[i].activeCard.attackPower);
                }
                else
                {
                    TowerHealthController.instance.ChangePlayerTowerHealth(enemyCardPoints[i].activeCard.attackPower);
                    enemyCardPoints[i].activeCard.animator.SetTrigger("CardAttack");
                }
            }
            //CARD ATTACKS
            yield return new WaitForSeconds(timeBetweenAttack);
        }
        CheckAssignedCards();

        CleanBattleArena();
        BattleController.instance.currentOrder = BattleController.TurnOrder.enemyActive;
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

    public void CleanBattleArena()
    {
        for (int i = 0; i < playerCardPoints.Length; i++)
        {
            if (playerCardPoints[i].activeCard != null)
            {
                Destroy(playerCardPoints[i].activeCard.gameObject);
            }
            if (enemyCardPoints[i].activeCard != null)
            {
                Destroy(enemyCardPoints[i].activeCard.gameObject);
            }
        }
        BattleController.instance.fillPlayerMana();
    }
}
