using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class DisplayNumber : MonoBehaviour
{
    public TextMeshPro Text;
    public NumberValues NumberValues;

    // Start is called before the first frame update
    void Start()
    {
        Text = gameObject.GetComponent<TextMeshPro>();
        NumberValues = GetComponentInParent<NumberValues>();
}

    // Update is called once per frame
    void Update()
    {

        Text.SetText(string.Format("{0:N0}", NumberValues.value));
    }
}
