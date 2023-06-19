using Args;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : MonoBehaviour
{
    public static event EventHandler<IntegerArgs> OnEating;
    public int NumberOfCultists { get { return _numberOfCultists; } }

    public int amountToEat = 1;
    private int _totalAmountToEat;
    private int _numberOfCultists = 0;

    private void Start()
    {
        _totalAmountToEat = amountToEat * _numberOfCultists;
    }

    private void OnEnable()
    {
        CultManager.OnTimeToEat += Eat;
        CultManager.OnChangingCultists += CultistAmountChanged;
    }

    private void OnDisable()
    {
        CultManager.OnTimeToEat -= Eat;
        CultManager.OnChangingCultists -= CultistAmountChanged;
    }

    public void Eat()
    {
        OnEating?.Invoke(this, new IntegerArgs { amount = amountToEat });
    }

    private void CultistAmountChanged()
    {
        _numberOfCultists = CultManager.NumberOfCultists;
    }


    private void JobAssignment(object sender, IntegerArgs args)
    {

    }
}
