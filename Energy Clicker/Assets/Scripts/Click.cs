using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{

    #region vars
    public Button energyBtn;
    public Text energyTag;
    public float energy;
    private int isActive = 0;
    public int happyRating = 200;
    public int happy = 0;

    public float goldPerClick;
    public float goldPerSec;

    float potatGold;
    float potatGold2;

    float windmillGold;
    float windmillGold2;

    float solarGold;
    float solarGold2;

    float powerGold;
    float powerGold2;

    float hamsterGold;
    float hamsterGold2;

    float waterGold;
    float waterGold2;

    float w_potatGold;
    float w_potatGold2;

    float w_windmillGold;
    float w_windmillGold2;

    float w_solarGold;
    float w_solarGold2;

    float w_powerGold;
    float w_powerGold2;

    float w_hamsterGold;
    float w_hamsterGold2;

    float w_waterGold;
    float w_waterGold2;

    public Items item = new Items();
    public Weather weather = new Weather();

    public Button weatherspr;
    public Sprite cloudy;
    public Sprite sunny;
    public Sprite rain;
    public Sprite windy;

    public Button face;
    public Sprite good;
    public Sprite neut;
    public Sprite bad;

    public Button background;
    public Sprite bg_cloudy;
    public Sprite bg_sunny;
    public Sprite bg_rain;
    public Sprite bg_windy;

    public Image PotatImg;
    public Image SolarImg;
    public Image WindmillImg;
    public Image PowerImg;
    public Image HamsterImg;
    public Image WaterImg;

    public Button addWindmillBtn;
    public Button addSolarBtn;
    public Button addPotatBtn;
    public Button addPowerPlantBtn;
    public Button addHamsterBtn;
    public Button addWaterBtn;

    public Button lvlWindmill;
    public Button lvlSolar;
    public Button lvlPotat;
    public Button lvlWater;
    public Button lvlPower;
    public Button lvlHam;

    // levels
    int windmillLvl;
    int potatLvl;
    int solarLvl;
    int powerpLvl;
    int hamsterLvl;
    int waterLvl;

    // check if made
    bool windmillX = false;
    bool solarX = false;
    bool powerX = false;
    bool hamsterX = false;
    bool waterX = false;

    bool windmillY = false;
    bool solarY = false;
    bool powerY = false;
    bool potatY = false;
    bool hamsterY = false;
    bool waterY = false;

    bool upgradedSolar = false;
    bool upgradedWind = false;
    bool upgradedWater = false;
    bool upgradedHam = false;

    #endregion

    void Start()
    {
        createStart();

        StartCoroutine("StartCounter");
        StartCoroutine("StartWeather");

        energyBtn.onClick.AddListener(TaskOnClick);
        addWindmillBtn.onClick.AddListener(addWindmill);
        addSolarBtn.onClick.AddListener(addSolarPanel);
        addPotatBtn.onClick.AddListener(addPotat);
        addPowerPlantBtn.onClick.AddListener(addPowerPlant);
        addHamsterBtn.onClick.AddListener(addHamster);
        addWaterBtn.onClick.AddListener(addWater);

        lvlSolar.onClick.AddListener(lvlSolarX);
        lvlPower.onClick.AddListener(lvlPowerX);
        lvlWindmill.onClick.AddListener(lvlWindmillX);
        lvlPotat.onClick.AddListener(lvlPotatX);
        lvlWater.onClick.AddListener(lvlWaterX);
        lvlHam.onClick.AddListener(lvlHamX);

    }

    void Update()
    {
        energyTag.text = "$: " + Mathf.Round(energy);
        Debug.Log("" + Mathf.Pow(1.07f, solarLvl - 1) * (solarLvl + 5));
        CheckWeather();
        CheckHappiness();
    }

    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(1f);
        energy += goldPerSec;
        StartCoroutine("StartCounter");
    }

    IEnumerator StartWeather()
    {
        weather.climate = Random.Range(0, 4);
        Debug.Log(weather.climate);
        float randnum = Random.Range(45f, 120f);
        yield return new WaitForSeconds(randnum);
        StartCoroutine("StartWeather");
    }

    void createStart()
    {
        potatLvl = 1;
        item.createPotat(potatLvl);

        potatGold = item.itemEnergy;
        potatGold2 = item.itemPerSec;
        goldPerClick += potatGold;
        goldPerSec += potatGold2;

        isActive++;
        potatY = true;

        ColorBlock colors = addPotatBtn.colors;
        colors.selectedColor = Color.green;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 250, 100, 255);
        addPotatBtn.colors = colors;

        hideImages();
        PotatImg.enabled = true;
    }


    void hideImages()
    {
        PotatImg.enabled = false;
        SolarImg.enabled = false;
        WindmillImg.enabled = false;
        PowerImg.enabled = false;
        WaterImg.enabled = false;
        HamsterImg.enabled = false;
    }

    void TaskOnClick()
    {
        energy += goldPerClick;
        happyRating += happy;
        Debug.Log(goldPerClick);
    }




    // Bonuses based on weather system
    void CheckWeather()
    {
        if(weather.climate == 0)
        {
            weatherspr.image.sprite = cloudy;
            background.image.sprite = bg_cloudy;

            if (solarY)
            {
                if (upgradedSolar)
                {
                    goldPerClick -= w_solarGold;
                    goldPerSec -= w_solarGold2;

                    w_solarGold = 0;
                    w_solarGold2 = 0;

                    
                }
                else
                {
                    w_solarGold = solarGold * 0.9f;
                    w_solarGold2 = solarGold2 * 0.8f;

                    goldPerClick -= solarGold;
                    goldPerSec -= solarGold2;

                    goldPerClick += w_solarGold;
                    goldPerSec += w_solarGold2;

                }
            }

            if (!solarY)
            {
                if(w_solarGold > 0)
                {
                    goldPerClick -= w_solarGold;
                    w_solarGold = 0;
                    goldPerClick += solarGold;
                }
                if(w_solarGold2 > 0)
                {
                    goldPerSec -= w_solarGold2;
                    w_solarGold2 = 0;
                    goldPerClick += solarGold2;
                }

                upgradedSolar = false;
            }

            if (!waterY)
            {
                if (w_waterGold > 0)
                {
                    goldPerClick -= w_waterGold;
                    w_waterGold = 0;
                    goldPerClick += waterGold;
                }
                if (w_waterGold2 > 0)
                {
                    goldPerSec -= w_waterGold2;
                    w_waterGold2 = 0;
                    goldPerClick += waterGold2;
                }

                upgradedWater = false;
            }

            if (!windmillY)
            {
                if (w_windmillGold > 0)
                {
                    goldPerClick -= w_windmillGold;
                    w_windmillGold = 0;
                    goldPerClick += windmillGold;
                }
                if (w_windmillGold2 > 0)
                {
                    goldPerSec -= w_windmillGold2;
                    w_windmillGold2 = 0;
                    goldPerClick += windmillGold2;
                }

                upgradedWind = false;
            }

            if (!hamsterY)
            {
                if (w_hamsterGold > 0)
                {
                    goldPerClick -= w_hamsterGold;
                    w_solarGold = 0;
                    goldPerClick += hamsterGold;
                }
                if (w_hamsterGold2 > 0)
                {
                    goldPerSec -= w_hamsterGold2;
                    w_hamsterGold2 = 0;
                    goldPerClick += hamsterGold2;
                }

                upgradedHam = false;
            }
        }
        else if (weather.climate == 1)
        {
            weatherspr.image.sprite = sunny;
            background.image.sprite = bg_sunny;

            if (solarY)
            {
                if (upgradedSolar)
                {
                    goldPerClick -= w_solarGold;
                    goldPerSec -= w_solarGold2;

                    w_solarGold = 0;
                    w_solarGold2 = 0;

                    
                }
                else
                {
                    w_solarGold = solarGold * 1.5f;
                    w_solarGold2 = solarGold2 * 2f;

                    goldPerClick -= solarGold;
                    goldPerSec -= solarGold2;

                    goldPerClick += w_solarGold;
                    goldPerSec += w_solarGold2;

                }

            }

            if (hamsterY)
            {
                if (upgradedHam)
                {
                    goldPerClick -= w_hamsterGold;

                    w_hamsterGold = 0;
                    
                }
                else
                {
                    w_hamsterGold = hamsterGold * 0.8f;

                    goldPerClick -= hamsterGold;

                    goldPerClick += w_hamsterGold;

                }

            }

            if (windmillY)
            {
                goldPerClick -= w_windmillGold;

                w_windmillGold = 0;
                
                }
                else
                {
                if (upgradedWind)
                {
                    w_windmillGold = windmillGold * 0.8f;

                    goldPerClick -= windmillGold;

                    goldPerClick += w_windmillGold;
                }

            }

            if (!solarY)
            {
                if (w_solarGold > 0)
                {
                    goldPerClick -= w_solarGold;
                    w_solarGold = 0;
                    goldPerClick += solarGold;
                }
                if (w_solarGold2 > 0)
                {
                    goldPerSec -= w_solarGold2;
                    w_solarGold2 = 0;
                    goldPerClick += solarGold2;
                }

                upgradedSolar = false;
            }

            if (!waterY)
            {
                if (w_waterGold > 0)
                {
                    goldPerClick -= w_waterGold;
                    w_waterGold = 0;
                    goldPerClick += waterGold;
                }
                if (w_waterGold2 > 0)
                {
                    goldPerSec -= w_waterGold2;
                    w_waterGold2 = 0;
                    goldPerClick += waterGold2;
                }

                upgradedWater = false;
            }

            if (!windmillY)
            {
                if (w_windmillGold > 0)
                {
                    goldPerClick -= w_windmillGold;
                    w_windmillGold = 0;
                    goldPerClick += windmillGold;
                }
                if (w_windmillGold2 > 0)
                {
                    goldPerSec -= w_windmillGold2;
                    w_windmillGold2 = 0;
                    goldPerClick += windmillGold2;
                }

                upgradedWind = false;
            }

            if (!hamsterY)
            {
                if (w_hamsterGold > 0)
                {
                    goldPerClick -= w_hamsterGold;
                    w_solarGold = 0;
                    goldPerClick += hamsterGold;
                }
                if (w_hamsterGold2 > 0)
                {
                    goldPerSec -= w_hamsterGold2;
                    w_hamsterGold2 = 0;
                    goldPerClick += hamsterGold2;
                }

                upgradedHam = false;
            }
        }
        else if (weather.climate == 2)
        {
            weatherspr.image.sprite = rain;
            background.image.sprite = bg_rain;

            if (solarY)
            {
                if (upgradedSolar)
                {
                    goldPerClick -= w_solarGold;
                    goldPerSec -= w_solarGold2;

                    w_solarGold = 0;
                    w_solarGold2 = 0;

                    
                }
                else
                {
                    w_solarGold = solarGold * 0.8f;
                    w_solarGold2 = solarGold2 * 0.7f;

                    goldPerClick -= solarGold;
                    goldPerSec -= solarGold2;

                    goldPerClick += w_solarGold;
                    goldPerSec += w_solarGold2;

                }

            }

            if (waterY)
            {
                if (upgradedWater)
                {
                    goldPerClick -= w_waterGold;
                    goldPerSec -= w_waterGold2;

                    w_waterGold = 0;
                    w_waterGold2 = 0;
                }
                else
                {
                    w_waterGold = waterGold * 1.2f;
                    w_waterGold2 = waterGold2 * 1.5f;

                    goldPerClick -= waterGold;
                    goldPerSec -= waterGold2;

                    goldPerClick += w_waterGold;
                    goldPerSec += w_waterGold2;



                }

            }

            if (!solarY)
            {
                if (w_solarGold > 0)
                {
                    goldPerClick -= w_solarGold;
                    w_solarGold = 0;
                    goldPerClick += solarGold;
                }
                if (w_solarGold2 > 0)
                {
                    goldPerSec -= w_solarGold2;
                    w_solarGold2 = 0;
                    goldPerClick += solarGold2;
                }

                upgradedSolar = false;
            }

            if (!waterY)
            {
                if (w_waterGold > 0)
                {
                    goldPerClick -= w_waterGold;
                    w_waterGold = 0;
                    goldPerClick += waterGold;
                }
                if (w_waterGold2 > 0)
                {
                    goldPerSec -= w_waterGold2;
                    w_waterGold2 = 0;
                    goldPerClick += waterGold2;
                }

                upgradedWater = false;
            }

            if (!windmillY)
            {
                if (w_windmillGold > 0)
                {
                    goldPerClick -= w_windmillGold;
                    w_windmillGold = 0;
                    goldPerClick += windmillGold;
                }
                if (w_windmillGold2 > 0)
                {
                    goldPerSec -= w_windmillGold2;
                    w_windmillGold2 = 0;
                    goldPerClick += windmillGold2;
                }

                upgradedWind = false;
            }

            if (!hamsterY)
            {
                if (w_hamsterGold > 0)
                {
                    goldPerClick -= w_hamsterGold;
                    w_solarGold = 0;
                    goldPerClick += hamsterGold;
                }
                if (w_hamsterGold2 > 0)
                {
                    goldPerSec -= w_hamsterGold2;
                    w_hamsterGold2 = 0;
                    goldPerClick += hamsterGold2;
                }

                upgradedHam = false;
            }

        }
        else if (weather.climate == 3)
        {
            weatherspr.image.sprite = windy;
            background.image.sprite = bg_windy;

            if (windmillY)
            {
                if (upgradedWind)
                {
                    goldPerClick -= w_windmillGold;
                    goldPerSec -= w_windmillGold2;

                    w_windmillGold = 0;
                    w_windmillGold2 = 0;


                   
                }
                else
                {
                     w_windmillGold = windmillGold * 1.3f;
                    w_windmillGold2 = windmillGold2 * 1.8f;

                    goldPerClick -= windmillGold;
                    goldPerSec -= windmillGold2;


                    goldPerClick += w_windmillGold;
                    goldPerSec += w_windmillGold2;

                }

            }

            if (!solarY)
            {
                if (w_solarGold > 0)
                {
                    goldPerClick -= w_solarGold;
                    w_solarGold = 0;
                    goldPerClick += solarGold;
                }
                if (w_solarGold2 > 0)
                {
                    goldPerSec -= w_solarGold2;
                    w_solarGold2 = 0;
                    goldPerClick += solarGold2;
                }

                upgradedSolar = false;
            }

            if (!waterY)
            {
                if (w_waterGold > 0)
                {
                    goldPerClick -= w_waterGold;
                    w_waterGold = 0;
                    goldPerClick += waterGold;
                }
                if (w_waterGold2 > 0)
                {
                    goldPerSec -= w_waterGold2;
                    w_waterGold2 = 0;
                    goldPerClick += waterGold2;
                }

                upgradedWater = false;
            }

            if (!windmillY)
            {
                if (w_windmillGold > 0)
                {
                    goldPerClick -= w_windmillGold;
                    w_windmillGold = 0;
                    goldPerClick += windmillGold;
                }
                if (w_windmillGold2 > 0)
                {
                    goldPerSec -= w_windmillGold2;
                    w_windmillGold2 = 0;
                    goldPerClick += windmillGold2;
                }

                upgradedWind = false;
            }

            if (!hamsterY)
            {
                if (w_hamsterGold > 0)
                {
                    goldPerClick -= w_hamsterGold;
                    w_solarGold = 0;
                    goldPerClick += hamsterGold;
                }
                if (w_hamsterGold2 > 0)
                {
                    goldPerSec -= w_hamsterGold2;
                    w_hamsterGold2 = 0;
                    goldPerClick += hamsterGold2;
                }

                upgradedHam = false;
            }
        }
    }

    void CheckHappiness()
    {
        if(happyRating >= 650)
        {
            face.image.sprite = bad;
        }
        else if(happyRating < 650 && happy > 50)
        {
            face.image.sprite = neut;
        }
        else if(happyRating < 50)
        {
            face.image.sprite = good;
        }
    }


    // Sustainability options
    void addPotat()
    {

        if (!potatY)
        {
            if (isActive < 3)
            {
                isActive++;
                goldPerClick += potatGold;
                goldPerSec += potatGold2;
                SSTools.ShowMessage("Potat Level: " + potatLvl, SSTools.Position.bottom, SSTools.Time.twoSecond);
                ColorBlock colors = addPotatBtn.colors;
                colors.selectedColor = Color.green;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(0, 250, 100, 255);
                addPotatBtn.colors = colors;
                potatY = true;
            }
            else
            {
                SSTools.ShowMessage("You already have 3 active options.", SSTools.Position.bottom, SSTools.Time.oneSecond);
                ColorBlock colors = addPotatBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addPotatBtn.colors = colors;
            }
        }
        else
        {
            isActive--;
            goldPerClick -= potatGold;
            goldPerSec -= potatGold2;
            ColorBlock colors = addPotatBtn.colors;
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            colors.highlightedColor = new Color32(250, 0, 50, 255);
            addPotatBtn.colors = colors;
            potatY = false;
        }

        hideImages();
        PotatImg.enabled = true;
    }

    void addWindmill()
    { 
        if (!windmillX && energy >= 1000)
        {
            energy -= 1000;
            windmillLvl = 1;
            item.createWindmill(windmillLvl);
            hideImages();
            WindmillImg.enabled = true;
            Debug.Log(item.itemEnergy);
            SSTools.ShowMessage("Level 1 Windmill built.", SSTools.Position.top, SSTools.Time.twoSecond);
            windmillX = true;

            windmillGold = item.itemEnergy;
            windmillGold2 = item.itemPerSec;

            

            if(isActive < 3)
            {
                isActive++;
                goldPerClick += windmillGold;
                goldPerSec += windmillGold2;
                upgradedWind = true;
                happy -= 5;
                ColorBlock colors = addWindmillBtn.colors;
                colors.selectedColor = Color.green;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(0, 250, 100, 255);
                addWindmillBtn.colors = colors;
                windmillY = true;
            }
            else
            {
                ColorBlock colors = addWindmillBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addWindmillBtn.colors = colors;
            }
        }
        else if(energy < 1000 && !windmillX)
        {
            SSTools.ShowMessage("You're missing $" + (1000 - energy) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
        else
        {
            if (!windmillY)
            {
                if (isActive < 3)
                {
                    isActive++;
                    goldPerClick += windmillGold;
                    goldPerSec += windmillGold2;
                    upgradedWind = true;
                    happy -= 5;
                    SSTools.ShowMessage("Windmill Level: " + windmillLvl, SSTools.Position.bottom, SSTools.Time.twoSecond);
                    ColorBlock colors = addWindmillBtn.colors;
                    colors.selectedColor = Color.green;
                    colors.normalColor = Color.green;
                    colors.highlightedColor = new Color32(0, 250, 100, 255);
                    addWindmillBtn.colors = colors;
                    hideImages();
                    WindmillImg.enabled = true;
                    windmillY = true;
                }
                else
                {
                    SSTools.ShowMessage("You already have 3 active options.", SSTools.Position.bottom, SSTools.Time.oneSecond);
                    ColorBlock colors = addWindmillBtn.colors;
                    colors.selectedColor = Color.red;
                    colors.normalColor = Color.red;
                    colors.highlightedColor = new Color32(250, 0, 50, 255);
                    addWindmillBtn.colors = colors;
                }
            }
            else
            {
                isActive--;
                goldPerClick -= windmillGold;
                goldPerSec -= windmillGold2;
                upgradedWind = true;
                happy += 5;
                ColorBlock colors = addWindmillBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addWindmillBtn.colors = colors;
                windmillY = false;
            }
        }

        
    }

    void addSolarPanel()
    {
        if (!solarX && energy >= 1000)
        {
            energy -= 1000;
            solarLvl = 1;
            item.createSolar(solarLvl);
            hideImages();
            SolarImg.enabled = true;
            Debug.Log(item.itemEnergy);
            SSTools.ShowMessage("Level 1 Solar Panel built.", SSTools.Position.top, SSTools.Time.twoSecond);
            solarX = true;

            solarGold = item.itemEnergy;
            solarGold2 = item.itemPerSec;

            if (isActive < 3)
            {
                isActive++;
                goldPerClick += solarGold;
                goldPerSec += solarGold2;
                upgradedSolar = true;
                happy -= 5;
                SSTools.ShowMessage("Solar Panel Level: " + solarLvl, SSTools.Position.bottom, SSTools.Time.twoSecond);
                ColorBlock colors = addSolarBtn.colors;
                colors.selectedColor = Color.green;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(0, 250, 100, 255);
                addSolarBtn.colors = colors;
                solarY = true;
            }
            else
            {
                ColorBlock colors = addSolarBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addSolarBtn.colors = colors;
            }
        }
        else if (energy < 1000 && !solarX)
        {
            SSTools.ShowMessage("You're missing $" + (1000 - energy) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
        else
        {
            if (!solarY)
            {
                if (isActive < 3)
                {
                    isActive++;
                    goldPerClick += solarGold;
                    goldPerSec += solarGold2;
                    upgradedSolar = true;
                    happy -= 5;
                    ColorBlock colors = addSolarBtn.colors;
                    colors.selectedColor = Color.green;
                    colors.normalColor = Color.green;
                    colors.highlightedColor = new Color32(0, 250, 100, 255);
                    addSolarBtn.colors = colors;
                    hideImages();
                    SolarImg.enabled = true;
                    solarY = true;
                }
                else
                {
                    SSTools.ShowMessage("You already have 3 active options.", SSTools.Position.bottom, SSTools.Time.oneSecond);
                    ColorBlock colors = addSolarBtn.colors;
                    colors.selectedColor = Color.red;
                    colors.normalColor = Color.red;
                    colors.highlightedColor = new Color32(250, 0, 50, 255);
                    addSolarBtn.colors = colors;
                }
            }
            else
            {
                isActive--;
                goldPerClick -= solarGold;
                goldPerSec -= solarGold2;
                upgradedSolar = false;
                happy += 5;
                ColorBlock colors = addSolarBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addSolarBtn.colors = colors;
                solarY = false;
            }
        }

        
        
    }

    void addPowerPlant()
    {
        if (!powerX && energy >= 500)
        {
            energy -= 500;
            powerpLvl = 1;
            item.createPowerp(powerpLvl);
            hideImages();
            PowerImg.enabled = true;
            Debug.Log(item.itemEnergy);
            SSTools.ShowMessage("Level 1 Power Plant built.", SSTools.Position.top, SSTools.Time.twoSecond);
            powerX = true;

            powerGold = item.itemEnergy;
            powerGold2 = item.itemPerSec;

            if (isActive < 3)
            {
                isActive++;
                goldPerClick += powerGold;
                goldPerSec += powerGold2;
                happy += 50;
                SSTools.ShowMessage("Power Plant Level: " + powerpLvl, SSTools.Position.bottom, SSTools.Time.twoSecond);
                ColorBlock colors = addPowerPlantBtn.colors;
                colors.selectedColor = Color.green;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(0, 250, 100, 255);
                addPowerPlantBtn.colors = colors;
                hideImages();
                PowerImg.enabled = true;
                powerY = true;
            }
            else
            {
                ColorBlock colors = addPowerPlantBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addPowerPlantBtn.colors = colors;
            }
        }
        else if (energy < 500 && !powerX)
        {
            SSTools.ShowMessage("You're missing $" + (500 - energy) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
        else
        {
            if (!powerY)
            {
                if (isActive < 3)
                {
                    isActive++;
                    goldPerClick += powerGold;
                    goldPerSec += powerGold2;
                    happy += 50;
                    ColorBlock colors = addPowerPlantBtn.colors;
                    colors.selectedColor = Color.green;
                    colors.normalColor = Color.green;
                    colors.highlightedColor = new Color32(0, 250, 100, 255);
                    addPowerPlantBtn.colors = colors;
                    hideImages();
                    PowerImg.enabled = true;
                    powerY = true;
                }
                else
                {
                    SSTools.ShowMessage("You already have 3 active options.", SSTools.Position.bottom, SSTools.Time.oneSecond);
                    ColorBlock colors = addPowerPlantBtn.colors;
                    colors.selectedColor = Color.red;
                    colors.normalColor = Color.red;
                    colors.highlightedColor = new Color32(250, 0, 50, 255);
                    addPowerPlantBtn.colors = colors;
                }
            }
            else
            {
                isActive--;
                goldPerClick -= powerGold;
                goldPerSec -= powerGold2;
                happy -= 50;
                ColorBlock colors = addPowerPlantBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addPowerPlantBtn.colors = colors;
                powerY = false;
            }
        }

        
        
    }

    void addHamster()
    {
        if (!hamsterX && energy >= 50)
        {
            energy -= 50;
            hamsterLvl = 1;
            item.createHamster(hamsterLvl);
            hideImages();
            HamsterImg.enabled = true;
            Debug.Log(item.itemEnergy);
            SSTools.ShowMessage("Level 1 Hamster Wheel built.", SSTools.Position.top, SSTools.Time.twoSecond);
            hamsterX = true;

            hamsterGold = item.itemEnergy;
            hamsterGold2 = item.itemPerSec;



            if (isActive < 3)
            {
                isActive++;
                goldPerClick += hamsterGold;
                goldPerSec += hamsterGold2;
                upgradedHam = true;
                ColorBlock colors = addHamsterBtn.colors;
                colors.selectedColor = Color.green;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(0, 250, 100, 255);
                addHamsterBtn.colors = colors;
                hideImages();
                HamsterImg.enabled = true;
                hamsterY = true;
            }
            else
            {
                ColorBlock colors = addHamsterBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addHamsterBtn.colors = colors;
            }
        }
        else if (energy < 50 && !hamsterX)
        {
            SSTools.ShowMessage("You're missing $" + (50 - energy) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
        else
        {
            if (!hamsterY)
            {
                if (isActive < 3)
                {
                    isActive++;
                    goldPerClick += hamsterGold;
                    goldPerSec += hamsterGold2;
                    upgradedHam = true;
                    SSTools.ShowMessage("Hamster Wheel Level: " + hamsterLvl, SSTools.Position.bottom, SSTools.Time.twoSecond);
                    ColorBlock colors = addHamsterBtn.colors;
                    colors.selectedColor = Color.green;
                    colors.normalColor = Color.green;
                    colors.highlightedColor = new Color32(0, 250, 100, 255);
                    addHamsterBtn.colors = colors;
                    hideImages();
                    HamsterImg.enabled = true;
                    hamsterY = true;
                }
                else
                {
                    SSTools.ShowMessage("You already have 3 active options.", SSTools.Position.bottom, SSTools.Time.oneSecond);
                    ColorBlock colors = addHamsterBtn.colors;
                    colors.selectedColor = Color.red;
                    colors.normalColor = Color.red;
                    colors.highlightedColor = new Color32(250, 0, 50, 255);
                    addHamsterBtn.colors = colors;
                }
            }
            else
            {
                isActive--;
                goldPerClick -= hamsterGold;
                goldPerSec -= hamsterGold2;
                upgradedHam = true;
                ColorBlock colors = addHamsterBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addHamsterBtn.colors = colors;
                hamsterY = false;
            }
        }

        
    }

    void addWater()
    {
        if (!waterX && energy >= 120)
        {
            energy -= 120;
            waterLvl = 1;
            item.createWater(waterLvl);
            hideImages();
            WaterImg.enabled = true;
            Debug.Log(item.itemEnergy);
            SSTools.ShowMessage("Level 1 Water Turbine built.", SSTools.Position.top, SSTools.Time.twoSecond);
            waterX = true;

            waterGold = item.itemEnergy;
            waterGold2 = item.itemPerSec;


           
            if (isActive < 3)
            {
                isActive++;
                goldPerClick += waterGold;
                goldPerSec += waterGold2;
                upgradedWater = true;
                ColorBlock colors = addWaterBtn.colors;
                colors.selectedColor = Color.green;
                colors.normalColor = Color.green;
                colors.highlightedColor = new Color32(0, 250, 100, 255);
                addWaterBtn.colors = colors;
                hideImages();
                WaterImg.enabled = true;
                waterY = true;
            }
            else
            {
                ColorBlock colors = addWaterBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addWaterBtn.colors = colors;
            }
        }
        else if (energy < 120 && !waterX)
        {
            SSTools.ShowMessage("You're missing $" + (120 - energy) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
        else
        {
            if (!waterY)
            {
                if (isActive < 3)
                {
                    isActive++;
                    goldPerClick += waterGold;
                    goldPerSec += waterGold2;
                    upgradedWater = true;
                    SSTools.ShowMessage("Water Turbine Level: " + waterLvl, SSTools.Position.bottom, SSTools.Time.twoSecond);
                    ColorBlock colors = addWaterBtn.colors;
                    colors.selectedColor = Color.green;
                    colors.normalColor = Color.green;
                    colors.highlightedColor = new Color32(0, 250, 100, 255);
                    addWaterBtn.colors = colors;
                    hideImages();
                    WaterImg.enabled = true;
                    waterY = true;

                }
                else
                {
                    SSTools.ShowMessage("You already have 3 active options.", SSTools.Position.bottom, SSTools.Time.oneSecond);
                    ColorBlock colors = addWaterBtn.colors;
                    colors.selectedColor = Color.red;
                    colors.normalColor = Color.red;
                    colors.highlightedColor = new Color32(250, 0, 50, 255);
                    addWaterBtn.colors = colors;
                }
            }
            else
            {
                isActive--;
                goldPerClick -= waterGold;
                goldPerSec -= waterGold2;
                upgradedWater = true;
                ColorBlock colors = addWaterBtn.colors;
                colors.selectedColor = Color.red;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(250, 0, 50, 255);
                addWaterBtn.colors = colors;
                waterY = false;
                
            }
        }

        
    }




    // level items
    void lvlSolarX()
    {
        if (solarX && energy >= 1000 * Mathf.Pow(1.07f, solarLvl - 1) * (solarLvl + 2))
        {
            energy -= 1000 * Mathf.Pow(1.07f, solarLvl - 1) * (solarLvl + 2);
            solarLvl++;
            item.createSolar(solarLvl);
            SSTools.ShowMessage("Level " + solarLvl + " Solar Panel built.", SSTools.Position.top, SSTools.Time.twoSecond);

            solarGold = item.itemEnergy;
            solarGold2 = item.itemPerSec;

            goldPerClick += solarGold;
            goldPerSec += solarGold2;
        }
        else
        {
            if (energy <= 1000 * Mathf.Pow(1.07f, solarLvl - 1) * (solarLvl + 2))
                SSTools.ShowMessage("You're missing $" + (energy - (1000 *Mathf.Pow(1.07f, solarLvl - 1) * (solarLvl + 2))) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }

    void lvlWindmillX()
    {
        Debug.Log(1000 * Mathf.Pow(1.07f, windmillLvl - 1) * (windmillLvl + 2));
        if (windmillX && energy >= 1000 * Mathf.Pow(1.07f, windmillLvl - 1) * (windmillLvl + 2))
        {
            energy -= 1000 * Mathf.Pow(1.07f, windmillLvl - 1) * (windmillLvl + 2);
            windmillLvl++;
            item.createWindmill(windmillLvl);
            SSTools.ShowMessage("Level " + windmillLvl + " Windmill built.", SSTools.Position.top, SSTools.Time.twoSecond);

            windmillGold = item.itemEnergy;
            windmillGold2 = item.itemPerSec;

            goldPerClick += windmillGold;
            goldPerSec += windmillGold2;
        }
        else
        {
            if (energy <= 1000 * Mathf.Pow(1.07f, windmillLvl - 1) * (windmillLvl + 2))
                SSTools.ShowMessage("You're missing $" + (energy - (1000 * Mathf.Pow(1.07f, windmillLvl - 1) * (windmillLvl + 2))) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }

    void lvlPowerX()
    {
        if (powerX && energy >= 500 * Mathf.Pow(1.07f, powerpLvl - 1) * (powerpLvl + 3))
        {
            energy -= 500 * Mathf.Pow(1.07f, powerpLvl - 1) * (powerpLvl + 3);
            powerpLvl++;
            item.createPowerp(powerpLvl);
            SSTools.ShowMessage("Level " + powerpLvl + " Power Plant built.", SSTools.Position.top, SSTools.Time.twoSecond);


            powerGold = item.itemEnergy;
            powerGold2 = item.itemPerSec;

            goldPerClick += powerGold;
            goldPerSec += powerGold2;
        }
        else
        {
            if (energy <= 500 * Mathf.Pow(1.07f, powerpLvl - 1) * (powerpLvl + 3))
                SSTools.ShowMessage("You're missing $" + (energy - (500 *(Mathf.Pow(1.07f, powerpLvl - 1) * (powerpLvl + 3)))) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }

    void lvlPotatX()
    {
        if (energy >= 50 * (Mathf.Pow(1.07f, potatLvl - 1) * (potatLvl + 5)))
        {
            energy -= 50 * ((Mathf.Pow(1.07f, potatLvl - 1) * (potatLvl + 5)));
            potatLvl++;
            item.createPotat(potatLvl);
            SSTools.ShowMessage("Level " + potatLvl + " Potato built.", SSTools.Position.top, SSTools.Time.twoSecond);

            potatGold = item.itemEnergy;
            potatGold2 = item.itemPerSec;

            goldPerClick += potatGold;
            goldPerSec += potatGold2;
        }
        else
        {
            if(energy <= 50 * ((Mathf.Pow(1.07f, potatLvl - 1) * (potatLvl + 5))))
                SSTools.ShowMessage("You're missing $" + (energy - (50 * ((Mathf.Pow(1.07f, potatLvl - 1) * (potatLvl + 5))))) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }   
    }

    void lvlHamX()
    {
        if (hamsterX && energy >= 50 * Mathf.Pow(1.07f, hamsterLvl - 1) * (hamsterLvl + 5))
        {
            energy -= 50 * (Mathf.Pow(1.07f, hamsterLvl - 1) * (hamsterLvl + 5));
            hamsterLvl++;
            item.createHamster(hamsterLvl);
            SSTools.ShowMessage("Level " + hamsterLvl + " Hamster wheel built.", SSTools.Position.top, SSTools.Time.twoSecond);

            hamsterGold = item.itemEnergy;
            hamsterGold2 = item.itemPerSec;

            goldPerClick += hamsterGold;
            goldPerSec += hamsterGold2;
        }
        else
        {
            if (energy <= 50 * Mathf.Pow(1.07f, hamsterLvl - 1) * (hamsterLvl + 5))
                SSTools.ShowMessage("You're missing $" + (energy - (50 *(Mathf.Pow(1.07f, hamsterLvl - 1) * (hamsterLvl + 5)))) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }

    void lvlWaterX()
    {
        if (waterX && energy >= 120 * Mathf.Pow(1.07f, waterLvl - 1) * (waterLvl + 5))
        {
            energy -= 120 * Mathf.Pow(1.07f, waterLvl - 1) * (waterLvl + 5);
            waterLvl++;
            item.createWater(waterLvl);
            SSTools.ShowMessage("Level " + waterLvl + " Water Turbine built.", SSTools.Position.top, SSTools.Time.twoSecond);

            waterGold = item.itemEnergy;
            waterGold2 = item.itemPerSec;

            goldPerClick += waterGold;
            goldPerSec += waterGold2;
        }
        else
        {
            if (energy <= 120 * Mathf.Pow(1.07f, waterLvl - 1) * (waterLvl + 5))
                SSTools.ShowMessage("You're missing $" + (energy - (120 * (Mathf.Pow(1.07f, waterLvl - 1) * (waterLvl + 5)))) + ".", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }
        
}

