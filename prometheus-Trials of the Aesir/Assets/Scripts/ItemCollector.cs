using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public static ItemCollector Counter;
    private int Favores = 0;
    [SerializeField] private Text FAVORESofTheGods;
    public GameObject thisSceneFaovres;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FavoresOfTheGods"))
        {
            
            Destroy(collision.gameObject);
            Favores ++;
          
            FAVORESofTheGods.text = "FAVORESofTheGods :" + Favores;
            



        }
        





    }
}