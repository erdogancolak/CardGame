using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
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

    public Vector3 targetPoint;
    public Quaternion targetRotation;
    public float moveSpeed;
    public float rotationSpeed;

    public bool isHand;
    public int handPosition;

    private HandController handController;

    private bool isSelected;
    private Collider2D theCollider;
    public LayerMask desktopLayer;
    void Start()
    {
        cardInfo();

        handController = FindAnyObjectByType<HandController>();
        theCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation, rotationSpeed * Time.deltaTime);

        if(isSelected)
        {
            Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldMousePosition,Vector2.zero,100f,desktopLayer);
            if(hit)
            {
                MoveToPoint(hit.point, Quaternion.identity);
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            ReturnToHand();
        }
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

    public void MoveToPoint(Vector3 pointToMoveTo , Quaternion rotToMatch)
    {
        targetPoint = pointToMoveTo;
        targetRotation = rotToMatch;
    }
    private void OnMouseOver()
    {
        if (isHand)
        {
            MoveToPoint(handController.cardPositions[handPosition] + new Vector3(0,.3f,0),Quaternion.identity);
        }
    }
    private void OnMouseExit()
    {
        if (isHand)
        {
            MoveToPoint(handController.cardPositions[handPosition], handController.minPos.rotation);
        }
    }
    private void OnMouseDown()
    {
        if (isHand)
        {
            isSelected = true;
            theCollider.enabled = false;
        }
    }
    public void ReturnToHand()
    {
        isSelected = false;
        theCollider.enabled = true;

        MoveToPoint(handController.cardPositions[handPosition], handController.minPos.rotation);
    }
}
