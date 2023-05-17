using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{

    public SOInt sOInt;
    public TextMeshProUGUI uiTextvalue;
    // Start is called before the first frame update
    void Start()
    {
        uiTextvalue.text = sOInt.value.ToString();   
    }

    // Update is called once per frame
    void Update()
    {
        uiTextvalue.text = sOInt.value.ToString();
    }
}
