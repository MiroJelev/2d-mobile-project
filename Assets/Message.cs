using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public Text DisplayMessageUI;
    public string enter_message;
    public string out_message;


    void OnTriggerEnter2D(Collider2D collider)
    {
        DisplayMessageUI.text = enter_message;

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        enter_message = out_message;
        DisplayMessageUI.text = " ";
    }
}
