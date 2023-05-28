using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{


    public int deathcount;
    // the values defined in this constructor will be the defoult values
    // the game starts with when there is no data to load

    public GameData()
    {
        this.deathcount = 0;
    }
}
