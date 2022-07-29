using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsController : MonoBehaviour
{
    [SerializeField] private MaleModel maleModel;
    [SerializeField] private FemaleModel femaleModel;
    [SerializeField] private LaserPointer pointer;
    [SerializeField] private GameObject menu;
    [SerializeField] private Material transparentMaterial;

    [SerializeField] private GameObject textInformer;
    [SerializeField] private Text informerText;

    private bool menuState;
    private int zoneModifier = 0;
    private bool modeState; //build or destroy

    GameObject curObj = null;
    Material defMaterial = null;

    string defText = "";
    string objNameText;

    //Text defText;
    //Text objNameText;
    private bool alreaduDisabled = true;


    void Start()
    {
        modeState = false; //destroy mode
        menuState = false;
        menu.SetActive(false);
    }

    void Update()
    {
        //OutlineParts();
        HighligtParts(true);
    }

    private void LateUpdate()
    {
        
    }

    public void CallMenu()
    {
        menuState = !menuState;
        if (menuState)
            menu.SetActive(true);
        else
            menu.SetActive(false);   
    }

    public void DisableParts()
    {
        GameObject linkToHittedObj = pointer.GetHittedObject();
        if (zoneModifier == 1)
        {
            maleModel.PartDisabler(linkToHittedObj, modeState);
        }
        else if (zoneModifier == 2)
        {
            femaleModel.PartDisabler(linkToHittedObj, modeState);
        }
    }
    public void OutlineParts()//
    {

        GameObject linkToHittedObj = pointer.GetHittedObject();
        
        if (linkToHittedObj.GetComponent<Outline>())
        {
            if (curObj == null)
            {
                curObj = linkToHittedObj;
                //defMaterial = curObj.GetComponent<Renderer>().material;
            }
            curObj.GetComponent<Outline>().enabled = true;
            alreaduDisabled = false;

            if (curObj != linkToHittedObj)
            {
                curObj.GetComponent<Outline>().enabled = false;
                curObj = linkToHittedObj;
                //defMaterial = curObj.GetComponent<Renderer>().material;
                curObj.GetComponent<Outline>().enabled = true;
            }
            //if (!alreaduDisabled)
            //{
            //    curObj.GetComponent<Renderer>().material = defMaterial;
            //    alreaduDisabled = true;
            //}
        }
        else
        {
            if (curObj != null && !alreaduDisabled)
            {
                curObj.GetComponent<Outline>().enabled = false;
                alreaduDisabled = true;
            }
        }
    }
    //
    public void HighligtParts(bool needHighlight)//
    {
        GameObject linkToHittedObj = pointer.GetHittedObject();
        //informerText.text = linkToHittedObj.gameObject.name;////////////////////////////////

        if (linkToHittedObj == null)
        {
            if (curObj != null && defMaterial != null && !alreaduDisabled)
            {
                informerText.text = defText;//////////////////////////
                curObj.GetComponent<Renderer>().material = defMaterial;
                alreaduDisabled = true;
            }
            //Debug.Log("HUUUSTOOOON");
            return;
        }

        if(linkToHittedObj.GetComponent<Renderer>() == null)
        {
            if (curObj != null && defMaterial != null && !alreaduDisabled)
            {
                informerText.text = defText;//////////////////////////
                curObj.GetComponent<Renderer>().material = defMaterial;
                alreaduDisabled = true;
            }
            return;
        }

        if (linkToHittedObj.GetComponent<Renderer>() && linkToHittedObj.tag != "NonHighlighted")
        {
            if (curObj == null)
            {
                curObj = linkToHittedObj;
                defMaterial = curObj.GetComponent<Renderer>().material;
            }

            if (needHighlight)
            {
                curObj.GetComponent<Renderer>().material = transparentMaterial;
                informerText.text = curObj.name;
                alreaduDisabled = false;
                if (curObj != linkToHittedObj)
                {
                    curObj.GetComponent<Renderer>().material = defMaterial;
                    curObj = linkToHittedObj;
                    defMaterial = curObj.GetComponent<Renderer>().material;
                    curObj.GetComponent<Renderer>().material = transparentMaterial;
                    informerText.text = curObj.name;
                }
            }
            else if (!needHighlight)
            {
                if (!alreaduDisabled)
                {
                    curObj.GetComponent<Renderer>().material = defMaterial;
                    informerText.text = defText;
                    alreaduDisabled = true;
                }
            }
        }
        else
        {
            if(curObj != null)
            {
                curObj.GetComponent<Renderer>().material = defMaterial;
                informerText.text = defText;
                alreaduDisabled = true;
            }
           
        }
       
    }
    //
    public void ZoneModeChanger(int mode)
    {
        zoneModifier = mode;
    }
    public void modeChanger()
    {
        modeState = !modeState;
    }
}
