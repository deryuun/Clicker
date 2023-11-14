using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    public GameResources.GameResource resourceToProduce;
    public GameResources.GameResource prodLvl;
    private float ProductionTime = 1f;

    public ResourceBank resourceBank;
    public Button productionButton;
    public Slider productionSlider;
    
    private void Awake()
    {
        resourceBank = FindObjectOfType<ResourceBank>();
        productionButton = GetComponentInChildren<Button>();
        productionSlider = GetComponentInChildren<Slider>();
        productionSlider.interactable = false;
        productionButton.onClick.AddListener(StartProduction);
    }
    public void StartProduction()
    {
        productionButton.interactable = false;
        productionSlider.interactable = false;
        StartCoroutine(ProductionCoroutine());
    }

    private IEnumerator ProductionCoroutine()
    {
        float productionTime = ProductionTime * (1f - resourceBank.GetProductionLevel(prodLvl) / 100f);
        
        float timer = 0f;
        while (timer < productionTime)
        {
            timer += Time.deltaTime;
            productionSlider.value =  timer / productionTime;
            yield return null;
        }

        resourceBank.ChangeResource(resourceToProduce, 1);
        productionButton.interactable = true;
        productionSlider.interactable = false;
        productionSlider.value = 0f;
    }

}
