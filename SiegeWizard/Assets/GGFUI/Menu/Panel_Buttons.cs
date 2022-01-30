using UnityEngine;

public class Panel_Buttons : MonoBehaviour
{
    ItemSelector itemSelector;

    void Start()
    {
        itemSelector = GetComponentInParent<ItemSelector>();
    }

    public void PanelClick()
    {
        itemSelector.SelectItem();
    }
}
