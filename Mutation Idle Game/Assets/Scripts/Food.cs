using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int AmountRefreshed { get { return _amountRefreshed; } }
    public int totalFood;

    private int _amountRefreshed;

    private void Awake()
    {
        _amountRefreshed = 50;
    }

    public void ConsumeFood(int amount)
    {
        totalFood -= amount;
    }

    public void GetFood(int amount)
    {
        totalFood += amount;
    }

}
