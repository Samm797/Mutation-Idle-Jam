using Pathfinding;
using System;
using UnityEngine;
using Args;

/// <summary>
/// The physical representation on the world map.
/// </summary>
public class CultistGFX : MonoBehaviour
{
    // Defines how the Townfolk interacts
    private SpriteRenderer _rend;
    public Sprite currentOutfit;

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
        _rend.sprite = currentOutfit;
    }

    private void OnEnable()
    {
        PlayerController.OnSettingDestination += SetDestination;
    }

    private void OnDisable()
    {
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

    private void SetDestination(object sender, TransformArgs args)
    {
        _myDestinationSetter.target = args.transform;
    }

    private void ReturnHome()
    {
        _myDestinationSetter.target = homeBase;
    }
}
