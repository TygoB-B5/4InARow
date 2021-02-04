using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInsert : MonoBehaviour
{
    public float lagBehindTime;

    private float xMousePosition;
    private Transform coinHolder;
    public SpriteRenderer[] coins;
    public Controller controller;
    public bool hasWon = false;

    void Start()
    {
        
        coinHolder = GetComponent<Transform>();
    }

    public void GetxInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        xMousePosition = ray.origin.x;
    }

    public void MoveCoin()
    {
        Vector3 coinPosition = new Vector3(xMousePosition, transform.position.y, transform.position.z);
        coinPosition = Vector3.Lerp(coinPosition, coinHolder.position, lagBehindTime);
        coinHolder.transform.position = new Vector3(coinPosition.x, coinPosition.y, coinPosition.z);
    }

    public void ShowTurnColor()
    {
        if (hasWon == true)
        {
            coins[0].enabled = false;
            coins[1].enabled = false;
        }

        if (controller.turn == 2 && hasWon == false)
        {
            coins[0].enabled = false;
            coins[1].enabled = true;
        }
        else if (hasWon == false)
        {
            coins[0].enabled = true;
            coins[1].enabled = false;
        }
    }


    public int GetInsertPositionConvert(int insertPosition)
    {
        xMousePosition = xMousePosition + 0.5f;
        if (xMousePosition >= 0 && xMousePosition <= 7)
        {
                insertPosition = (int)xMousePosition;
                return insertPosition;
        }
        return Random.Range(0, 6);
    }
}
