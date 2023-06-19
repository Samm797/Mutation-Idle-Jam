using System;
using UnityEngine;
using Args;

public class Food : MonoBehaviour
{
    public static event Action OnEmpty;
    public static int totalFood = 5;


    private void OnEnable()
    {
        Cultist.OnEating += RemoveFood;
        Farmer.OnFoodAdded += AddFood;
    }
    private void OnDisable()
    {
        Cultist.OnEating -= RemoveFood;
        Farmer.OnFoodAdded -= AddFood;
    }

    private void AddFood(object sender, IntegerArgs e)
    {
        totalFood += e.amount;
    }

    private void RemoveFood(object sender, IntegerArgs e)
    {
        totalFood -= e.amount;

        if (totalFood <= 0)
        {
            totalFood = 0;
            OnEmpty?.Invoke();
        }
    }
}
