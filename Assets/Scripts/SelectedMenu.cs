using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedMenu : MonoBehaviour
{
    //[SerializeField] private MaleModel;
    [SerializeField] private int groupNum;
    [SerializeField] private Image circleImg;
    private Color32 highColor = new Color32(100,255,125,150);
    // Start is called before the first frame update

    bool isActive = true;

    // GameObject lastHighlighted = null;

    void Start()
    {
        circleImg.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        SetCorrectColor();
    }

    private void LateUpdate()
    {
        
    }

    public int selectedNum()
    {
        return groupNum;
    }

    private void SetCorrectColor()
    {
        if (isActive)
            circleImg.color = Color.green;
        else
            circleImg.color = Color.gray;
    }

    public void SetCircleActive()
    {
        SetCorrectColor();
        isActive = !isActive;
    }

    public void HighlightMenuSel()
    {
        //if (toHighlight != lastHighlighted)
        //{
        //    if (lastHighlighted != null)
        //    {
        //        circleImg.color = Color.green;
        //    }
        //    lastHighlighted = toHighlight;
        //}
        //else
        //{
            circleImg.color = Color.yellow;
        //}
    }
}
