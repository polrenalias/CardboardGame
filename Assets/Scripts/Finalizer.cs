using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Finalizer : MonoBehaviour
{

  public Player player;
  // If the player touches this zone it dies, avoiding an infinite fall if the player get's out of the slide
  void OnTriggerEnter(Collider other) 
  {
    player.die();
  }
}
