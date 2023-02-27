using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    public List<GameObject> lifePointsUI = new List<GameObject>();
    // Start is called before the first frame update
    public Player player;
    void Start()
    {
        foreach (Transform child in transform)
        {
            lifePointsUI.Add(child.gameObject);
            player.life++;
        }
        player.maxLife = player.life;
        // Debug.Log(player.life);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void removeLifePoint()
    {
        lifePointsUI[player.life].GetComponent<Image>().color = new Color32(0, 150, 100, 255);
    }

    public void addLifePoint()
    {
        lifePointsUI[player.life].GetComponent<Image>().color = new Color32(0, 255, 100, 255);
    }


}
