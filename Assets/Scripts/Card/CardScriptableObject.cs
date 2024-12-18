using UnityEngine;
[CreateAssetMenu(fileName = "New Card",menuName = "Card" , order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public int manaCost;
    public int attackPower;
    public int health;
    public string cardName;
    public string cardType;
    [TextArea] public string cardDescription;
    [TextArea] public string cardLore;
    public Sprite cardSprite;
    public Sprite backgroundSprite;
}
