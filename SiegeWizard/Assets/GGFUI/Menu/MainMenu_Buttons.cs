using UnityEngine;

public class MainMenu_Buttons : MonoBehaviour
{
    MenuManager menuManager;
    public GameObject PlayMenu;
    public GameObject SettingsMenu;
    public GameObject AboutMenu;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("MainCanvas").GetComponent<MenuManager>();
    }

    public void PlayClick()
    {
        menuManager.SetActiveMenu(PlayMenu);
    }

    public void SettingsClick()
    {
        menuManager.SetActiveMenu(SettingsMenu);
    }

    public void AboutClick()
    {
        menuManager.SetActiveMenu(AboutMenu);
    }
}
