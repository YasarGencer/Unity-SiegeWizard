using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemSelector : MonoBehaviour
{
    public GameObject NextButton;
    public GameObject PreviousButton;

    public List<GameObject> Panels;
    public Image _Image;
    public GameObject PanelPrefab;

    public Transform NewLeftPanelPosition;
    public Transform NewRightPanelPosition;

    public float PanelsPositionSwipeDuration; // Second
    public float PanelsScaleSwipeDuration; // Second

    public int MainPanelId;
    public float MainPanelSizeX;
    public float MainPanelSizeY;
    public float MainPanelSizeZ;

    public float ScaledPanelSizeX;
    public float ScaledPanelSizeY;
    public float ScaledPanelSizeZ;

    public List<Item> Items = new List<Item>();

    List<Vector3> PanelsPositions;
    Vector3 ScaledPanelSize;
    Vector3 MainPanelSize;
    int LastMainPanelItemId;

    private void Awake()
    {
        PanelsPositions = new List<Vector3>();

        Items.Add(new Item() { Id = 0, Title = "Level 1", Image = Resources.Load<Sprite>("Minimaps/1") });
        Items.Add(new Item() { Id = 1, Title = "Level 2", Image = Resources.Load<Sprite>("Minimaps/2") });
        Items.Add(new Item() { Id = 2, Title = "Level 3", Image = Resources.Load<Sprite>("Minimaps/3") });
        Items.Add(new Item() { Id = 3, Title = "Level 4", Image = Resources.Load<Sprite>("Minimaps/4") });
        Items.Add(new Item() { Id = 4, Title = "Level 5", Image = Resources.Load<Sprite>("Minimaps/5") });
        Items.Add(new Item() { Id = 5, Title = "Level 6", Image = Resources.Load<Sprite>("Minimaps/6") });
        Items.Add(new Item() { Id = 6, Title = "Level 7", Image = Resources.Load<Sprite>("Minimaps/7") });
        Items.Add(new Item() { Id = 7, Title = "Level 8", Image = Resources.Load<Sprite>("Minimaps/8") });
    }


    private void Start()
    {
        for (int i = 0; i < Panels.Count; i++) PanelsPositions.Add(Panels[i].transform.localPosition);

        ScaledPanelSize = new Vector3(ScaledPanelSizeX, ScaledPanelSizeY, ScaledPanelSizeZ);
        MainPanelSize = new Vector3(MainPanelSizeX, MainPanelSizeY, MainPanelSizeZ);

        for (int i = 0; i < Panels.Count; i++) { Panels[i].GetComponent<Panel>().SetPanel(Items[i]); _Image.sprite = Items[i].Image; }
        LastMainPanelItemId = MainPanelId;
    }

    public void PreviousItem()
    {
        GameObject LeftPanel = Instantiate(PanelPrefab, NewLeftPanelPosition.position, transform.rotation, transform);

        Extentions.SetObjectPosition(LeftPanel.transform, PanelsPositions[0], PanelsPositionSwipeDuration);
        for (int i=0; i < Panels.Count; i++)
        {
            if (i != Panels.Count - 1) Extentions.SetObjectPosition(Panels[i].transform, PanelsPositions[i + 1], PanelsPositionSwipeDuration);
            else Extentions.SetObjectPosition(Panels[i].transform, NewRightPanelPosition.localPosition, PanelsPositionSwipeDuration, true);
        }

        LastMainPanelItemId = Panels[MainPanelId].GetComponent<Panel>().ActiveItem.Id;
        for (int i=Panels.Count - 1; i>0; i--)
        {
            Panels[i] = Panels[i - 1];
        }
        Panels[0] = LeftPanel;

        Extentions.SetObjectScale(LeftPanel, ScaledPanelSize, PanelsScaleSwipeDuration);
        for (int i = 0; i < Panels.Count; i++)
        {
            if (i != MainPanelId) Extentions.SetObjectScale(Panels[i], ScaledPanelSize, PanelsScaleSwipeDuration);
            else Extentions.SetObjectScale(Panels[i], MainPanelSize, PanelsScaleSwipeDuration);
        }

        int ItemId = (LastMainPanelItemId - (Panels.Count + 1) / 2 + Items.Count) % Items.Count;
        LeftPanel.GetComponent<Panel>().SetPanel(Items[ItemId]);
        _Image.sprite = Items[ItemId].Image;
    }

    public void NextItem()
    {
        GameObject RightPanel = Instantiate(PanelPrefab, NewRightPanelPosition.position, transform.rotation, transform);

        Extentions.SetObjectPosition(RightPanel.transform, PanelsPositions[Panels.Count - 1], PanelsPositionSwipeDuration);
        for (int i = 0; i < Panels.Count; i++)
        {
            if (i != 0) Extentions.SetObjectPosition(Panels[i].transform, PanelsPositions[i-1], PanelsPositionSwipeDuration);
            else Extentions.SetObjectPosition(Panels[i].transform, NewLeftPanelPosition.localPosition, PanelsPositionSwipeDuration, true);
        }

        LastMainPanelItemId = Panels[MainPanelId].GetComponent<Panel>().ActiveItem.Id;
        for (int i = 0; i < Panels.Count - 1; i++)
        {
            Panels[i] = Panels[i + 1];
        }
        Panels[Panels.Count - 1] = RightPanel;

        Extentions.SetObjectScale(RightPanel, ScaledPanelSize, PanelsScaleSwipeDuration);
        for (int i = 0; i < Panels.Count; i++)
        {
            if (i != MainPanelId) Extentions.SetObjectScale(Panels[i], ScaledPanelSize, PanelsScaleSwipeDuration);
            else Extentions.SetObjectScale(Panels[i], MainPanelSize, PanelsScaleSwipeDuration);
        }

        int ItemId = (LastMainPanelItemId + (Panels.Count + 1) / 2 + Items.Count) % Items.Count;
        RightPanel.GetComponent<Panel>().SetPanel(Items[ItemId]);
        Debug.Log(ItemId);
        _Image.sprite = Items[ItemId].Image;
    }

    public Item SelectedItem()
    {
        return Panels[MainPanelId].GetComponent<Panel>().ActiveItem;
    }

    public void SelectItem()
    {
        SceneManager.LoadScene("Level" + (SelectedItem().Id + 1));
    }
}