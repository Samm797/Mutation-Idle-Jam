using UnityEngine;

public abstract class Mutation : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
