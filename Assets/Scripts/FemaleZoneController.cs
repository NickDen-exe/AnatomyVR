using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleZoneController : MonoBehaviour
{
    [SerializeField] private menuNavigation modeControl;
    [SerializeField] private ActionsController modeController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        modeControl.ModeChanger(2);
        modeController.ZoneModeChanger(2);
    }
    private void OnTriggerExit(Collider other)
    {
        modeControl.ModeChanger(0);
        modeController.ZoneModeChanger(0);
    }
}
