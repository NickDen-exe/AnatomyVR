using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private ActionsController actionsController;
    [SerializeField] private menuNavigation menu;
    private bool menuActive;
   
    //private Vector2 fingerPosition;
    //[SerializeField] private RoundMenuScript roundMenu;
    public SteamVR_Action_Boolean TouchPadUpDown;//Center Down
    public SteamVR_Action_Vector2 TouchPadNavigation;
    public SteamVR_Action_Single TriggerState;//Pull.Release
    public SteamVR_Action_Boolean TriggerUpDown;//Down.Up
    public SteamVR_Action_Boolean leftSideButton;//Down

    public SteamVR_Input_Sources handType;
    public SteamVR_Input_Sources handType2;

    // Start is called before the first frame update
    void Start()
    {
        menuActive = false;
        //TouchPadUpDown.AddOnStateDownListener(TouchPadDown, handType);
        //TouchPadUpDown.AddOnStateUpListener(TouchPadUp, handType);
        //TouchPadNavigation.AddOnAxisListener(TouchPadPosition, handType);

        TriggerState.AddOnAxisListener(TriggerPosition, handType);
        TriggerUpDown.AddOnStateDownListener(TriggerDown, handType);

        leftSideButton.AddOnStateDownListener(SideButtonState, handType2);
    }
    private void Update()
    {

    }


    public void TouchPadDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
       
    }
    public void TouchPadUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
       
    }
    public void TouchPadPosition(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
       
    }

    public void TriggerPosition(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
    {

        if (newAxis <= 0.1) //Trigger released
        {
            //actionsController.HighligtParts(false);
        }
        else if (newAxis > 0.1 && newAxis < 1) //Trigger pressed
        {
            //actionsController.HighligtParts(true);
        }
    }

    public void SideButtonState(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        menuActive = !menuActive;
        actionsController.CallMenu();
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)// Trigger button down
    {
        if (menuActive)
        {
            menu.SelectionConfirm();
        }
        else
        {
            actionsController.DisableParts();
            //calldestroy
            //callbuild
        }
    }
    
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) //Triger button up
    {
       
    }
   
}
