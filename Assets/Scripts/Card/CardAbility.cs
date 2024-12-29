using System.Collections.Generic;
using UnityEngine;

public class CardAbility : MonoBehaviour
{
    [HideInInspector] public string Ability;

    public int NatureHealthIndex;
    [Space]
    public int FireAttackIndex;
    [Space]
    public int IceAttackIndex;
    [Space]
    public int MageAttackIndex;
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void playAbility(Card card1,Card card2)
    {
        Ability = card1.cardAbility;
        switch (Ability)
        {
            case "Nature":
                Nature(card2);
                break;
            case "Lightning":
                Lightning(card1, card2);
                break;
            case "Fire":
                Fire(card2);
                break;
            case "Ice":
                Ice(card2);
                break;
            case "Crown":
                Crown(card1);
                break;
            case "Mage":
                Mage(card2);
                break;
            case "Ocean":
                Ocean(card1, card2);
                break;
            case "Ghost":
                Ghost(card2);
                break;
        }
    }

    public void Nature(Card card2)
    {
        card2.health += NatureHealthIndex;
        card2.UpdateCardDisplay();
    }
    public void Lightning(Card card1,Card card2)
    {
        if(card2.health <= card1.attackPower)
        {
            card2.attackPower = 0;
        }
    }
    public void Fire(Card card2)
    {
        card2.attackPower += FireAttackIndex;
        card2.UpdateCardDisplay();
    }
    public void Ice(Card card2)
    {
        card2.attackPower -= IceAttackIndex;
        card2.UpdateCardDisplay();
    }
    public void Crown(Card card1)
    {
        if(card1.isPlayer)
        {
            TowerHealthController.instance.playerHealth += card1.attackPower;
            if(TowerHealthController.instance.playerHealth > 20)
            {
                TowerHealthController.instance.playerHealth = 20;
            }
            TowerHealthController.instance.playerHealthText.text = TowerHealthController.instance.playerHealth.ToString();
        }
        if(!card1.isPlayer)
        {
            TowerHealthController.instance.enemyHealth += card1.attackPower;
            if(TowerHealthController.instance.enemyHealth > 20)
            {
                TowerHealthController.instance.enemyHealth = 20;
            }
            TowerHealthController.instance.enemyHealthText.text = TowerHealthController.instance.enemyHealth.ToString();
        }
    }
    public void Mage(Card card2)
    {
            card2.GetDamage(MageAttackIndex);
    }
    public void Ocean(Card card1, Card card2)
    {
        if(card1.attackPower > card2.health)
        {
            int getDamageToTower = card1.attackPower - card2.health;
            if(card1.isPlayer)
            {
                TowerHealthController.instance.ChangeEnemyTowerHealth(getDamageToTower);
            }
            if(!card1.isPlayer)
            {
                TowerHealthController.instance.ChangePlayerTowerHealth(getDamageToTower);
            }
           
        }
    }
    public void Ghost(Card card2)
    {
        if(card2.cardAbility != "Ghost")
        {
            card2.attackPower = 0;
        }
    }

}
