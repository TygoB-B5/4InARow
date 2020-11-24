using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawncoin : MonoBehaviour
{
    public GameObject[] coinPrefab;
    public Controller controller;

    public void SpawnCoin()
    {
        Vector3 spawnCords = new Vector3(controller.insertPosition, 5, 0);
        Instantiate(coinPrefab[controller.turn - 1], spawnCords, transform.rotation);
    }
}
