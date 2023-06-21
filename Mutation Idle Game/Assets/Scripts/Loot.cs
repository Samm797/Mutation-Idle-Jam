using Args;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Loot : MonoBehaviour
{
    public static event EventHandler<RelicArgs> OnRelicGained;
    public static event Action FirstRelicFound;


    public List<Relic> totalRelics = new List<Relic>();
    private List<Relic> potentialDrops = new List<Relic>();
    private List<Relic> droppedRelics = new List<Relic>();
    private Relic _rarestRelic;


    private void Update()
    {
        if (droppedRelics.Count <= 0) return;

        if (droppedRelics.Count == 1)
        {
            FirstRelicFound?.Invoke();
        }
    }

    public Relic GetRandomRelic()
    {
        if (potentialDrops.Count > 0)
        {
            potentialDrops.Clear();
        }

        _rarestRelic = null;

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

        // If no potential drops
        if (potentialDrops.Count == 0)
        {
            return null;
        }

        // If a single potential drop
        else if (potentialDrops.Count == 1)
        {
            // Add the relic to the dropped relics list
            droppedRelics.Add(potentialDrops[0]);
            
            // Invoke the OnRelicGained event
            OnRelicGained?.Invoke(this, new RelicArgs { relic = potentialDrops[0] });
            
            // Return the first item in the list
            return potentialDrops[0];
        } 
        
        // If multiple potential drops
        else
        {
            // Will always be the highest
            int lowestChance = 100;

            // For every item in the potential drop list 
            for (int i = 0;i < potentialDrops.Count;i++)
            {
                // If the chance is lower than the current lowest chance (at the start will be 100%)
                if (lowestChance >= potentialDrops[i].chance)
                {
                    // The new lowest chance is the lowest drop %age
                    lowestChance = potentialDrops[i].chance;
                    // The rarest relic is now the lowest drop %age
                    _rarestRelic = potentialDrops[i];
                }
            }
        }

        // Add the relic to the dropped relic list
        droppedRelics.Add(_rarestRelic);

        // Invoke the OnRelicGained event 
        OnRelicGained?.Invoke(this, new RelicArgs { relic = _rarestRelic });
        
        // Return the relic with the lowest drop %age
        return _rarestRelic;
    }
}
