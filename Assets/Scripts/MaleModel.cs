using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleModel : MonoBehaviour
{
    //[SerializeField] List<GameObject> modelParts;//0
    [SerializeField] private GameObject[] modelParts;//0

    [SerializeField] private GameObject[] bones;//1
    [SerializeField] private GameObject[] circularity;//2
    [SerializeField] private GameObject[] limphatic;//3
    [SerializeField] private GameObject[] nervouse;//4
    [SerializeField] private GameObject[] muscles;//5
    [SerializeField] private GameObject[] respiratory;//6
    [SerializeField] private GameObject[] digestive;//7
    [SerializeField] private GameObject[] uninary;//8

    private bool buildMode = false;

    private bool bonesState = true;
    private bool musclesState = true;
    private bool circularityState = true;
    private bool limphaticState = true;
    private bool nervouseState = true; 
    private bool respiratoryState = true;
    private bool digestiveState = true;
    private bool uninaryState = true;

    List<GameObject> hidenObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        //foreach (GameObject muscle in muscles)
        //{
        //    muscle.GetComponent<Outline>().enabled = false;
        //}
        foreach (GameObject part in modelParts)
        {
            part.tag = "ActivePart";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SystemsDisabler(GameObject[] systemParts)
    {
        foreach (GameObject part in systemParts)
        {
            part.SetActive(false);
            part.tag = "HiddenPart";
        }
    }
    private void SystemsActivator(GameObject[] systemParts)
    {
        foreach (GameObject part in systemParts)
        {
            part.SetActive(true);
            part.tag = "ActivePart";
        }
    }
    public void DisableMaleSystems(int system)
    {
        switch(system)
        {
            case 0:
                if (musclesState)
                {
                    SystemsDisabler(muscles);
                }
                else
                {
                    SystemsActivator(muscles);
                }
                musclesState = !musclesState;
                break;
            case 1:
                if (bonesState)
                {
                    SystemsDisabler(bones);
                }
                else
                {
                    SystemsActivator(bones);
                }
                bonesState = ! bonesState;
                break;
            case 2:
                if (digestiveState)
                {
                    SystemsDisabler(digestive);
                }
                else
                {
                    SystemsActivator(digestive);
                }
                digestiveState = !digestiveState;
                //SystemsDisabler(digestive);
                break;
            case 3:
                if (respiratoryState)
                {
                    SystemsDisabler(respiratory);
                }
                else
                {
                    SystemsActivator(respiratory);
                }
                respiratoryState = !respiratoryState;
                //SystemsDisabler(respiratory);
                break;
            case 4:
                if (nervouseState)
                {
                    SystemsDisabler(nervouse);
                }
                else
                {
                    SystemsActivator(nervouse);
                }
                nervouseState = !nervouseState;
                //SystemsDisabler(nervouse);
                break;
            case 5:
                if (circularityState)
                {
                    SystemsDisabler(circularity);
                }
                else
                {
                    SystemsActivator(circularity);
                }
                circularityState = !circularityState;
                //SystemsDisabler(circularity);
                break;
            case 6:
                if (limphaticState)
                {
                    SystemsDisabler(limphatic);
                }
                else
                {
                    SystemsActivator(limphatic);
                }
                limphaticState = !limphaticState;
                //SystemsDisabler(limphatic);
                break;
            case 7:
                if (uninaryState)
                {
                    SystemsDisabler(uninary);
                }
                else
                {
                    SystemsActivator(uninary);
                }
                uninaryState = !uninaryState;
                //SystemsDisabler(uninary);
                break;
        }
    }

    public void PartDisabler(GameObject hittedObject, bool buildMode)
    {
        if (!buildMode)
        {
            if (hittedObject.tag == "ActivePart")
            {
                hittedObject.SetActive(false);
                hittedObject.tag = "HiddenPart";
            }
        }
        else if (buildMode)
        {
            int index = hidenObjects.Count - 1;
            GameObject lastObj = hidenObjects[index];
            lastObj.GetComponent<Collider>().enabled = true;
            if (hittedObject.tag == "HiddenPart")
            {
                hittedObject.SetActive(true);
                hittedObject.tag = "ActivePart";
                hidenObjects.RemoveAt(index);
            }
        }
    }
}
