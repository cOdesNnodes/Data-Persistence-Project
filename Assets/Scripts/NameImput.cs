using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NameImput : MonoBehaviour
{
    [SerializeField] public TMP_InputField inputField;
    [SerializeField] public string uname;
    [SerializeField] public string ScoreTextName;

    public TMP_Text userInput;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("Name Field").GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputName()
    {
        string uname = inputField.text;
        Debug.Log(uname + " loaded into NameImput script");
       
        FindObjectOfType<ScoreKeeper>().WhosPlaying(uname);
        //_inputField.text = "";
    }

    public void UpdateUsName(string ScoreTextName)
    {
        userInput.text = ScoreTextName.ToString();
        Debug.Log(ScoreTextName + " Has Been Passed from ScoreKeeper");
    }
}
