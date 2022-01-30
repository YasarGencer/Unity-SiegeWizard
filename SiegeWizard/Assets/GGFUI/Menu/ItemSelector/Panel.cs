using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public Text Title;

    public Item ActiveItem;
    public bool IsActivePanel;

    public void SetPanel(Item NewItem)
    {
        if (Title != null)
        {
            if (Title.text != "") Title.text = "";
            if (NewItem.Title != "")
            {
                Title.text = NewItem.Title;
            }
        }
        ActiveItem = NewItem;
    }
}
