using Args;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public static event EventHandler<IntegerArgs> OnFoodAdded;

    public int amountToGather = 1;
    private int _numberOfFarmers;

    private bool _gatherRoutineActive;

    private void Start()
    {
        _numberOfFarmers = CultManager.NumberOfFarmers;
        _gatherRoutineActive = false;
    }

    private void Update()
    {
        if (_numberOfFarmers <= 0) return;

        CheckGatherFood();
    }

    private void OnEnable()
    {
        CultManager.OnChangingFarmers += FarmerAmountChanged;
    }

    private void OnDisable()
    {
        CultManager.OnChangingFarmers -= FarmerAmountChanged;
    }

    private void CheckGatherFood()
    {
        if (!_gatherRoutineActive)
        {
            StartCoroutine(GatherFoodRoutine());
        }
    }

    private void GatherFood()
    {
        OnFoodAdded?.Invoke(this, new IntegerArgs { amount = (amountToGather * _numberOfFarmers)});
    }

    private IEnumerator GatherFoodRoutine()
    {
        _gatherRoutineActive = true;
        while (_gatherRoutineActive)
        {
            yield return new WaitForSeconds(3);
            GatherFood();
        }
    }

    private void FarmerAmountChanged()
    {
        _numberOfFarmers = CultManager.NumberOfFarmers;

        if (_numberOfFarmers == 0)
        {
            _gatherRoutineActive = false;
        }
    }
}
