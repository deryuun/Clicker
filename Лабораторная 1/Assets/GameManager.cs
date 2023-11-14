using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ResourceBank resourceBank;

    public void Start()
    {
        resourceBank = this.GetComponent<ResourceBank>();
        
        resourceBank.ChangeResource(GameResources.GameResource.Humans, 10);
        resourceBank.ChangeResource(GameResources.GameResource.Food, 5);
        resourceBank.ChangeResource(GameResources.GameResource.Wood, 5);
    }
    // Start is called before the first frame update
 
}
