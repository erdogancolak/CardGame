using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    public CardScriptableObject cardSO;

    [HideInInspector] public int manaCost;
    [HideInInspector] public int attackPower;
    [HideInInspector] public int health;
    [HideInInspector] public string cardName;
    [HideInInspector] public string cardType;
    [HideInInspector] public string cardDescription;
    [HideInInspector] public string cardLore;

    public TMP_Text manaCostText;
    public TMP_Text attackPowerText;
    public TMP_Text healthText;
    public TMP_Text cardNameText;
    public TMP_Text cardTypeText;
    public TMP_Text cardDescriptionText;
    public TMP_Text cardLoreText;
    public Image characterImage;
    void Start()
    {
        cardInfo();
    }

    void Update()
    {
        
    }

    public void cardInfo()
    {
        manaCost = cardSO.manaCost;
        attackPower = cardSO.attackPower;
        health = cardSO.health;
        cardName = cardSO.cardName;
        cardType = cardSO.cardType;
        cardDescription = cardSO.cardDescription;
        cardLore = cardSO.cardLore;

        manaCostText.text = manaCost.ToString();
        attackPowerText.text = attackPower.ToString();
        healthText.text = health.ToString();
        cardNameText.text = cardName.ToString();
        cardTypeText.text = cardType.ToString();
        cardDescriptionText.text = cardDescription.ToString();
        cardLoreText.text = cardLore.ToString();
        characterImage.sprite = cardSO.cardSprite;
    }
}
