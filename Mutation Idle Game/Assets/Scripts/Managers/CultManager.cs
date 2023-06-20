using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;
using System;
using Unity.VisualScripting;

public class CultManager : MonoBehaviour
{
    public static event Action OnTimeToEat;
    public static event Action OnChangingCultists;
    public static event Action OnChangingFarmers;
    public static event Action OnChangingArcheologists;
    public static float EatingInterval = 10f;
    public static float CultistSpawnInterval = 20f;

    public static int NumberOfCultists;
    public static int NumberOfFarmers;
    public static int NumberOfArchaeologists;

    private bool _cultistEating, _cultistSpawning = false;

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
            _cultistEating = false;
            return;
        }

        CheckEating();

    }

    private void CheckSpawning()
    {
        if (!_cultistSpawning)
        {
            StartCoroutine(AddCultistRoutine());
        }
    }
    public void AddCultist()
    {
        NumberOfCultists++;
        Debug.Log($"AddCultist called! Total cultists: {NumberOfCultists}");

        // Alert that a new townsfolk has been added
        OnChangingCultists?.Invoke();
    }

    private IEnumerator AddCultistRoutine()
    {
        _cultistSpawning = true;
        while (_cultistSpawning)
        {
            AddCultist();
            yield return new WaitForSeconds(CultistSpawnInterval);
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

    private void CheckEating()
    {
        if (!_cultistEating)
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
        _cultistEating = true;
        while (_cultistEating)
        {
            yield return new WaitForSeconds(EatingInterval);
            TimeToEat();
        }
    } 

    private void EmptyFoodStores()
    {
        _cultistSpawning = false;
    }

    private void AddFarmer()
    {
        if ((NumberOfFarmers + NumberOfArchaeologists) == NumberOfCultists)
        {
            Debug.Log("No farmer added. You need more cultists first!");
            return;
        }

        NumberOfFarmers++;

        OnChangingFarmers?.Invoke();
    }

    private void RemoveFarmer()
    {
        NumberOfFarmers--;

        if (NumberOfFarmers < 0)
        {
            NumberOfFarmers = 0;
            return;
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

    public void AssignJob(int ID)
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

    public void UnassignJob(int ID)
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
