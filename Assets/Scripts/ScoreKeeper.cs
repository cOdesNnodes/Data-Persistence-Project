using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//public TMP_InputField Playername;

//string currentPlayername = Playername.text;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance;

    public string currentPlayer;

    public bool playerIsNew;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void WhosPlaying(string UsInput)
    {
        currentPlayer = UsInput;

        Debug.Log(currentPlayer + " is loaded in ScoreKeeper");

        FindObjectOfType<NameImput>().UpdateUsName(currentPlayer);
    }

    public void UpdateMainManager()
    {
        Debug.Log(currentPlayer + " Sent to MainManager");

        FindObjectOfType<MainManager>().UpdateCurrentScoreText(currentPlayer);
    }
}
