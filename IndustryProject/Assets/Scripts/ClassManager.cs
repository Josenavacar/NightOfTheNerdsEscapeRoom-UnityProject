using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassManager : MonoBehaviour
{
    #region SingleTon
    public static ClassManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    public List<MeshList> meshLists = new List<MeshList>();
    
    private List<EnumPlayerClasses> selectedClasses = new List<EnumPlayerClasses>();
    private List<PlayerClassSelector> playerClassSelectors = new List<PlayerClassSelector>();

    public bool CanSelectClass(EnumPlayerClasses pickedClass)
    {
        bool toReturn = true;

        foreach (EnumPlayerClasses alreadySelectedClass in selectedClasses)
        {
            if (alreadySelectedClass == pickedClass)
            {
                toReturn = false;
                break;
            }
        }

        return toReturn;
    }

    public void AddPlayerClassSelector(PlayerClassSelector playerClassSelector)
    {
        playerClassSelectors.Add(playerClassSelector);
    }

    public void DeSelectClass(EnumPlayerClasses classToRemove)
    {
        int index = -1;

        bool foundClass = false;

        foreach (EnumPlayerClasses selectedClass in selectedClasses)
        {
            index++;

            if (selectedClass == classToRemove)
            {
                foundClass = true;
                break;
            }
        }

        if (foundClass)
        {
            selectedClasses.RemoveAt(index);
        }

        UpdateSelectionGraphic(classToRemove, false);
    }

    public void SelectClass(EnumPlayerClasses pickedClass)
    {
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.CLASS_CHANGE);
        selectedClasses.Add(pickedClass);
        UpdateSelectionGraphic(pickedClass, true);
    }

    public void UpdateSelectionGraphic(EnumPlayerClasses classToUpdate, bool isSelected)
    {
        foreach (PlayerClassSelector selector in playerClassSelectors)
        {
            if (selector.SelectedClass == classToUpdate)
            {
                selector.ChangeColor(isSelected);
                break;
            }
        }
    }

    public List<MeshFilter> getMeshes(EnumPlayerClasses playerClass)
    {
        List<MeshFilter> meshesToReturn = new List<MeshFilter>(); 

        foreach (MeshList meshList in meshLists)
        {
            if (meshList.ClassType == playerClass)
            {
                meshesToReturn = meshList.Meshes;
                break;
            }
        }

        return meshesToReturn;
    }
}
