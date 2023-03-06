using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public byte life = 0;
    public byte maxLife = 0;

    public Lifes lifes;

    public int points = 0;

    bool canReceiveDamage = true;

    public GameObject deathParticles;
    public AudioSource deathExplosionSound;

    public SlideController slideController;
    // The player loses a pint of life
    public void losePoint()
    {
        if (canReceiveDamage)
        {
            canReceiveDamage = false;
            life--;
            lifes.removeLifePoint();
            // Debug.Log (life);
            if (life == 0)
            {
                die();
            }
            StartCoroutine(damageTime(0.5f));
        }
    }
    // The player gains a point of life
    public void gainPoint()
    {
        lifes.addLifePoint();
        life++;
    }
    // Cooldown between multiple hits
    private IEnumerator damageTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canReceiveDamage = true;
    }
    // The player dies, after some time the scene restarts
    public void die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        deathExplosionSound.Play();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        slideController.isAllowedToSlide = false;
        setNewScore();
        StartCoroutine(deathTime(3f));
    }
    // Delays the restart of the scene
    private IEnumerator deathTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Saves the highscore of the player as a PlayerPrefab in order to show it on the main screen
    private void setNewScore() {
        if (PlayerPrefs.GetInt("highScore") < points){
            PlayerPrefs.SetInt("highScore", points);
        }
    }
}
