using UnityEngine;
[CreateAssetMenu(fileName = "New Card",menuName = "Card" , order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public int manaCost;
    public int attackPower;
    public int health;
    public string cardName;
    public Sprite modelHolderSprite;
}
