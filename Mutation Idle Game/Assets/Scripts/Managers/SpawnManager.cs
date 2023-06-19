using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject cultistPrefab;
    public GameObject cultistContainer;
    public Transform homeBase;

    private void OnEnable()
    {
        CultManager.OnChangingCultists += SpawnInitialCultist;
    }

    private void OnDisable()
    {
        CultManager.OnChangingCultists -= SpawnInitialCultist;
    }

    private void SpawnInitialCultist()
    {
        GameObject cultistRepresentative = Instantiate(cultistPrefab, homeBase.position, Quaternion.identity, cultistContainer.transform);
        cultistRepresentative.GetComponent<AIDestinationSetter>().target = homeBase;
        CultManager.OnChangingCultists -= SpawnInitialCultist;
    }
}
