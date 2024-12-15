using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    public static UiController instance;

    public TMP_Text playerManaText;

    public GameObject manaWarning;
    public float manaWarningTime;
    private float manaWarningCounter;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(manaWarningCounter > 0)
        {
            manaWarningCounter -= Time.deltaTime;
            if(manaWarningCounter <= 0)
            {
                manaWarning.SetActive(false);
            }
        }
    }

    public void SetPlayerManaText(int manaAmount)
    {
        playerManaText.text = "MANA = " + manaAmount.ToString();
    }

    public void ShowManaWarning()
    {
        manaWarning.SetActive(true);
        manaWarningCounter = manaWarningTime;
    }
}
