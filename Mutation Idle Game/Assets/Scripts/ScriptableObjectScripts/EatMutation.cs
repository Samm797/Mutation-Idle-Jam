using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/EatMutations")]
public class EatMutation : Mutation
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Townsfolk>().amountToEat += amount;
    }
}
