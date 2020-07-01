using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items
{

    public float itemEnergy;
    public float itemCost;
    public float itemPerSec = 0;


    public Weather weather = new Weather();

    public void createPotat(int level)
    {
        if(level == 1)
        {
            itemEnergy = 1;
            itemPerSec = 0;
        }
        if (level == 2)
        {
            itemEnergy = 1;
            itemPerSec = 1;
        }
        if (level == 3)
        {
            itemEnergy = 1;
            itemPerSec = 1;
        }
        if (level == 4)
        {
            itemEnergy = 2;
            itemPerSec = 2;
        }
        if (level == 5)
        {
            itemEnergy = 2;
            itemPerSec = 2;
        }
        if(level > 5)
        {
            itemEnergy += 1;
            itemPerSec += 1;
        }
    }


    public void createWindmill(int level)
    {
        if (level == 1)
        {
            itemEnergy = 5;
            itemPerSec = 2;
        }
        if (level == 2)
        {
            itemEnergy = 12;
            itemPerSec = 3;
        }
        if (level == 3)
        {
            itemEnergy = 22;
            itemPerSec = 5;
        }
        if (level == 4)
        {
            itemEnergy = 28;
            itemPerSec = 8;
        }
        if (level == 5)
        {
            itemEnergy = 36;
            itemPerSec = 12;
        }
        if (level > 5)
        {
            itemEnergy += 5;
            itemPerSec += 2;
        }
    }


    public void createSolar(int level)
    {
        if (level == 1)
        {
            itemEnergy = 2;
            itemPerSec = 5;
        }
        if (level == 2)
        {
            itemEnergy = 3;
            itemPerSec = 10;
        }
        if (level == 3)
        {
            itemEnergy = 8;
            itemPerSec = 18;
        }
        if (level == 4)
        {
            itemEnergy = 12;
            itemPerSec = 24;
        }
        if (level == 5)
        {
            itemEnergy = 18;
            itemPerSec = 32;
        }
        if (level > 5)
        {
            itemEnergy += 3;
            itemPerSec += 7;
        }
    }

    public void createPowerp(int level)
    {
        if (level == 1)
        {
            itemEnergy = 4;
            itemPerSec = 4;
        }
        if (level == 2)
        {
            itemEnergy = 9;
            itemPerSec = 9;
        }
        if (level == 3)
        {
            itemEnergy = 14;
            itemPerSec = 14;
        }
        if (level == 4)
        {
            itemEnergy = 20;
            itemPerSec = 20;
        }
        if (level == 5)
        {
            itemEnergy = 28;
            itemPerSec = 28;
        }
        if (level > 5)
        {
            itemEnergy += 6;
            itemPerSec += 6;
        }
    }

    public void createHamster(int level)
    {
        if (level == 1)
        {
            itemEnergy = 4;
            itemPerSec = 1;
        }
        if (level == 2)
        {
            itemEnergy = 8;
            itemPerSec = 2;
        }
        if (level == 3)
        {
            itemEnergy = 16;
            itemPerSec = 4;
        }
        if (level == 4)
        {
            itemEnergy = 30;
            itemPerSec = 5;
        }
        if (level == 5)
        {
            itemEnergy = 45;
            itemPerSec = 6;
        }
        if (level > 5)
        {
            itemEnergy += 5;
            itemPerSec += 5;
        }
    }

    public void createWater(int level)
    {
        if (level == 1)
        {
            itemEnergy = 2;
            itemPerSec = 4;
        }
        if (level == 2)
        {
            itemEnergy = 4;
            itemPerSec = 8;
        }
        if (level == 3)
        {
            itemEnergy = 8;
            itemPerSec = 16;
        }
        if (level == 4)
        {
            itemEnergy = 14;
            itemPerSec = 26;
        }
        if (level == 5)
        {
            itemEnergy = 20;
            itemPerSec = 28;
        }
        if (level > 5)
        {
            itemEnergy += 4;
            itemPerSec += 4;
        }
    }
}
