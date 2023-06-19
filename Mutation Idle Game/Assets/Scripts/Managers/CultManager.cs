using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;
using System;

public class CultManager : MonoBehaviour
{
    public static event Action OnTimeToEat;
    public static event Action OnChangingCultists;
    public static event Action OnChangingFarmers;
    public static event Action OnChangingArcheologists;
    public static float EatingInterval = 10f;
    public static float TownsfolkInterval = 20f;

    public static int NumberOfCultists;
    public static int NumberOfFarmers;
    public static int NumberOfArchaeologists;
    public static int JobID;

    [SerializeField] private GameObject _townsfolkContainer;
    [SerializeField] private GameObject _cultistPrefab;
    [SerializeField] private GameObject _farmerPrefab;
    [SerializeField] private GameObject _archeologistPrefab;

    // Jobs
    /// <summary>
    /// 0 = Cultist; 1 = Farmer; 2 = Archeologist; 3 = Priest
    /// </summary>
    private int _jobID;


    public Transform homeBase;


    private bool _townsfolkEating, _townsfolkSpawning = false;

    private void OnEnable()
    {
        // Subscribe for AddTownsfolk
        Food.OnEmpty += EmptyFoodStores;
    }

    private void OnDisable()
    {
        // Unsubscribe for AddTownsfolk
        Food.OnEmpty -= EmptyFoodStores;
    }

    private void Update()
    {
        CheckSpawning();
        
        if (NumberOfCultists <= 0)
        {
            _townsfolkEating = false;
            return;
        }

        CheckEating();

    }

    private void CheckSpawning()
    {
        if (!_townsfolkSpawning && Food.totalFood >= NumberOfCultists)
        {
            StartCoroutine(AddCultistRoutine());
        }
    }
    public void AddCultist()
    {
        NumberOfCultists++;

        // Alert that a new townsfolk has been added
        OnChangingCultists?.Invoke();
    }

    private IEnumerator AddCultistRoutine()
    {
        _townsfolkSpawning = true;
        while (_townsfolkSpawning)
        {
            AddCultist();
            yield return new WaitForSeconds(TownsfolkInterval);
        }
    }

    private void CheckEating()
    {
        if (!_townsfolkEating)
        {
            StartCoroutine(TimeToEatRoutine());
        }
    }

    private void TimeToEat()
    {
        OnTimeToEat?.Invoke();
    }

    private IEnumerator TimeToEatRoutine()
    {
        _townsfolkEating = true;
        while (_townsfolkEating)
        {
            TimeToEat();
            yield return new WaitForSeconds(EatingInterval);
        }
    } 

    private void RemoveCultist()
    {
        NumberOfCultists--;

        if (NumberOfCultists <= 0)
        {
            NumberOfCultists = 0;
        }

        OnChangingCultists?.Invoke();
    }
    private void EmptyFoodStores()
    {
        _townsfolkSpawning = false;
    }

    private void AddFarmer()
    {
        NumberOfFarmers++;
        OnChangingFarmers?.Invoke();
    }

    private void RemoveFarmer()
    {
        NumberOfFarmers--;
        if (NumberOfFarmers <= 0)
        {
            NumberOfFarmers = 0;
        }

        OnChangingFarmers?.Invoke();
    }

    private void AddArcheologist()
    {
        NumberOfArchaeologists++;
        OnChangingArcheologists?.Invoke();
    }

    private void RemoveArcheologist()
    {
        NumberOfArchaeologists--;
        if (NumberOfArchaeologists <= 0)
        {
            NumberOfArchaeologists = 0;
        }

        OnChangingArcheologists?.Invoke();
    }

    private void AssignJob(int ID)
    {
        if (ID <= 0 || ID >= 4) return;

        switch (ID)
        {
            case 1:
                AddFarmer();
                break;
            case 2:
                AddArcheologist();
                break;
            case 3:
                // AddPriest(); // If there's time
                break;
            default:
                Debug.LogError("Default case reached in AssignJob on the CultManager!");
                break;
        }
    }

    private void UnassignJob(int ID)
    {
        if (ID <= 0 || ID >= 4) return;

        switch (ID)
        {
            case 1:
                RemoveFarmer();
                break;
            case 2:
                RemoveArcheologist();
                break;
            case 3:
                // RemovePriest(); // If there's time
                break;
            default:
                Debug.LogError("Default case reached in AssignJob on the CultManager!");
                break;
        }
    }
}
