using System;
using System.Collections.Generic;
using UnityEngine;

public class Townsfolk : MonoBehaviour
{
    public static event EventHandler<OnFoodChangesArgs> OnEating;

    public class OnFoodChangesArgs : EventArgs
    {
        public int amount;
    }

    // Defines how the Townfolk interacts
    private int _jobID;
    private SpriteRenderer _rend;
    public Sprite currentOutfit;

    // Survival
    public int amountToEat;

    // Corruption
    private int _maxCorruption = 100;
    private int _currentCorruption;

    // Mutations
    [SerializeField] private List<Mutation> _currentMutations = new List<Mutation>();


    private void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        amountToEat = 1;
        _currentCorruption = 0;

        _rend.sprite = currentOutfit;
    }
    private void Update()
    {

    }

    public void Eat()
    {
        OnEating?.Invoke(this, new OnFoodChangesArgs { amount = amountToEat });
    }

    public void AddCorruption(int amount)
    {
        _currentCorruption += amount;

        if (_currentCorruption > _maxCorruption)
        {
            _currentCorruption = _maxCorruption;
            FullyCorrupted();
        }
    }

    public void FullyCorrupted()
    {
        // Make them a permanent fixture somewhere? 
        // Will figure this out
        Debug.Log("Total corruption reached!");
    }

    public void ShowInfo()
    {
        Debug.Log("Showing information!");
    }

    public void HideInfo()
    {
        Debug.Log("Hiding information!");
    }

    /// <param name="jobId">0 = Townsfolk; 1 = Archaeologist; 2 = Priest; 3 = Farmer</param>
    public void AssignJob(int jobId)
    {
        this._jobID = jobId;
        switch (_jobID) 
        {
            default:
                Debug.LogError("Default case reached in AssignJob");
                break;
            case 0:
                // Townsfolk - nothing needed here 
                break;
            case 1:
                // Archaeologist
                break;
            case 2:
                // Farmer
                break;
            case 3:
                // Priest
                break;
        }
    }
}
