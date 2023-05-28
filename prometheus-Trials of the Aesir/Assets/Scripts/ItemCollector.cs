using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Favores = 0;
    [SerializeField] private Text FAVORESofTheGods;

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