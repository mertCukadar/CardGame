using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject cardPrefab;
    public Vector2 cardposition1 = new Vector2(0, -2.5f);
    public Vector2 cardposition2 = new Vector2(-3, -2.5f);
    public Vector2 cardposition3 = new Vector2(3, -2.5f);

    private List<GameObject> cards = new List<GameObject>();
    private List<Vector2> targetPositions = new List<Vector2>();

    public bool dealCards = false;

    public float moveSpeed = 100.0f;

    public float deltaTime = 0.1f;

    void Start()
    {
        targetPositions.Add(cardposition1);
        targetPositions.Add(cardposition2);
        targetPositions.Add(cardposition3);

    }

    void Update()
    {
        if (dealCards)
        {
            dealCardsToPlayers();   
        }
      
    
        
    }

    void CreateCardObject()
    {
        if (cardPrefab != null)
        {
            GameObject card = Instantiate(cardPrefab, this.transform.position - new Vector3(0, 0, -4), Quaternion.identity);
            card.transform.localScale = new Vector3(0.2074598f, 0.2111842f, 0.1225f);
            card.AddComponent<BoxCollider2D>();

            cards.Add(card);
        }
        else
        {
            Debug.LogError("Card Prefab is not assigned! Please assign it in the inspector.");
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Card Clicked!");
        shuffleCards();
        dealCards = true;

    }

    private void dealCardsToPlayers()
    {   
        for (int i = 0; i < cards.Count; i++)
            {
                GameObject card = cards[i];
                Vector2 targetPosition = targetPositions[i];
                card.transform.position = Vector3.MoveTowards(card.transform.position, targetPosition, moveSpeed * deltaTime);
                Debug.Log($"Card {i} position: {card.transform.position}");
            }
    }

    private void shuffleCards()
    {
        cards.Clear();
        for (int i = 0; i < 3; i++)
        {
            CreateCardObject();
        }

    }
  
}
