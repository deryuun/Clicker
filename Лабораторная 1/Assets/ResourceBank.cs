using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBank : MonoBehaviour
{
    public readonly Dictionary<GameResources.GameResource, ObservableInt> dictionary = new Dictionary<GameResources.GameResource, ObservableInt>();
    public Dictionary<GameResources.GameResource, int> productionLevels = new Dictionary<GameResources.GameResource, int>();
    public void ChangeResource(GameResources.GameResource r, int v)
    {
        if (dictionary.ContainsKey(r))
        {
            dictionary[r].Value += v;
        }
        
    }
    public ObservableInt GetResource(GameResources.GameResource r)
    {
        return dictionary.ContainsKey(r) ? dictionary[r] : null;
    }

     public void ChangeProductionLevel(GameResources.GameResource prodLevelResource)
    {
        if (productionLevels.ContainsKey(prodLevelResource))
        {
            productionLevels[prodLevelResource]++;
        }
    }
    public int GetProductionLevel(GameResources.GameResource prodLevelResource)
    {
        return productionLevels.ContainsKey(prodLevelResource) ? productionLevels[prodLevelResource] : 0;
    }
 
    private bool IsProductionLevel(GameResources.GameResource resource)
    {
        switch (resource)
        {
            case GameResources.GameResource.HumansProdLvl:
            case GameResources.GameResource.FoodProdLvl:
            case GameResources.GameResource.WoodProdLvl:
            case GameResources.GameResource.StoneProdLvl:
            case GameResources.GameResource.GoldProdLvl:
                return true;
            default:
                return false;
        }
    }
    
    void Awake()
    {
        foreach (GameResources.GameResource resource in System.Enum.GetValues(typeof(GameResources.GameResource)))
        {
            dictionary[resource] = new ObservableInt(0);
            if (IsProductionLevel(resource))
            {
                productionLevels[resource] = 0;
            }
        }
    }
    
    // Start is called before the first frame upd
}