using System;
using UnityEngine;
using Args;

public class Food : MonoBehaviour
{
    public static event Action OnEmpty;
    public static int totalFood;


    private void OnEnable()
    {
        Townsfolk.OnEating += Eat;
        //Farmer.OnFoodAdded += AddFood;
    }
    private void OnDisable()
    {
        Townsfolk.OnEating -= Eat;
        //Farmer.OnFoodAdded -= AddFood;
    }

    private void AddFood(object sender, IntegerArgs e)
    {
        totalFood += e.amount;
    }


    private void Eat(object sender, IntegerArgs e)
    {
        totalFood -= e.amount;

        if (totalFood <= 0)
        {
            totalFood = 0;
            OnEmpty?.Invoke();
        }
    }
}
