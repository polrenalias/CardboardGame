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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void losePoint()
    {
        if (canReceiveDamage)
        {
            canReceiveDamage = false;
            life--;
            lifes.removeLifePoint();
<<<<<<< Updated upstream
            Debug.Log (life);
=======
>>>>>>> Stashed changes
            if (life == 0)
            {
                die();
            }
            StartCoroutine(damageTime());
        }
    }

    public void gainPoint()
    {
        lifes.addLifePoint();
        life++;
    }

    private IEnumerator damageTime()
    {
        yield return new WaitForSeconds(0.5f);
        canReceiveDamage = true;
    }

    public void die()
    {
<<<<<<< Updated upstream
=======
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        deathExplosionSound.Play();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        // slideController.isAllowedToSlide = false;
        StartCoroutine(deathTime(3f));
    }

    private IEnumerator deathTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
>>>>>>> Stashed changes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
