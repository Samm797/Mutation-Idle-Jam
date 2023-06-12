using UnityEngine;

public class Damage : MonoBehaviour
{
    public float Amount { get { return _amount; } set { _amount = value; } }
    [SerializeField] private float _amount; 

}
