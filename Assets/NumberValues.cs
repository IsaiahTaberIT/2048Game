using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberValues : MonoBehaviour
{
   // public GameObject Self;
    public SpriteRenderer selfSprite;
    public float value = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        selfSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        byte basecolor = 175;
        byte baseblue = (byte)((int)basecolor -5);
        byte basegreen = (byte)((int)basecolor);
        byte basered = (byte)((int)basecolor + 5);

        if (value == 2)
        {

            selfSprite.color = new Color32(basered, basegreen, baseblue, 255);
        }
        else if (value <= 64)
        {
            byte newred = (byte)((int)basered + 5);

            byte newgreen = (byte)(Mathf.Round((value * -2.3f) + 10) + (int)basegreen);
            byte newblue = (byte)(Mathf.Round((value * -2.3f)) + (int)baseblue - 20);
            // byte newgreen = 0;

            //byte newblue = (byte)((int)Mathf.Round(Mathf.Log(value, 2) -1) * -20 + (int)baseblue);
            // byte newblue = baseblue;
            selfSprite.color = new Color32(newred, newgreen, newblue, 255);
        }
        else if (value <= 4192)
        {

            byte newred = (byte)((int)Mathf.Round(Mathf.Log(value, 2) - 6) * 10 + 195);
            byte newgreen = (byte)((int)Mathf.Round(Mathf.Log(value, 2) - 6) * 10 + 195);
            byte newblue = (byte)((int)Mathf.Round(Mathf.Log(value, 2) -1) * 2 + (int)baseblue);

            selfSprite.color = new Color32(newred, newgreen, 0, 255);
        }
    }
   

    public float ValuePass()
{
    return value;

}
    public float ValuePass(float set)
    {
        value = set;
        return set;

    }

}
