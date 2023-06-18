using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Args;

public class PlayerController : MonoBehaviour
{
    // Stops and starts the movement of the Townsfolk
    public static event Action OnMovingTownsfolk;
    public static event Action OnStoppingTownsfolk;

    // Sets the destination for the Townsfolk
    public static event EventHandler<TransformArgs> OnSettingDestination;

    
    private List<Townsfolk> _townsfolks = new List<Townsfolk>();

    private int _maxTownsfolk;

    private Townsfolk _currentTarget, _previousTarget;
    private Camera _camera;
    private RaycastHit _hitInfo;


    public Transform homeBase, mine;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _maxTownsfolk = 30;
    }

    private void Update()
    {

    }

    private void SelectTownsfolk(Townsfolk target)
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

    public void AddNewRecruit(Townsfolk newRecruit)
    {
        if (_townsfolks.Count >= _maxTownsfolk)
        {
            Debug.Log("Too many townsfolk.");
        }

        Townsfolk clone = newRecruit;
        _townsfolks.Add(clone);
    }

    public void RecruitRemoved(Townsfolk toBeRemoved)
    {
        if (_townsfolks.Contains(toBeRemoved))
        {
            _townsfolks.Remove(toBeRemoved);
        }
    }
}
