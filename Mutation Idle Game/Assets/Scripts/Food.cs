using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Static so the other classes can utilize it OnEnable
    public static event EventHandler<OnFoodChangedArgs> OnFoodAdded;
    public static int totalFood;

    /// <summary>
    /// Arg used to pass a reference to an int through an event
    /// </summary>
    public class OnFoodChangedArgs: EventArgs
    {
        public int amount;
    }

    private void OnEnable()
    {
        Townsfolk.OnEating += Townsfolk_OnEating;
    }

    private void OnDisable()
    {
        Townsfolk.OnEating -= Townsfolk_OnEating;
    }

    private void Townsfolk_OnEating(object sender, Townsfolk.OnFoodChangesArgs e)
    {
        totalFood -= e.amount;
    }

    public void AddFood(int amount)
    {
        totalFood += amount;
        // If the event is not null, invoke it
            // Same as writing if (OnFoodAdded != null)
        OnFoodAdded?.Invoke(this, new OnFoodChangedArgs { amount = amount });
    }
}
