using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
// Defines the max lifes of the user and manages the lifes bar
public class Lifes : MonoBehaviour
{
    public List<GameObject> lifePointsUI = new List<GameObject>();
    // Start is called before the first frame update
    public Player player;
    void Start()
    {
        // The number of lifes and max lifes of the player is defined by the number of "life bar" defined on the child object of this object
        foreach (Transform child in transform)
        {
            lifePointsUI.Add(child.gameObject);
            player.life++;
        }
        player.maxLife = player.life;
        // Debug.Log(player.life);
    }
    // Removes one point of life of the UI element, changing its color
    public void removeLifePoint()
    {
        lifePointsUI[player.life].GetComponent<Image>().color = new Color32(0, 150, 100, 255);
    }
    // Adds one point of life of the UI element, changing its color
    public void addLifePoint()
    {
        lifePointsUI[player.life].GetComponent<Image>().color = new Color32(0, 255, 100, 255);
    }


}
