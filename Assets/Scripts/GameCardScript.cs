using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCardScript : MonoBehaviour
{

    public GameObject Card;
    public Vector3 basePosition = new Vector3(4f, 5f , 0);

    public float moveSpeed = 10.0f;


    private bool collect = false;
    void Start()
    {
        if (Card == null){
            Card = GameObject.Find("card");
        }

    }

    void Update()
    {
        if (collect)
        {
            Vector3 targetPosition = Card.GetComponent<Card>().transform.position - new Vector3(0, 0, -4);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (this.transform.position == targetPosition)
            {
                Destroy(this.gameObject);
            }
        }
        
    }

    void OnMouseDown()
    {
        Debug.Log($"Card objects {this.name} Clicked!");
        collect = true;
        // change Card object's dealcards value to false
        Card.GetComponent<Card>().dealCards = false;

        
    }
}
