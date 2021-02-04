using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonscript : MonoBehaviour
{
    public Win win;

    // Update is called once per frame
    public void ResetGame_()
    {
        win.ResetGame();
    }
}
