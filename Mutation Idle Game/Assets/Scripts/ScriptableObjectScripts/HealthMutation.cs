using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/HealthMutations")]
public class HealthMutation : Mutation
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<HealthSystem>().MaxHealth += amount;
    }
}
