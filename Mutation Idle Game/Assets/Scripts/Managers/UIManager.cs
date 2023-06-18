using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;

public class UIManager : MonoBehaviour
{
    public TextMesh foodText;
    private int _foodCount;

    private void OnEnable()
    {
        _foodCount = Food.totalFood;
        //Farmer.OnFoodAdded += IncrementFoodCount;
        Townsfolk.OnEating += DecrementFoodCount;
        Food.OnEmpty += EmptyFoodStoreAlert;
    }

    private void OnDisable()
    {
        //Farmer.OnFoodAdded -= IncrementFoodCount;
        Townsfolk.OnEating -= DecrementFoodCount;
        Food.OnEmpty -= EmptyFoodStoreAlert;
    }

    private void IncrementFoodCount(object sender, IntegerArgs args)
    {
        _foodCount += args.amount;
        Debug.Log($"Food: {_foodCount}");
        // foodText.text = $"Food: {_foodCount}";
    }

    public void DecrementFoodCount(object sender, IntegerArgs args)
    {
        _foodCount -= args.amount;
        Debug.Log($"Food: {_foodCount}");
        //foodText.text = $"Food: {_foodCount}";
    }

    private void EmptyFoodStoreAlert()
    {
        Debug.Log("There is no food left! Please assign more cultists to farming!");
    }
}
