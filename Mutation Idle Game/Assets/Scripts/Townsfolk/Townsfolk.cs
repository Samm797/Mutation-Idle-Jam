using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;

public class Townsfolk : MonoBehaviour
{
    private struct Job
    {
        public Transform jobSite;
        public string name;
        public string collectible;
        public int amountCollected;

        public Job(string name, Transform jobSite, string collectible, int amountCollected)
        {
            this.name = name;
            this.jobSite = jobSite;
            this.collectible = collectible;
            this.amountCollected = amountCollected;
        }
    }
    
    public static event EventHandler<IntegerArgs> OnEating;
    public static bool IsAtHomeBase;

    // Defines how the Townfolk interacts
    private SpriteRenderer _rend;
    public Sprite currentOutfit;

    // Survival
    public int amountToEat;

    // Corruption
    private int _maxCorruption = 100;
    private int _currentCorruption;

    // Mutations 
    [SerializeField] private List<Mutation> _currentMutations = new List<Mutation>();

    // Jobs
    /// <summary>
    /// 0 = Townsfolk; 1 = farmer; 2 = archeologist; 3 = priest
    /// </summary>
    private int _jobID;
    [SerializeField] private Job _currentJob;
    private Job _farmer, _archeologist, _priest;

    // Pathfinding
    private AIPath _myPath;
    private AIDestinationSetter _myDestinationSetter;
    public Transform homeBase, farm, mine, church;
    public Transform sacrificePit, theDepths;
    private Rigidbody2D _rb;
    private float _distanceToBase;

    private void Awake()
    {
        _rend = GetComponentInChildren<SpriteRenderer>();
        _rb = GetComponentInChildren<Rigidbody2D>();
        _myPath = GetComponent<AIPath>();
        _myDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void Start()
    {
        amountToEat = 1;
        _currentCorruption = 0;

        _rend.sprite = currentOutfit;

        // Initializing the jobs
        _farmer = new Job("Farmer", farm, "Food", 1);
        _archeologist = new Job("Archeologist", mine, "Gold", 1);
        _priest = new Job("Priest", church, "Corruption", 1);

    }

    private void OnEnable()
    {
        PlayerController.OnMovingTownsfolk += StartMoving;
        PlayerController.OnStoppingTownsfolk += StopMoving;
        PlayerController.OnSettingDestination += SetDestination;
    }

    private void OnDisable()
    {
        PlayerController.OnMovingTownsfolk -= StartMoving;
        PlayerController.OnStoppingTownsfolk -= StopMoving;
        PlayerController.OnSettingDestination -= SetDestination;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _myDestinationSetter.target.position);

        if (distance <= 0.2)
        {
            // We have reached our destination
            // Set destination=true
            // ReturnHome
                // Once returned home
                // Do job
        }
    }

    private void StartMoving()
    {
        _myPath.canMove = true;
    }

    private void StopMoving()
    {
        _myPath.canMove = false;
    }

    private void SetDestination(object sender, TransformArgs args)
    {
        _myDestinationSetter.target = args.transform;
    }

    private void ReturnHome()
    {
        _myDestinationSetter.target = homeBase;
    }

    public void Eat()
    {
        StartCoroutine(EatRoutine());
    }

    private IEnumerator EatRoutine()
    {
        OnEating?.Invoke(this, new IntegerArgs { amount = amountToEat });
        yield return new WaitForSeconds(CultManager.EatingInterval);
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

    /// <param name="jobId">0 = Townsfolk; 1 = Farmer; 2 = Archeologist; 3 = Priest</param>
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
                // Farmer
                _farmer = _currentJob;
                break;
            case 2:
                // Archeologist
                break;
            case 3:
                // Priest
                break;
        }
    }

}
