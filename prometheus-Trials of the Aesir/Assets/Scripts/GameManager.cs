using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    public GameObject BS;
    public GameObject PM;
    public GameObject BATTLEintant;
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BATTLEINTANT"))
        {


           
        }

        if (collision.gameObject.CompareTag("FavoresOfTheGods"))
        {


            
        }


    }

    public void OpenScene()
    {
        

    }
}
