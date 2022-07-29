using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundMenuScript : MonoBehaviour
{
    [SerializeField] private InputController touchpadInput;
    [SerializeField] private MaleModel maleModel;
    [SerializeField] private FemaleModel femaleModel;
    [SerializeField] private GameObject pointer;
    RaycastHit hit;
    private Vector2 fingerPosition;
    private Vector2 hittedPoint;
    private float curAngle;
    private int selection;
    private Color defColor = new Color(135, 135, 135, 205);
    private Color selColor = new Color(255, 255, 255, 20);
    private Color actColor = new Color(0, 255, 6, 255);
    private Color deactColor = new Color(181, 181, 181, 255);
    [SerializeField] private GameObject[] menuSelections;
    [SerializeField] private Image[] backgrounds;
    [SerializeField] private Image[] maleCircleIcons;
    [SerializeField] private Image[] femaleCircleIcons;
    [SerializeField] private GameObject maleMenu;
    [SerializeField] private GameObject femaleMenu;
    //private Image[] femaleCircleIcons;
    private int modeChanger = 0; //1-male 2-female
    //public GameObject[] menuSelections;

    //private MenuItemScript menuItemScr;
    //private MenuItemScript previousMenuItemScr;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Image circle in maleCircleIcons)
        {
            circle.color = Color.green;
        }
        foreach (Image circle in femaleCircleIcons)
        {
            circle.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
  
        UpdatePosition();
        CalculateSector();
        SelectionsController();
        UpdateMenu();
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        RaycastHit hit;
        Ray ray = new Ray(pointer.transform.position, pointer.transform.forward);
        Physics.Raycast(ray, out hit, 10);
        ///hit = pointer.GetHittedObject();
        hittedPoint.x = hit.point.x;
        hittedPoint.y = hit.point.y;
        Debug.Log(hittedPoint);


    }
    //public void UpdateFingerPos()
    //{
    //    if (touchpadInput.GetFingerPos() != null)
    //    {
    //        fingerPosition = touchpadInput.GetFingerPos();
    //    }       
    //}

    private void CalculateSector()
    {
        curAngle = Mathf.Atan2(hittedPoint.y, hittedPoint.x) * Mathf.Rad2Deg;
        curAngle = (curAngle + 360) % 360;
        selection = (int)curAngle / 45;
        Debug.Log(selection);
    }

    private void UpdateMenu()
    {
        if (modeChanger == 1)
        {
            maleMenu.SetActive(true);
            femaleMenu.SetActive(false);
        }
        else if (modeChanger == 2)
        {
            maleMenu.SetActive(false);
            femaleMenu.SetActive(true);
        }
    }

    public void SelectionsController()
    {
        foreach (Image backImg in backgrounds)
        {
            backImg.color = Color.gray;
        }
        backgrounds[selection].color = Color.white;
    }

    private void circlesController(bool mode)
    {
        if (mode)
        {
            if (maleCircleIcons[selection].color == Color.green)
            {
                maleCircleIcons[selection].color = Color.grey;
            }
            else
                maleCircleIcons[selection].color = Color.green;
        }
        else if(!mode)
        {
            if (femaleCircleIcons[selection].color == Color.green)
            {
                femaleCircleIcons[selection].color = Color.grey;
            }
            else
                femaleCircleIcons[selection].color = Color.green;
        }
       
    } 

    public void SelectionConfirm()
    {
        //circlesController();
        if (modeChanger == 1)
        {
            circlesController(true);
            //circlesController(maleCircleIcons);
            maleModel.DisableMaleSystems(selection);
        }
        else if (modeChanger == 2)
        {
            circlesController(false);
            //circlesController(femaleCircleIcons);
            femaleModel.DisableFemaleSystems(selection);
        }
    }

    public void ModeChanger(int mode)
    {
        modeChanger = mode;
    }
}
