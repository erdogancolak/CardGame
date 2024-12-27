using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckMakerController : MonoBehaviour
{
    [SerializeField] private Sprite natureSprite;
    [SerializeField] private Sprite LightningSprite;
    [SerializeField] private Sprite FireSprite;
    [SerializeField] private Sprite IceSprite;
    [SerializeField] private Sprite CrownSprite;
    [SerializeField] private Sprite MageSprite;
    [SerializeField] private Sprite OceanSprite;
    [SerializeField] private Sprite GhostSprite;

    [SerializeField] private List<Image> SelectedFrames = new List<Image>();

    private int selectedFrameIndex;

    [SerializeField] private List<CardScriptableObject> natureDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> lightningDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> fireDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> iceDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> crownDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> mageDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> oceanDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> ghostDeck = new List<CardScriptableObject>();

    [HideInInspector] private string SelectedDeck1;
    [HideInInspector] private string SelectedDeck2;
    public void Nature()
    {
        if(selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = natureSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Nature";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = natureSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Nature";
        }
    }
    public void Lightning()
    {
        if (selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = LightningSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Lightning";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = LightningSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Lightning";
        }
    }
    public void Fire()
    {
        if (selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = FireSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Fire";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = FireSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Fire";
        }
    }
    public void Ice()
    {
        if (selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = IceSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Ice";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = IceSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Ice";
        }
    }
    public void Crown()
    {
        if (selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = CrownSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Crown";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = CrownSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Crown";
        }
    }
    public void Mage()
    {
        if (selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = MageSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Mage";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = MageSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Mage";
        }
    }
    public void Ocean()
    {
        if (selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = OceanSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Ocean";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = OceanSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Ocean";
        }
    }
    public void Ghost()
    {
        if (selectedFrameIndex == 0)
        {
            SelectedFrames[0].sprite = GhostSprite;
            selectedFrameIndex = 1;
            SelectedDeck1 = "Ghost";
        }
        else if (selectedFrameIndex == 1)
        {
            SelectedFrames[1].sprite = GhostSprite;
            selectedFrameIndex = 0;
            SelectedDeck2 = "Ghost";
        }
    }

    public void ApplyButton()
    {
        DeckController.instance.deckToUse.Clear();
        GeneratePlayerDeck();
        GenerateEnemyDeck();
    }

    public void GeneratePlayerDeck()
    {
        if(SelectedDeck1 == SelectedDeck2 && SelectedDeck1 == null && SelectedDeck2 == null)
        {
            return;
        }
        switch (SelectedDeck1)
        {
            case ("Nature"):
                for (int i = 0; i < natureDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(natureDeck[i]);
                }
                break;
            case ("Lightning"):
                for (int i = 0; i < lightningDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(lightningDeck[i]);
                }
                break;
            case ("Fire"):
                for (int i = 0; i < fireDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(fireDeck[i]);
                }
                break;
            case ("Ice"):
                for (int i = 0; i < iceDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(iceDeck[i]);
                }
                break;
            case ("Crown"):
                for (int i = 0; i < crownDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(crownDeck[i]);
                }
                break;
            case ("Mage"):
                for (int i = 0; i < mageDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(mageDeck[i]);
                }
                break;
            case ("Ocean"):
                for (int i = 0; i < oceanDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(oceanDeck[i]);
                }
                break;
            case ("Ghost"):
                for (int i = 0; i < ghostDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(ghostDeck[i]);
                }
                break;
        }
        switch (SelectedDeck2)
        {
            case ("Nature"):
                for (int i = 0; i < natureDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(natureDeck[i]);
                }
                break;
            case ("Lightning"):
                for (int i = 0; i < lightningDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(lightningDeck[i]);
                }
                break;
            case ("Fire"):
                for (int i = 0; i < fireDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(fireDeck[i]);
                }
                break;
            case ("Ice"):
                for (int i = 0; i < iceDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(iceDeck[i]);
                }
                break;
            case ("Crown"):
                for (int i = 0; i < crownDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(crownDeck[i]);
                }
                break;
            case ("Mage"):
                for (int i = 0; i < mageDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(mageDeck[i]);
                }
                break;
            case ("Ocean"):
                for (int i = 0; i < oceanDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(oceanDeck[i]);
                }
                break;
            case ("Ghost"):
                for (int i = 0; i < ghostDeck.Count; i++)
                {
                    DeckController.instance.deckToUse.Add(ghostDeck[i]);
                }
                break;
        }
        GuýController.instance.CloseButton();
    }

    public void GenerateEnemyDeck()
    {
        int EnemyDeckGenerator1 = Random.Range(0, 8);
        int EnemyDeckGenerator2 = Random.Range(0, 8);
        do
        {
            EnemyDeckGenerator2 = Random.Range(0, 8);
        }
        while (EnemyDeckGenerator2 == EnemyDeckGenerator1);

        switch (EnemyDeckGenerator1)
        {
            case 0:
                for (int i = 0; i < natureDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(natureDeck[i]);
                }
                break;
            case 1:
                for (int i = 0; i < lightningDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(lightningDeck[i]);
                }
                break;
            case 2:
                for (int i = 0; i < fireDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(fireDeck[i]);
                }
                break;
            case 3:
                for (int i = 0; i < iceDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(iceDeck[i]);
                }
                break;
            case 4:
                for (int i = 0; i < crownDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(crownDeck[i]);
                }
                break;
            case 5:
                for (int i = 0; i < mageDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(mageDeck[i]);
                }
                break;
            case 6:
                for (int i = 0; i < oceanDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(oceanDeck[i]);
                }
                break;
            case 7:
                for (int i = 0; i < ghostDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(ghostDeck[i]);
                }
                break;
        }
        switch (EnemyDeckGenerator2)
        {
            case 0:
                for (int i = 0; i < natureDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(natureDeck[i]);
                }
                break;
            case 1:
                for (int i = 0; i < lightningDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(lightningDeck[i]);
                }
                break;
            case 2:
                for (int i = 0; i < fireDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(fireDeck[i]);
                }
                break;
            case 3:
                for (int i = 0; i < iceDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(iceDeck[i]);
                }
                break;
            case 4:
                for (int i = 0; i < crownDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(crownDeck[i]);
                }
                break;
            case 5:
                for (int i = 0; i < mageDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(mageDeck[i]);
                }
                break;
            case 6:
                for (int i = 0; i < oceanDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(oceanDeck[i]);
                }
                break;
            case 7:
                for (int i = 0; i < ghostDeck.Count; i++)
                {
                    EnemyController.instance.deckToUse.Add(ghostDeck[i]);
                }
                break;
        }
    }

}
