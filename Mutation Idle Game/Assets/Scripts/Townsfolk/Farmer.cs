using Args;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public static event EventHandler<IntegerArgs> OnFoodAdded;

    public int amountToGather = 1;
    private int _totalAmountToGather;
    private int _numberOfFarmers = 0;

    private void OnEnable()
    {
        CultManager.OnChangingFarmers += FarmerAmountChanged;
    }

    private void OnDisable()
    {
        CultManager.OnChangingFarmers -= FarmerAmountChanged;
    }

    private void GatherFood()
    {
        OnFoodAdded?.Invoke(this, new IntegerArgs { amount = amountToGather });
    }

    private void FarmerAmountChanged()
    {
        _numberOfFarmers = CultManager.NumberOfFarmers;
    }
}
