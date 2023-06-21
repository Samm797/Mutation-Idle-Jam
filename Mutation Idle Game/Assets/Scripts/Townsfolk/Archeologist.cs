using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;

public class Archeologist : MonoBehaviour
{
    public static event EventHandler<IntegerArgs> OnMaterialsAdded;

    public int amountToGather = 1;
    private int _numberOfArcheologists;

    private bool _gatherRoutineActive;

    private void Start()
    {
        _numberOfArcheologists = CultManager.NumberOfArchaeologists;
        _gatherRoutineActive = false;
    }

    private void Update()
    {
        if (_numberOfArcheologists <= 0) return;

        CheckGatherMaterials();
    }

    private void OnEnable()
    {
        CultManager.OnChangingArcheologists += ArcheologistAmountChanged;
    }

    private void OnDisable()
    {
        CultManager.OnChangingArcheologists -= ArcheologistAmountChanged;
    }

    private void CheckGatherMaterials()
    {
        if (!_gatherRoutineActive)
        {
            StartCoroutine(GatherMaterialsRoutine());
        }
    }

    private IEnumerator GatherMaterialsRoutine()
    {
        _gatherRoutineActive = true;
        while (_gatherRoutineActive)
        {
            yield return new WaitForSeconds(3);
            GatherMaterials();
        }
    }

    private void GatherMaterials()
    {
        OnMaterialsAdded?.Invoke(this, new IntegerArgs { amount = ( amountToGather * _numberOfArcheologists ) });
    }

    private void ArcheologistAmountChanged()
    {
        _numberOfArcheologists = CultManager.NumberOfArchaeologists;

        if (_numberOfArcheologists == 0)
        {
            _gatherRoutineActive = false;
        }
    }
}
