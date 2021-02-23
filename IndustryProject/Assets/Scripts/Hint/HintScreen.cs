using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI pageCounter;
    [SerializeField] private GameObject image;
    private bool showPopUp = false;

    private HintInventory hintInventory;
    private TextMeshProUGUI hintScreen;

    private int pageIndex = 1;
    private int pageBound = 1;

    private void Update() {
        checkForPageControl();
        if (InputReader.instance.OnPhone){
            showPopUp = !showPopUp;
        }
        if(showPopUp){            
            updateHints();
            ShowPopUp();
            
        }
        if(panel.activeSelf){
            if(!showPopUp){
                ClosePopUp();
            }
        }
    }

    private void checkForPageControl()
    {
        if (InputReader.instance.NextPage)
        {
            pageIndex++;
            if(pageIndex > pageBound)
            {
                pageBound = pageIndex;
            }         
            hintScreen.pageToDisplay = pageIndex;
            pageCounter.text = pageIndex + "/" + pageBound;
        }
        else if (InputReader.instance.PreviousPage)
        {
            pageIndex--;
            if(pageIndex < 1)
            {
                pageIndex = 1;
            }
            hintScreen.pageToDisplay = pageIndex-1;
            pageCounter.text = pageIndex + "/" + pageBound;
        }
    }

    private void Start()
    {     
        hintScreen = panel.GetComponentInChildren<TextMeshProUGUI>();
        hintInventory = GetComponent<HintInventory>();
        pageCounter.text = "1/1";
    }

    private void ShowPopUp()
    {       
        panel.SetActive(true);
        image.SetActive(false);
    }

    private void ClosePopUp()
    {       
        panel.SetActive(false);
        image.SetActive(true);
    }

    private void updateHints()
    {
        hintScreen.text = "";
        foreach(Hint hint in hintInventory.Hints)
        {
            hintScreen.text += "- " + hint.Data.Description + "\n";
        }
        
        
    }


}
