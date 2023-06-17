using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public List<Relic> totalRelics = new List<Relic>();
    private List<Relic> potentialDrops = new List<Relic>();
    private Relic _rarestRelic;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Relic loot = GetRandomRelic();
        }
    }

    public Relic GetRandomRelic()
    {
        if (potentialDrops.Count > 0)
        {
            potentialDrops.Clear();
        }

        // Get a random value from 1 - 100
        int randomPercent = Random.Range(1, 101);

        // Check each relic in the list
        for (int i = 0; i < totalRelics.Count; i++)
        {
            // If drop chance is below, add to the potentialDrops list
            if (randomPercent <= totalRelics[i].chance)
            {
                potentialDrops.Add(totalRelics[i]);
            }
        }

        if (potentialDrops.Count == 0)
        {
            return null;
        }
        else if (potentialDrops.Count == 1)
        {
            return potentialDrops[0];
        } else
        {
            int lowestChance = 100;

            for (int i = 0;i < potentialDrops.Count;i++)
            {
                if (lowestChance >= potentialDrops[i].chance)
                {
                    lowestChance = potentialDrops[i].chance;
                    _rarestRelic = potentialDrops[i];
                }
            }
        }

        return _rarestRelic;
    }
}
