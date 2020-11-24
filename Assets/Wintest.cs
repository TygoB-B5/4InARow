using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wintest : MonoBehaviour
{
    public Controller controller;
    private int fourrowX;
    private int fourrowY;
    private int fourrowDiag1;
    private int fourrowDiag2;

    int hordown;
    public void WinTest()
    {
        TestHorizontal();
        TestVertical();
        TestDiagonal1();
        TestDiagonal2();
    }

    void TestHorizontal()
    {
        fourrowX = 0;

        int[,] cords = controller.cords;
        for (int turn = 1; turn <= 2; turn++)
        {
            for (int switchrowLeft = 0; switchrowLeft <= 3; switchrowLeft++)
            {
                for (int uprow = 0; uprow <= 5; uprow++)
                {
                    fourrowX = 0;
                    for (int siderow = 0 + switchrowLeft; siderow <= 3 + switchrowLeft; siderow++)
                    {
                        if (cords[siderow, uprow] == turn)
                        {
                            fourrowX = fourrowX + 1;
                            if (fourrowX >= 4)
                            {
                                Win();
                            }
                        }
                        else
                        {
                            fourrowX = 0;
                        }
                    }
                }
            }
        }
    }

    void TestVertical()
    {
        fourrowY = 0;

        int[,] cords = controller.cords;
        for (int turn = 1; turn <= 2; turn++)
        {
            for (int siderow = 0; siderow <= 6; siderow++)
            {
                fourrowX = 0;
                for (int switchrowUp = 0; switchrowUp <= 5; switchrowUp++)
                {
                    if (cords[siderow, switchrowUp] == turn)
                    {
                        fourrowX = fourrowX + 1;
                        if (fourrowX >= 4)
                        {
                            Win();
                        }
                    }
                    else
                    {
                        fourrowX = 0;
                    }

                }
            }
        }
    }

    void TestDiagonal1()
    {
        fourrowDiag1 = 0;
        int[,] cords = controller.cords;
        for (int turn = 1; turn <= 2; turn++)
        {
            for (int siderow = 0; siderow <= 3; siderow++)
            {
                for (int uprow = 0; uprow <= 2; uprow++)
                {
                    fourrowDiag1 = 0;
                    for (int diagonal = 0; diagonal <= 3; diagonal++)
                    {
                        if (cords[diagonal + siderow, diagonal + uprow] == turn)
                        {
                            fourrowDiag1 = fourrowDiag1 + 1;
                            if (fourrowDiag1 >= 4)
                            {
                                Win();
                            }
                        }
                        else
                        {
                            fourrowDiag1 = 0;
                        }

                    }
                }
            }
        }
    }

    void TestDiagonal2()
    {

        fourrowDiag2 = 0;
        int[,] cords = controller.cords;
        for (int turn = 1; turn <= 2; turn++)
        {
            for (int siderow = 0; siderow <= 3; siderow++)
            {
                for (int uprow = -1; uprow <= 2; uprow++)
                {
                    fourrowDiag2 = 0;
                    
                    for (int diagonal = 6; diagonal <= 4; diagonal--)
                    {
                        hordown = uprow;
                        if (cords[hordown , diagonal] == turn)
                            {
                                fourrowDiag2 = fourrowDiag2 + 1;
                                if (fourrowDiag2 >= 4)
                                {
                                    Win();
                                }
                            }
                            else
                            {
                                fourrowDiag2 = 0;
                            }
                    }
                }
            }
        }
    }



    void Win()
    {
        Debug.Log("win");
    }
}
