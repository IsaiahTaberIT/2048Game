using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class ScoreDisplayScript : MonoBehaviour
{
    public float Score = 0;
    public TextMeshPro Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Score: " + (string.Format("{0:N0}", Score));
    }
    public void UpdateScore(float NewScore)
    {

        Score += NewScore;

      
    }



}
