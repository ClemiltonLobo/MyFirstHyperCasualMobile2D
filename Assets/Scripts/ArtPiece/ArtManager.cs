using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        BEACH,
        SNOW
    }
    public List<artSetup> artSetups;

    public artSetup GetSetupByType(ArtType artType)
    {
        return artSetups.Find(i => i.artType == artType);
    }
}

[System.Serializable]
public class artSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}