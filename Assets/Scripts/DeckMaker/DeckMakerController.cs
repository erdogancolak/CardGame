using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DeckMakerController : MonoBehaviour
{
    [SerializeField] private List<CardScriptableObject> natureDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> lightningDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> fireDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> iceDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> crownDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> mageDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> oceanDeck = new List<CardScriptableObject>();
    [SerializeField] private List<CardScriptableObject> ghostDeck = new List<CardScriptableObject>();
    [Space]
    public List<CardScriptableObject> natureDeckHold = new List<CardScriptableObject>();
    public List<CardScriptableObject> lightningDeckHold = new List<CardScriptableObject>();
    public List<CardScriptableObject> fireDeckHold = new List<CardScriptableObject>();
    public List<CardScriptableObject> iceDeckHold = new List<CardScriptableObject>();
    public List<CardScriptableObject> crownDeckHold = new List<CardScriptableObject>();
    public List<CardScriptableObject> mageDeckHold = new List<CardScriptableObject>();
    public List<CardScriptableObject> oceanDeckHold = new List<CardScriptableObject>();
    public List<CardScriptableObject> ghostDeckHold = new List<CardScriptableObject>();

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
    public bool isApply;

    public GameObject applyError;
    private void Start()
    {
        DeckHold(natureDeck,natureDeckHold);
        DeckHold(lightningDeck,lightningDeckHold);
        DeckHold(fireDeck,fireDeckHold);
        DeckHold(iceDeck,iceDeckHold);
        DeckHold(crownDeck,crownDeckHold);
        DeckHold(mageDeck,mageDeckHold);
        DeckHold(oceanDeck,oceanDeckHold);
        DeckHold(ghostDeck,ghostDeckHold);
    }

    private void Update()
    {
        TotalCardControl();
    }

    #region Nature
    public void NatureAdd()
    {
        if(canAdd)
        {
            natureCount++;
            if (natureCount > maxCardPerTheme)
            {
                natureCount = maxCardPerTheme;
            }
            natureCountText.text = (natureCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void NatureRemove()
    {
        natureCount--;
        if (natureCount < 0)
        {
            natureCount = 0;
        }
        natureCountText.text = (natureCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
    }
    #endregion
    #region Lightning
    public void LightningAdd()
    {
        if(canAdd)
        {
            lightningCount++;
            if (lightningCount > maxCardPerTheme)
            {
                lightningCount = maxCardPerTheme;
            }
            lightningCountText.text = (lightningCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void LightningRemove()
    {
        lightningCount--;
        if(lightningCount < 0)
        {
            lightningCount = 0;
        }
        lightningCountText.text = (lightningCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
    }
    #endregion
    #region Fire
    public void FireAdd()
    {
        if(canAdd)
        {
            fireCount++;
            if (fireCount > maxCardPerTheme)
            {
                fireCount = maxCardPerTheme;
            }
            fireCountText.text = (fireCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void FireRemove()
    {
        fireCount--;
        if(fireCount < 0)
        {
            fireCount = 0;
        }
        fireCountText.text = (fireCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
    }
    #endregion
    #region Ice
    public void IceAdd()
    {
        if(canAdd)
        {
            iceCount++;
            if (iceCount > maxCardPerTheme)
            {
                iceCount = maxCardPerTheme;
            }
            iceCountText.text = (iceCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void IceRemove()
    {
        iceCount--;
        if(iceCount < 0)
        {
            iceCount = 0;
        }
        iceCountText.text = (iceCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
    }
    #endregion
    #region Crown
    public void CrownAdd()
    {
        if(canAdd)
        {
            crownCount++;
            if (crownCount > maxCardPerTheme)
            {
                crownCount = maxCardPerTheme;
            }
            crownCountText.text = (crownCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void CrownRemove()
    {
        crownCount--;
        if(crownCount < 0)
        {
            crownCount = 0;
        }
        crownCountText.text = (crownCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
    }
    #endregion
    #region Mage
    public void MageAdd()
    {
        if(canAdd)
        {
            mageCount++;
            if (mageCount > maxCardPerTheme)
            {
                mageCount = maxCardPerTheme;
            }
            mageCountText.text = (mageCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void MageRemove()
    {
        mageCount--;
        if(mageCount < 0)
        {
            mageCount = 0;
        }
        mageCountText.text = (mageCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
    }
    #endregion
    #region Ocean
    public void OceanAdd()
    {
        if(canAdd)
        {
            oceanCount++;
            if (oceanCount > maxCardPerTheme)
            {
                oceanCount = maxCardPerTheme;
            }
            oceanCountText.text = (oceanCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void OceanRemove()
    {
        oceanCount--;
        if (oceanCount < 0)
        {
            oceanCount = 0;
        }
        oceanCountText.text = (oceanCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
    }
    #endregion
    #region Ghost
    public void GhostAdd()
    {
        if(canAdd)
        {
            ghostCount++;
            if (ghostCount > maxCardPerTheme)
            {
                ghostCount = maxCardPerTheme;
            }
            ghostCountText.text = (ghostCount.ToString() + " X");
            GuýController.instance.ClickSFX();
        }
    }
    public void GhostRemove()
    {
        ghostCount--;
        if(ghostCount < 0)
        {
            ghostCount = 0;
        }
        ghostCountText.text = (ghostCount.ToString() + " X");
        GuýController.instance.ClickSFX();
        ResetAllTheme();
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
    public void ResetAllTheme()
    {
        DeckController.instance.deckToUse.Clear();
        natureDeck.Clear();
        DeckHold(natureDeckHold, natureDeck);
        lightningDeck.Clear();
        DeckHold(lightningDeckHold, lightningDeck);
        fireDeck.Clear();
        DeckHold(fireDeckHold, fireDeck);
        iceDeck.Clear();
        DeckHold(iceDeckHold, iceDeck);
        crownDeck.Clear();
        DeckHold(crownDeckHold, crownDeck);
        mageDeck.Clear();
        DeckHold(mageDeckHold, mageDeck);
        oceanDeck.Clear();
        DeckHold(oceanDeckHold, oceanDeck);
        ghostDeck.Clear();
        DeckHold(ghostDeckHold, ghostDeck);
        isApply = false;
    }
    public void DeckHold(List<CardScriptableObject> deck1,List<CardScriptableObject> deck2)
    {
        for(int i = 0;i < deck1.Count;i++)
        {
            deck2.Add(deck1[i]);
        }
    }
    public void ApplyButton()
    {
        if(totalCount == maxTotalCard)
        {
            DeckController.instance.deckToUse.Clear();
            GenerateEnemyDeck();
        }
        else
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();             
            applyError.SetActive(true);
            StartCoroutine(applyErrorClose());
        }
        
    }
    IEnumerator applyErrorClose()
    {
        yield return new WaitForSeconds(2f);
        applyError.SetActive(false);
    }
    public void CloseButton()
    {
        GuýController.instance.CloseButton();
        if(totalCount != maxTotalCard)
        {
            totalCount = 0;
            natureCount = 0;
            lightningCount = 0;
            fireCount = 0;
            iceCount = 0;
            crownCount = 0;
            mageCount = 0;
            oceanCount = 0;
            ghostCount = 0;
            ResetAllTheme();
            natureCountText.text = (natureCount.ToString() + " X");
            lightningCountText.text = (lightningCount.ToString() + " X");
            fireCountText.text = (fireCount.ToString() + " X");
            iceCountText.text = (iceCount.ToString() + " X");
            crownCountText.text = (crownCount.ToString() + " X");
            mageCountText.text = (mageCount.ToString() + " X");
            oceanCountText.text = (oceanCount.ToString() + " X");
            ghostCountText.text = (ghostCount.ToString() + " X");
        }
    }
    public void GeneratePlayerDeck()
    {
        if (totalCount == maxTotalCard)
        {
            if(natureCount != 0)
            {
                for(int i = 0;i < natureCount;i++)
                {
                    int randomNumber = Random.Range(0, natureDeck.Count);
                    DeckController.instance.deckToUse.Add(natureDeck[randomNumber]);
                    natureDeck.Remove(natureDeck[randomNumber]);
                }
            }
            if(lightningCount != 0)
            {
                for(int i = 0;i < lightningCount;i++)
                {
                    int randomNumber = Random.Range(0, lightningDeck.Count);
                    DeckController.instance.deckToUse.Add(lightningDeck[randomNumber]);
                    lightningDeck.Remove(lightningDeck[randomNumber]);
                }
            }
            if (fireCount != 0)
            {
                for (int i = 0; i < fireCount; i++)
                {
                    int randomNumber = Random.Range(0, fireDeck.Count);
                    DeckController.instance.deckToUse.Add(fireDeck[randomNumber]);
                    fireDeck.Remove(fireDeck[randomNumber]);
                }
            }
            if (iceCount != 0)
            {
                for (int i = 0; i < iceCount; i++)
                {
                    int randomNumber = Random.Range(0, iceDeck.Count);
                    DeckController.instance.deckToUse.Add(iceDeck[randomNumber]);
                    iceDeck.Remove(iceDeck[randomNumber]);
                }
            }
            if (crownCount != 0)
            {
                for (int i = 0; i < crownCount; i++)
                {
                    int randomNumber = Random.Range(0, crownDeck.Count);
                    DeckController.instance.deckToUse.Add(crownDeck[randomNumber]);
                    crownDeck.Remove(crownDeck[randomNumber]);
                }
            }
            if (mageCount != 0)
            {
                for (int i = 0; i < mageCount; i++)
                {
                    int randomNumber = Random.Range(0, mageDeck.Count);
                    DeckController.instance.deckToUse.Add(mageDeck[randomNumber]);
                    mageDeck.Remove(mageDeck[randomNumber]);
                }
            }
            if (oceanCount != 0)
            {
                for (int i = 0; i < oceanCount; i++)
                {
                    int randomNumber = Random.Range(0, oceanDeck.Count);
                    DeckController.instance.deckToUse.Add(oceanDeck[randomNumber]);
                    oceanDeck.Remove(oceanDeck[randomNumber]);
                }
            }
            if (ghostCount != 0)
            {
                for (int i = 0; i < ghostCount; i++)
                {
                    int randomNumber = Random.Range(0, ghostDeck.Count);
                    DeckController.instance.deckToUse.Add(ghostDeck[randomNumber]);
                    ghostDeck.Remove(ghostDeck[randomNumber]);
                }
            }
            GuýController.instance.CloseButton();
            isApply = true;
        }
    }
    public void GenerateEnemyDeck()
    {
        for(int i = 0;i < maxTotalCard; i++)
        {
            int randomTheme = Random.Range(0,8);
            int randomCard = Random.Range(0, 20);
            switch(randomTheme)
            {
                case 0:
                    EnemyController.instance.deckToUse.Add(natureDeck[randomCard]);
                    break;
                case 1:
                    EnemyController.instance.deckToUse.Add(lightningDeck[randomCard]);
                    break;
                case 2:
                    EnemyController.instance.deckToUse.Add(fireDeck[randomCard]);
                    break;
                case 3:
                    EnemyController.instance.deckToUse.Add(iceDeck[randomCard]);
                    break;
                case 4:
                    EnemyController.instance.deckToUse.Add(crownDeck[randomCard]);
                    break;
                case 5:
                    EnemyController.instance.deckToUse.Add(mageDeck[randomCard]);
                    break;
                case 6:
                    EnemyController.instance.deckToUse.Add(oceanDeck[randomCard]);
                    break;
                case 7:
                    EnemyController.instance.deckToUse.Add(ghostDeck[randomCard]);
                    break;
            }
        }
        GeneratePlayerDeck();
    }

    //public void GenerateEnemyDeck1()
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
