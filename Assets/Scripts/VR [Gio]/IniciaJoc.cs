using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Inicia el joc 20 segons després despertant a tots els objectes enemy
// Serveix també per quan s'acaba el joc que desperti a tots els enemics
public class IniciaJoc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Enemigos;
    

    void Start()
    {              
        foreach (GameObject go in Enemigos)
        {
            go.SetActive(false);
        }
        StartCoroutine("Coroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Coroutine()
    {
       
        yield return new WaitForSeconds(20f);
     
        //ara desperta a tots els enemy del mapa
        foreach (GameObject go in Enemigos)
        {
            go.SetActive(true);
        }
        //cada 3 minuts torna a crear tots els enemics
        yield return new WaitForSeconds(180);
        StartCoroutine("Coroutine");
    }

    
}


