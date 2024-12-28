using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckMakerController : MonoBehaviour
{
    //[SerializeField] private Sprite natureSprite;
    //[SerializeField] private Sprite LightningSprite;
    //[SerializeField] private Sprite FireSprite;
    //[SerializeField] private Sprite IceSprite;
    //[SerializeField] private Sprite CrownSprite;
    //[SerializeField] private Sprite MageSprite;
    //[SerializeField] private Sprite OceanSprite;
    //[SerializeField] private Sprite GhostSprite;

    //[SerializeField] private List<Image> SelectedFrames = new List<Image>();

    //private int selectedFrameIndex;

    [SerializeField] private List<CardScriptableObject> natureDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> lightningDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> fireDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> iceDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> crownDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> mageDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> oceanDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> ghostDeck = new List<CardScriptableObject>();

    //[HideInInspector] private string SelectedDeck1;
    //[HideInInspector] private string SelectedDeck2;
    [Space]

    [HideInInspector] public int natureCount;
    [HideInInspector] public int lightningCount;
    [HideInInspector] public int fireCount;
    [HideInInspector] public int iceCount;
    [HideInInspector] public int crownCount;
    [HideInInspector] public int mageCount;
    [HideInInspector] public int oceanCount;
    [HideInInspector] public int ghostCount;
    [HideInInspector] public int totalCount;

    public TMP_Text natureCountText;
    public TMP_Text lightningCountText;
    public TMP_Text fireCountText;
    public TMP_Text iceCountText;
    public TMP_Text crownCountText;
    public TMP_Text mageCountText;
    public TMP_Text oceanCountText;
    public TMP_Text ghostCountText;
    public TMP_Text totalCountText;

    public int maxCardPerTheme;
    public int maxTotalCard;

    private bool canAdd;

    private void Update()
    {
        TotalCardControl();
    }

    #region Nature
    public void NatureAdd()
    {
        //if(selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = natureSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Nature";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = natureSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Nature";
        //}
        if(canAdd)
        {
            natureCount++;
            if (natureCount > maxCardPerTheme)
            {
                natureCount = maxCardPerTheme;
            }
            natureCountText.text = (natureCount.ToString() + " X");
        }
    }
    public void NatureRemove()
    {
        //if(selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = natureSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Nature";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = natureSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Nature";
        //}
        natureCount--;
        if (natureCount < 0)
        {
            natureCount = 0;
        }
        natureCountText.text = (natureCount.ToString() + " X");
    }
    #endregion
    #region Lightning
    public void LightningAdd()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = LightningSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Lightning";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = LightningSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Lightning";
        //}
        if(canAdd)
        {
            lightningCount++;
            if (lightningCount > maxCardPerTheme)
            {
                lightningCount = maxCardPerTheme;
            }
            lightningCountText.text = (lightningCount.ToString() + " X");
        }
    }
    public void LightningRemove()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = LightningSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Lightning";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = LightningSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Lightning";
        //}
        lightningCount--;
        if(lightningCount < 0)
        {
            lightningCount = 0;
        }
        lightningCountText.text = (lightningCount.ToString() + " X");
    }
    #endregion
    #region Fire
    public void FireAdd()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = FireSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Fire";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = FireSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Fire";
        //}
        if(canAdd)
        {
            fireCount++;
            if (fireCount > maxCardPerTheme)
            {
                fireCount = maxCardPerTheme;
            }
            fireCountText.text = (fireCount.ToString() + " X");
        }
    }
    public void FireRemove()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = FireSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Fire";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = FireSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Fire";
        //}
        fireCount--;
        if(fireCount < 0)
        {
            fireCount = 0;
        }
        fireCountText.text = (fireCount.ToString() + " X");
    }
    #endregion
    #region Ice
    public void IceAdd()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = IceSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Ice";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = IceSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Ice";
        //}
        if(canAdd)
        {
            iceCount++;
            if (iceCount > maxCardPerTheme)
            {
                iceCount = maxCardPerTheme;
            }
            iceCountText.text = (iceCount.ToString() + " X");
        }
    }
    public void IceRemove()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = IceSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Ice";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = IceSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Ice";
        //}
        iceCount--;
        if(iceCount < 0)
        {
            iceCount = 0;
        }
        iceCountText.text = (iceCount.ToString() + " X");
    }
    #endregion
    #region Crown
    public void CrownAdd()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = CrownSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Crown";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = CrownSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Crown";
        //}
        if(canAdd)
        {
            crownCount++;
            if (crownCount > maxCardPerTheme)
            {
                crownCount = maxCardPerTheme;
            }
            crownCountText.text = (crownCount.ToString() + " X");
        }
    }
    public void CrownRemove()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = CrownSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Crown";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = CrownSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Crown";
        //}
        crownCount--;
        if(crownCount < 0)
        {
            crownCount = 0;
        }
        crownCountText.text = (crownCount.ToString() + " X");
    }
    #endregion
    #region Mage
    public void MageAdd()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = MageSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Mage";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = MageSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Mage";
        //}
        if(canAdd)
        {
            mageCount++;
            if (mageCount > maxCardPerTheme)
            {
                mageCount = maxCardPerTheme;
            }
            mageCountText.text = (mageCount.ToString() + " X");
        }
    }
    public void MageRemove()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = MageSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Mage";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = MageSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Mage";
        //}
        mageCount--;
        if(mageCount < 0)
        {
            mageCount = 0;
        }
        mageCountText.text = (mageCount.ToString() + " X");
    }
    #endregion
    #region Ocean
    public void OceanAdd()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = OceanSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Ocean";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = OceanSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Ocean";
        //}
        if(canAdd)
        {
            oceanCount++;
            if (oceanCount > maxCardPerTheme)
            {
                oceanCount = maxCardPerTheme;
            }
            oceanCountText.text = (oceanCount.ToString() + " X");
        }
    }
    public void OceanRemove()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = OceanSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Ocean";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = OceanSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Ocean";
        //}
        oceanCount--;
        if (oceanCount < 0)
        {
            oceanCount = 0;
        }
        oceanCountText.text = (oceanCount.ToString() + " X");
    }
    #endregion
    #region Ghost
    public void GhostAdd()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = GhostSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Ghost";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = GhostSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Ghost";
        //}
        if(canAdd)
        {
            ghostCount++;
            if (ghostCount > maxCardPerTheme)
            {
                ghostCount = maxCardPerTheme;
            }
            ghostCountText.text = (ghostCount.ToString() + " X");
        }
    }
    public void GhostRemove()
    {
        //if (selectedFrameIndex == 0)
        //{
        //    SelectedFrames[0].sprite = GhostSprite;
        //    selectedFrameIndex = 1;
        //    SelectedDeck1 = "Ghost";
        //}
        //else if (selectedFrameIndex == 1)
        //{
        //    SelectedFrames[1].sprite = GhostSprite;
        //    selectedFrameIndex = 0;
        //    SelectedDeck2 = "Ghost";
        //}
        ghostCount--;
        if(ghostCount < 0)
        {
            ghostCount = 0;
        }
        ghostCountText.text = (ghostCount.ToString() + " X");
    }
    #endregion

    public void TotalCardControl()
    {
        totalCount = natureCount + lightningCount + fireCount + iceCount + crownCount + mageCount + oceanCount + ghostCount;
        if(totalCount > maxTotalCard - 1)
        {
            canAdd = false;
        }
        else
        {
            canAdd = true;
        }
        totalCountText.text = totalCount.ToString() + " / " + maxTotalCard.ToString();
    }

    public void ApplyButton()
    {
        DeckController.instance.deckToUse.Clear();
        //GeneratePlayerDeck();
        //GenerateEnemyDeck();
    }

    //public void GeneratePlayerDeck()
    //{
    //    if(SelectedDeck1 == SelectedDeck2 && SelectedDeck1 == null && SelectedDeck2 == null)
    //    {
    //        return;
    //    }
    //    switch (SelectedDeck1)
    //    {
    //        case ("Nature"):
    //            for (int i = 0; i < natureDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(natureDeck[i]);
    //            }
    //            break;
    //        case ("Lightning"):
    //            for (int i = 0; i < lightningDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(lightningDeck[i]);
    //            }
    //            break;
    //        case ("Fire"):
    //            for (int i = 0; i < fireDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(fireDeck[i]);
    //            }
    //            break;
    //        case ("Ice"):
    //            for (int i = 0; i < iceDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(iceDeck[i]);
    //            }
    //            break;
    //        case ("Crown"):
    //            for (int i = 0; i < crownDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(crownDeck[i]);
    //            }
    //            break;
    //        case ("Mage"):
    //            for (int i = 0; i < mageDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(mageDeck[i]);
    //            }
    //            break;
    //        case ("Ocean"):
    //            for (int i = 0; i < oceanDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(oceanDeck[i]);
    //            }
    //            break;
    //        case ("Ghost"):
    //            for (int i = 0; i < ghostDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(ghostDeck[i]);
    //            }
    //            break;
    //    }
    //    switch (SelectedDeck2)
    //    {
    //        case ("Nature"):
    //            for (int i = 0; i < natureDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(natureDeck[i]);
    //            }
    //            break;
    //        case ("Lightning"):
    //            for (int i = 0; i < lightningDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(lightningDeck[i]);
    //            }
    //            break;
    //        case ("Fire"):
    //            for (int i = 0; i < fireDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(fireDeck[i]);
    //            }
    //            break;
    //        case ("Ice"):
    //            for (int i = 0; i < iceDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(iceDeck[i]);
    //            }
    //            break;
    //        case ("Crown"):
    //            for (int i = 0; i < crownDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(crownDeck[i]);
    //            }
    //            break;
    //        case ("Mage"):
    //            for (int i = 0; i < mageDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(mageDeck[i]);
    //            }
    //            break;
    //        case ("Ocean"):
    //            for (int i = 0; i < oceanDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(oceanDeck[i]);
    //            }
    //            break;
    //        case ("Ghost"):
    //            for (int i = 0; i < ghostDeck.Count; i++)
    //            {
    //                DeckController.instance.deckToUse.Add(ghostDeck[i]);
    //            }
    //            break;
    //    }
    //    GuýController.instance.CloseButton();
    //}

    //public void GenerateEnemyDeck()
    //{
    //    int EnemyDeckGenerator1 = Random.Range(0, 8);
    //    int EnemyDeckGenerator2 = Random.Range(0, 8);
    //    do
    //    {
    //        EnemyDeckGenerator2 = Random.Range(0, 8);
    //    }
    //    while (EnemyDeckGenerator2 == EnemyDeckGenerator1);

    //    switch (EnemyDeckGenerator1)
    //    {
    //        case 0:
    //            for (int i = 0; i < natureDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(natureDeck[i]);
    //            }
    //            break;
    //        case 1:
    //            for (int i = 0; i < lightningDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(lightningDeck[i]);
    //            }
    //            break;
    //        case 2:
    //            for (int i = 0; i < fireDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(fireDeck[i]);
    //            }
    //            break;
    //        case 3:
    //            for (int i = 0; i < iceDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(iceDeck[i]);
    //            }
    //            break;
    //        case 4:
    //            for (int i = 0; i < crownDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(crownDeck[i]);
    //            }
    //            break;
    //        case 5:
    //            for (int i = 0; i < mageDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(mageDeck[i]);
    //            }
    //            break;
    //        case 6:
    //            for (int i = 0; i < oceanDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(oceanDeck[i]);
    //            }
    //            break;
    //        case 7:
    //            for (int i = 0; i < ghostDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(ghostDeck[i]);
    //            }
    //            break;
    //    }
    //    switch (EnemyDeckGenerator2)
    //    {
    //        case 0:
    //            for (int i = 0; i < natureDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(natureDeck[i]);
    //            }
    //            break;
    //        case 1:
    //            for (int i = 0; i < lightningDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(lightningDeck[i]);
    //            }
    //            break;
    //        case 2:
    //            for (int i = 0; i < fireDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(fireDeck[i]);
    //            }
    //            break;
    //        case 3:
    //            for (int i = 0; i < iceDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(iceDeck[i]);
    //            }
    //            break;
    //        case 4:
    //            for (int i = 0; i < crownDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(crownDeck[i]);
    //            }
    //            break;
    //        case 5:
    //            for (int i = 0; i < mageDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(mageDeck[i]);
    //            }
    //            break;
    //        case 6:
    //            for (int i = 0; i < oceanDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(oceanDeck[i]);
    //            }
    //            break;
    //        case 7:
    //            for (int i = 0; i < ghostDeck.Count; i++)
    //            {
    //                EnemyController.instance.deckToUse.Add(ghostDeck[i]);
    //            }
    //            break;
    //    }
    //}

}
