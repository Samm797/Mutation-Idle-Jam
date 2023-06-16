using System.Collections.Generic;
using UnityEngine;

public class Townsfolk : MonoBehaviour
{
    // Defines how the Townfolk interacts
    private int _jobID;
    private SpriteRenderer _rend;
    public Sprite currentOutfit;

    // Survival
    private int _amountToEat;

    // Corruption
    private int _maxCorruption = 100;
    private int _currentCorruption;

    // Mutations
    [SerializeField] private List<Mutation> _currentMutations = new List<Mutation>();

    // Communication with other scripts 
    // Will shift to an observer pattern if time allows 
    private Food _food;

    private void Awake()
    {
        _food = GameObject.Find("Player").GetComponent<Food>();

        _rend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _amountToEat = 1;
        _currentCorruption = 0;

        _rend.sprite = currentOutfit;
    }

    public void Eat()
    {
        _food.ConsumeFood(_amountToEat);
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
                // Priest
                break;
            case 3:
                // Farmer
                break;
        }
    }
}
