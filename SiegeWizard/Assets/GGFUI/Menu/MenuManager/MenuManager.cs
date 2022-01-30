using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Menu ActiveMenu;
    public GameObject Back;
    public Transform MenuSpawnPoint;
    public Transform MenuOutSwipePoint;
    public Transform MenuInSwipePoint;
    public Canvas MainCanvas;

    public float MenuPositionSwipeDuration = 0.8f;

    public void SetActiveMenu(GameObject menu)
    {
        if (menu != null)
        {
            GameObject NewMenu = Instantiate(menu, MenuSpawnPoint.position, MainCanvas.transform.rotation, MainCanvas.transform);

            Extentions.SetObjectPosition(ActiveMenu.transform, MenuOutSwipePoint.localPosition, MenuPositionSwipeDuration, NewMenu.GetComponent<Menu>().DestroyAfterClose);
            Extentions.SetObjectPosition(NewMenu.transform, MenuInSwipePoint.localPosition, MenuPositionSwipeDuration);
            ActiveMenu = NewMenu.GetComponent<Menu>();

            if (ActiveMenu.ParentMenu) Back.SetActive(true);
            else Back.SetActive(false);
        }
    }
}
