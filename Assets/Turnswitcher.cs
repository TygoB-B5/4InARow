using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnswitcher : MonoBehaviour
{
    public int Change(int turn_)
    {
        if (turn_ == 1)
        {
            turn_ = 2;
        }
        else
        {
            turn_ = 1;
        }
        return turn_;
    }
}
