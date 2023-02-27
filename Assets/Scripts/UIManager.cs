using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI userMessage;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: "+PlayerPrefs.GetFloat("highScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUserMessage(string s) 
    {
        userMessage.text = s;
        title.text = "";
        highScore.gameObject.SetActive(false);
    }
}
