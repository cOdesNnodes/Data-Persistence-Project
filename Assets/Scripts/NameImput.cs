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
    [SerializeField] public int HighScore;
    [SerializeField] public string HighName;

    [SerializeField] public TMP_Text userInput;
    [SerializeField] public TMP_Text bestScoreText;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("Name Field").GetComponent<TMP_InputField>();
        bestScoreText.text = HighName + $"'s Best Score : {HighScore}";

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

    public void ReqUpdateHighScore()
    {
        FindObjectOfType<ScoreKeeper>().UpdateHighName(HighName);
    }

    public void RecUpdateHighScore(int hScore)
    {
        HighScore = hScore;
    }

    public void ReqUpdateHighName()
    {
        FindObjectOfType<ScoreKeeper>().UpdateHighName(HighName);
    }

    public void RecUpdateHighName(string hName)
    {
        HighName = hName;
    }
}
