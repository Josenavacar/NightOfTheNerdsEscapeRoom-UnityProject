using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshList
{
    private List<MeshFilter> meshes = new List<MeshFilter>();

    private EnumPlayerClasses classType = EnumPlayerClasses.DEFAULT;

    public MeshList(EnumPlayerClasses classType, List<MeshFilter> meshes)
    {
        this.meshes = meshes;
        this.classType = classType;
    }

    public List<MeshFilter> Meshes { get => meshes; private set => meshes = value; }
    public EnumPlayerClasses ClassType { get => classType; private set => classType = value; }
}
