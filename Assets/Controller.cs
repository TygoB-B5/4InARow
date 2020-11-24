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

    public int insertPosition;
    public int turn;
    public int[,] cords = new int[7, 6];

    public float turnWaitTime;

    private float t;

    void Start()
    {
        //be able to make turn without having to wait for "t"
        t = turnWaitTime;
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
            if (t >= turnWaitTime)
            {
                GetDetails();
                spawnCoin.SpawnCoin();
                t = 0;
                winTest.WinTest();
            }
        }
    }

    void GetDetails()
    {
        turn = turnSwitcher.Change(turn);
        insertPosition = coinInsert.GetInsertPositionConvert(insertPosition);
        cords = cordCalculator.CalculateInsert(cords);
    }
}
