using UnityEngine;

public class Back : MonoBehaviour
{
    public MenuManager menuManager;

    public void BackClick()
    {
        menuManager.ActiveMenu.GoBack();
    }
}
