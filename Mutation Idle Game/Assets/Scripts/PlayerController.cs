using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private List<Townsfolk> _townsfolks = new List<Townsfolk>();

    private int _maxTownsfolk;
    private Food _food;

    private Townsfolk _currentTarget, _previousTarget;
    private Camera _camera;
    private RaycastHit _hitInfo;

    private Townsfolk _townsfolk;

    private void Awake()
    {
        _food = GetComponent<Food>();
        _camera = Camera.main;
        _townsfolk = GameObject.Find("Townsfolk").GetComponent<Townsfolk>();
    }

    private void Start()
    {
        _maxTownsfolk = 30;
    }

    private void Update()
    {
        /*
        // Left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast( ray, out _hitInfo))
            {
                if (_hitInfo.collider.gameObject.GetComponent<Townsfolk>() == null)
                {
                    return;
                }

                Townsfolk newTarget = _hitInfo.collider.gameObject.GetComponent<Townsfolk>();

                SelectTownsfolk(newTarget);
            }
        }
        */
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _food.AddFood(2);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _townsfolk.Eat();
        }
    }

    private void SelectTownsfolk(Townsfolk target)
    {
        if (_currentTarget == null)
        {
            _currentTarget = target;
            _currentTarget.ShowInfo();
        }
        else
        {
            _previousTarget = _currentTarget;
            _previousTarget.HideInfo();
            _previousTarget = null;

            _currentTarget = target;
            _currentTarget.ShowInfo();
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
