using UnityEngine;

[CreateAssetMenu(menuName = "Mutations/DamageMutations")]
public class DamageMutation : Mutation
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Damage>().Amount += amount;
    }
}
