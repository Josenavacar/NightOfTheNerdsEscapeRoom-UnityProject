using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClassSelector : Interactable
{
    [SerializeField] private EnumPlayerClasses selectableClass;
    [SerializeField] private ColorChanger colorChanger;
    [SerializeField] private List<MeshFilter> lstMeshes = new List<MeshFilter>();

    private ClassPickerManager classPickerManager;

    PhotonView PV;
    private ClassPickerManager lastClassPicker;

    private void Start()
    {
        classPickerManager = GetComponentInParent<ClassPickerManager>();

        ClassManager.instance.meshLists.Add(new MeshList(selectableClass, lstMeshes));
        ClassManager.instance.AddPlayerClassSelector(this);
    }

    public void ChangeColor(bool isSelected)
    {
        if (colorChanger != null)
        {
            colorChanger.ChangeColor(isSelected);
        }
    }

    public override void HandleAction(Transform transform)
    {
        SetPhotonView(transform);

        PickClass(transform);
    }

    private void SetPhotonView(Transform transform)
    {
        if (PV == null)
        {
            PV = transform.GetComponentInParent<PhotonView>();
        }
    }

    private void PickClass(Transform transform)
    {
        PlayerClass playerClass = transform.GetComponentInParent<PlayerClass>();

        playerClass.ChangePlayerClass(SelectedClass);
    }

    public List<MeshFilter> LstMeshes { get => lstMeshes; }
    public EnumPlayerClasses SelectedClass { get => selectableClass; }
}
