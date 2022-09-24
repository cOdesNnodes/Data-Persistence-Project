using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NameImput : MonoBehaviour
{
    //public GameObject TMP_InputField_Username;
   // public string currentPlayer;

    [SerializeField]
    public TMP_InputField inputField;
    public string uname;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("Name Field").GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        //WhosPlaying();
    }

    //public void WhosPlaying()
    //{
     //   string currentPlayer = TMP_InputField_Username.GetComponent<TMP_InputField>().text;
     //   Debug.Log("Username: " + currentPlayer);
   // }

    public void InputName()
    {
        string uname = inputField.text;
        Debug.Log(uname);

        //_inputField.text = "";
    }
}
