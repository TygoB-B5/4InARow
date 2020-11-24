using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cordcalculator : MonoBehaviour
{
    public Controller controller;
    private bool notSet = true;

    public int[,] CalculateInsert(int[,] cords)
    {
        for (int i = 0; i <= 5; i++)
        {
            if (notSet == true)
            {
                if (cords[controller.insertPosition, i] == 0)
                {
                    cords[controller.insertPosition, i] = controller.turn;
                    notSet = false;
                }
            }
        }
        notSet = true;
        return cords;
    } 
}
