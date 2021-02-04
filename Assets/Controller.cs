using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public CoinInsert coinInsert;
    public Cordcalculator cordCalculator;
    public Turnswitcher turnSwitcher;
    public Spawncoin spawnCoin;
    public Wintest winTest;
    public Win win;

    public int insertPosition;
    public int turn;
    public int[,] cords = new int[7, 6];

    public float turnWaitTime;
    public bool hasWon = false;

    private float t;

    void Start()
    {
        //1 = red 2 = yellow
        //be able to make turn without having to wait for "t"
        t = turnWaitTime;
        turn = 2;
    }

    void Update()
    {
        coinInsert.GetxInput();
        coinInsert.MoveCoin();
        coinInsert.ShowTurnColor();
        Timer();

        Insert();
    }

    void Timer()
    {
        t = t + 1 * Time.deltaTime;
    }

    void Insert()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //1 second timer
            if (t >= turnWaitTime && hasWon == false)
            {
                GetDetails();
                t = 0;
                winTest.WinTest();
            }
        }
    }

    void GetDetails()
    {
        insertPosition = coinInsert.GetInsertPositionConvert(insertPosition);
        if (cords[insertPosition, 5] == 0)
        {
            turn = turnSwitcher.Change(turn);
            cords = cordCalculator.CalculateInsert(cords);
            spawnCoin.SpawnCoin();
        }
    }

    public void Won()
    {
        hasWon = true;
        win.Win_();
        coinInsert.hasWon = true;
        Debug.Log("win");
    }
}
