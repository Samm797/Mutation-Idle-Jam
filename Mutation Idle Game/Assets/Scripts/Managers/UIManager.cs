using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMesh foodText;
    private int _foodCount;

    private void OnEnable()
    {
        _foodCount = Food.totalFood;
        Food.OnFoodAdded += IncrementFoodCount;
        Townsfolk.OnEating += DecrementFoodCount;
    }

    private void OnDisable()
    {
        Food.OnFoodAdded -= IncrementFoodCount;
        Townsfolk.OnEating -= DecrementFoodCount;
    }

    private void IncrementFoodCount(object sender, Food.OnFoodChangedArgs args)
    {
        _foodCount += args.amount;
        Debug.Log($"Food: {_foodCount}");
        // foodText.text = $"Food: {_foodCount}";
    }

    public void DecrementFoodCount(object sender, Townsfolk.OnFoodChangesArgs args)
    {
        _foodCount -= args.amount;
        Debug.Log($"Food: {_foodCount}");
        //foodText.text = $"Food: {_foodCount}";
    }
}
