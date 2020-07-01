using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tests : MonoBehaviour
{
    /*

    public Button energyBtn;
    public Text energyTag;

    public Button addBtn;

    public int energy;

    public Image peopleHappy;
    public Color peopleColor;

    public Image enviornment;
    public Color envioColor;

    public Image itemInView;

    public Items item = new Items();


    // sprites
    public Sprite windmill;
    public Sprite potat;
    public Sprite potatClicked;


    // Start is called before the first frame update
    void Start()
    {
        item.createItem(1, 1, 1, 0);

        StartCoroutine("StartCounter");
        energy = item.itemEnergy;

        peopleColor = peopleHappy.color;
        peopleColor = Color.red;

        envioColor = Color.green;

        energyBtn.onClick.AddListener(TaskOnClick);
        addBtn.onClick.AddListener(NewItem);
    }

    // Update is called once per frame
    void Update()
    {
        energyTag.text = "big dick energy: " + energy;
        peopleHappy.color = peopleColor;
        enviornment.color = envioColor;

        if (energy > 5)
        {
            peopleColor = Color.green;
        }
        else
        {
            peopleColor = Color.red;
        }
    }

    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(1f);
        energy += item.itemPerSec;
        if (energy > 0)
        {
            energy -= item.itemCost;
        }
        StartCoroutine("StartCounter");
    }

    void TaskOnClick()
    {
        energy += item.itemEnergy;
        if(item.itemLevel < 2)
        {
            StartCoroutine("ImageAnimate");
        }
    }

    void NewItem()
    {
        item.createItem(2, 5, 2, 1);
        itemInView.sprite = windmill;
    }


    IEnumerator ImageAnimate()
    {
        itemInView.sprite = potatClicked;
        yield return new WaitForSeconds(0.2f);
        itemInView.sprite = potat;
    }
*/
}
