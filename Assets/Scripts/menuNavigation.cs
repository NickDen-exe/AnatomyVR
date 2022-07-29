using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuNavigation : MonoBehaviour
{
    [SerializeField] private LaserPointer pointer;
    [SerializeField] private MaleModel maleModel;
    [SerializeField] private FemaleModel femaleModel;

    [SerializeField] private GameObject maleMenu;
    [SerializeField] private GameObject femaleMenu;

    Ray ray;
    RaycastHit hit;

    private int zoneMode;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMenu();
    }

    private void LateUpdate()
    {
        RedSelection();
    }

    private void RedSelection()
    {
        GameObject linkToHittedObj = pointer.GetHittedObject();
        if (linkToHittedObj == null) return;
        SelectedMenu selMenu = linkToHittedObj.GetComponent<SelectedMenu>();

        if (selMenu == null)
            return;

        selMenu.HighlightMenuSel();
    }

    public void SelectionConfirm()
    {
        GameObject link = pointer.GetHittedObject();
        if (link == null) return;
        SelectedMenu selMenu = link.GetComponent<SelectedMenu>();

        if (selMenu == null)
        {
            Debug.Log("no selected menu");
            return;
        }

        int n = selMenu.selectedNum();

        if (zoneMode == 1)
        {
            maleModel.DisableMaleSystems(n);
        }

        else if (zoneMode == 2)
        {
            femaleModel.DisableFemaleSystems(n);
        }

        n = 0;
        selMenu.SetCircleActive();
    }

    private void UpdateMenu()
    {
        if (zoneMode == 1)
        {
            maleMenu.SetActive(true);
            femaleMenu.SetActive(false);
        }
        else if (zoneMode == 2)
        {
            maleMenu.SetActive(false);
            femaleMenu.SetActive(true);
        }
        else
        {
            maleMenu.SetActive(false);
            femaleMenu.SetActive(false);
        }
    }

    public void ModeChanger(int mode)
    {
        zoneMode = mode;
    }
}
