using UnityEngine;

[CreateAssetMenu(menuName = "Relics")]
public class Relic : ScriptableObject
{
    public string relicName;
    public Sprite image;
    public int value;
    public Mutation mutation;
    public int corruptionAmount;
    public int chance;
}
