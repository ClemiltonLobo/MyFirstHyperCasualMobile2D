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
        artSetup setup = artSetups.Find(i => i.artType == artType);
        if (setup == null)
        {
            Debug.LogWarning("No artSetup found for ArtType: " + artType);
            // Aqui você pode retornar null ou um valor padrão adequado
            // ou tomar qualquer outra ação necessária.
        }
        return setup;
        //return artSetups.Find(i => i.artType == artType);
    }
}

[System.Serializable]
public class artSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}