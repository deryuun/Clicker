using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ResourceBank resourceBank;
    public GameResources.GameResource resource;
    public Button productionButton;
    public TextMeshPro text;

    private void Awake()
    {
        resourceBank = FindObjectOfType<ResourceBank>();
        productionButton = GetComponent<Button>();
        productionButton.onClick.AddListener(OnHumansProdLvlButtonClick);
        
    }
    public void OnHumansProdLvlButtonClick()
    {
        if (resource.ToString().Contains("ProdLvl"))
        {
            resourceBank.ChangeProductionLevel(resource);
            IncreaseProductionLevel(resource);
        }
    }
    

    private void IncreaseProductionLevel(GameResources.GameResource resource)
    {
        text.text = resourceBank.GetProductionLevel(resource).ToString();
    }
}
    
