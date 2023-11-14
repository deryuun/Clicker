using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceVisual : MonoBehaviour
{
    public GameResources.GameResource trecker;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        ResourceBank resources = FindObjectOfType<ResourceBank>();
        var resource = resources.GetResource(trecker);
        
        resource.OnValueChanged += UpdateResourceDisplay;
        
        UpdateResourceDisplay(resource.Value);
    }

    // Update is called once per frame
    public void UpdateResourceDisplay(int value)
    {
        text.text = value.ToString();
    }
    private void OnDestroy()
    {
        ResourceBank resources = FindObjectOfType<ResourceBank>();
        if(resources)
        {
            ObservableInt resourceValue = resources.GetResource(trecker);
            if (resourceValue != null)
            {
                resourceValue.OnValueChanged -= UpdateResourceDisplay;
            }
        }
    }
}
