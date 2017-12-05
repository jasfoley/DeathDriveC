using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillCount : MonoBehaviour
{
    public static int count;


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        count = 0;
    }


    void Update ()
    {
        text.text = "Kill Count: " + count;
    }
}
