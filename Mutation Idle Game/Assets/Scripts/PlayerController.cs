using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;

public class PlayerController : MonoBehaviour
{
    // Sets the destination for the Townsfolk
    public static event EventHandler<TransformArgs> OnSettingDestination;

    public static event EventHandler<IntegerArgs> OnSettingJob;
    
    private CultistGFX _currentTarget, _previousTarget;
    private Camera _camera;
    private RaycastHit _hitInfo;


    public Transform homeBase, mine;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void SelectTownsfolk(CultistGFX target)
    {
        if (_currentTarget == null)
        {
            _currentTarget = target;
            //_currentTarget.ShowInfo();
        }
        else
        {
            _previousTarget = _currentTarget;
            //_previousTarget.HideInfo();
            _previousTarget = null;

            _currentTarget = target;
            //_currentTarget.ShowInfo();
        }
    }
}
