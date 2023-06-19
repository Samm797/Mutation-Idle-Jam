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
        Farmer.OnFoodAdded += FoodChanged;
        Cultist.OnEating += FoodChanged;
        Food.OnEmpty += EmptyFoodStoreAlert;
    }

    private void OnDisable()
    {
        Farmer.OnFoodAdded -= FoodChanged;
        Cultist.OnEating -= FoodChanged;
        Food.OnEmpty -= EmptyFoodStoreAlert;
    }

    private void FoodChanged(object sender, IntegerArgs args)
    {
        _foodCount = Food.totalFood;
        Debug.Log($"Food: {_foodCount}");
        // foodText.text = $"Food: {_foodCount}";
    }

    private void EmptyFoodStoreAlert()
    {
        Debug.Log("There is no food left! Please assign more cultists to farming!");
    }
}
