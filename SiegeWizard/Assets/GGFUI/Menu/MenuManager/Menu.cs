using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject ParentMenu;
    public GameObject MenuPrefab;

    public bool DestroyAfterClose = true;

    public void GoBack()
    {
        if (ParentMenu) transform.parent.GetComponent<MenuManager>().SetActiveMenu(ParentMenu);
    }
}
