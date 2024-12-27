using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
public class Card : MonoBehaviour
{
    public CardScriptableObject cardSO;

    [HideInInspector] public int manaCost;
    [HideInInspector] public int attackPower;
    [HideInInspector] public int health;
    [HideInInspector] public string cardName;
    [HideInInspector] public string cardAbility;
   
    public TMP_Text manaCostText;
    public TMP_Text attackPowerText;
    public TMP_Text healthText;
    public TMP_Text cardNameText;
    public GameObject modelHolder;

    [HideInInspector] public Animator animator;

    public bool isPlayer;

    [HideInInspector] public Vector3 targetPoint;
    [HideInInspector] public Quaternion targetRotation;
    public float moveSpeed;
    public float rotationSpeed;

    [HideInInspector] public bool isHand;
    public int handPosition;

    private HandController handController;

    private bool isSelected;
    private Collider2D theCollider;
    public LayerMask desktopLayer;
    public LayerMask placementLayer; 

    private bool justPressed;
    [HideInInspector] public CardPlacePoint assignedPlace;

    private List<CardPlacePoint> allFrames;

    void Start()
    {
        if(targetPoint == Vector3.zero)
        {
            targetPoint = transform.position;
            targetRotation = transform.rotation;
        }
        animator = GetComponent<Animator>();
        cardInfo();

        handController = FindAnyObjectByType<HandController>();
        theCollider = GetComponent<Collider2D>();

        allFrames = Object.FindObjectsByType<CardPlacePoint>(FindObjectsSortMode.None).OrderBy(f => f.transform.position.x).ToList();

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation, rotationSpeed * Time.deltaTime);

        if (isSelected)
        {
            HandleSelection();
        }
        justPressed = false;
    }
    public void cardInfo()
    {
        cardAbility = cardSO.abilityName;
        manaCost = cardSO.manaCost;
        attackPower = cardSO.attackPower;
        health = cardSO.health;
        cardName = cardSO.cardName;
       

        UpdateCardDisplay();

        cardNameText.text = cardName.ToString();
        modelHolder.GetComponent<SpriteRenderer>().sprite = cardSO.modelHolderSprite;
       
    }

    public void MoveToPoint(Vector3 pointToMoveTo , Quaternion rotToMatch)
    {
        targetPoint = pointToMoveTo;
        targetRotation = rotToMatch;
    }
    private void OnMouseOver()
    {
        if (isHand && isPlayer)
        {
            MoveToPoint(handController.cardPositions[handPosition] + new Vector3(0,.3f,0),Quaternion.identity);
        }
    }
    private void OnMouseExit()
    {
        if (isHand && isPlayer)
        {
            MoveToPoint(handController.cardPositions[handPosition], handController.minPos.rotation);
        }
    }
    private void OnMouseDown()
    {
        if (isHand && BattleController.instance.currentOrder == BattleController.TurnOrder.playerActive && isPlayer)
        {
            isSelected = true;
            theCollider.enabled = false;

            justPressed = true;
        }
    }
    public void ReturnToHand()
    {
        isSelected = false;
        theCollider.enabled = true;

        MoveToPoint(handController.cardPositions[handPosition], handController.minPos.rotation);
    }

    public void HandleSelection()
    {
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D desktopHit = Physics2D.Raycast(worldMousePosition, Vector2.zero, 100f, desktopLayer);
        if (desktopHit)
        {
            MoveToPoint(desktopHit.point, Quaternion.identity);
        }


        if (Input.GetMouseButtonDown(1))
        {
            ReturnToHand();
        }
        if (Input.GetMouseButtonDown(0) && justPressed == false)
        {
            RaycastHit2D placementHit = Physics2D.Raycast(worldMousePosition, Vector2.zero, 100f, placementLayer);
            if (placementHit && BattleController.instance.currentOrder == BattleController.TurnOrder.playerActive)
            {
                CardPlacePoint selectedPoint = placementHit.collider.GetComponent<CardPlacePoint>();
                CardPlacePoint bestFrame = FindBestFrame();
                if (selectedPoint.activeCard == null && selectedPoint.isPlayerPoint)
                {
                    if (BattleController.instance.playerMana >= manaCost && bestFrame != null)
                    {
                        selectedPoint.activeCard = this;
                        assignedPlace = selectedPoint;
                        MoveToPoint(selectedPoint.transform.position, Quaternion.identity);
                        isHand = false;
                        isSelected = false;
                        if (assignedPlace != null)
                        {
                            assignedPlace.activeCard = null;
                        }
                        PlaceCardAtFrame(bestFrame);

                        handController.RemoveCardFromHand(this);
                        BattleController.instance.SpendPlayerMana(manaCost);
                    }
                    else
                    {
                        ReturnToHand();

                        UiController.instance.ShowManaWarning();
                    }
                }
                else
                {
                    ReturnToHand();
                }
            }
            else
            {
                ReturnToHand();
            }
        }
    }
    private CardPlacePoint FindBestFrame()
    {
        foreach (var frame in allFrames)
        {
            if (frame.activeCard == null && frame.isPlayerPoint)
            {
                return frame; 
            }
        }
        return null; 
    }

    private void PlaceCardAtFrame(CardPlacePoint frame)
    {
        frame.activeCard = this;
        assignedPlace = frame;

        MoveToPoint(frame.transform.position, Quaternion.identity);

        isHand = false;
        isSelected = false;

        handController.RemoveCardFromHand(this);
    }

    public void GetDamage(int damageAmount)
    {
        animator.SetTrigger("CardAttack");
        
        health -= damageAmount;

        StartCoroutine(CheckHealthAfterGetDamage());

        UpdateCardDisplay();
    }

    IEnumerator CheckHealthAfterGetDamage()
    {
        yield return new WaitForSeconds(.3f);
        if (health <= 0)
        {
            health = 0;

            Destroy(gameObject);
        }
    }
    
    public void UpdateCardDisplay()
    {
        manaCostText.text = manaCost.ToString();
        attackPowerText.text = attackPower.ToString();
        healthText.text = health.ToString();
    }
}
