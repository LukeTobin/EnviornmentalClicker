using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sidebar : MonoBehaviour
{ 
    
    public GameObject Panel;
    public GameObject Tips;

    public Button OpenMenuBtn;
    public Button EcoCat;
    public Button Tap;

    public Text tipText; 

    int counter;
    int counter2;

    void Start()
    {
        OpenMenuBtn.onClick.AddListener(showhidePanel);
        EcoCat.onClick.AddListener(showhideTips);
        Tap.onClick.AddListener(closeWhatever);
        Panel.gameObject.SetActive(false);
        Tips.gameObject.SetActive(false);
    }

    public void showhidePanel()
    {
        counter++;
        if(counter % 2 == 1)
        {
            Panel.gameObject.SetActive(true);
        }
        else
        {
            Panel.gameObject.SetActive(false);
        }
    }

    public void showhideTips()
    {
        counter2++;
        if (counter2 % 2 == 1)
        {
            Tips.gameObject.SetActive(true);
            int randTip = Random.Range(0, 39);
            if (randTip == 0)
            {
                tipText.text = "Save glass jars and re-use them as containers!";
            }
            else if (randTip == 1)
            {
                tipText.text = "Don’t forget to turn off lights and air conditioning when you leave the room. This will reduce your energy consumption!";
            }
            else if (randTip == 2)
            {
                tipText.text = "To reduce plastic pollution, you could use reusable water bottles and cups! Try avoiding plastic straws, most of them end up in the ocean!";
            }
            else if (randTip == 3)
            {
                tipText.text = "Invest in some reusable food containers to reduce waste! Besides reducing food waste you’ll also reduce plastic pollution!";
            }
            else if (randTip == 4)
            {
                tipText.text = "Donate old clothes to charity and old devices to schools or other institutions if they are still in a good shape! This will bring you some money and your stuff won’t go to waste!";
            }
            else if (randTip == 5)
            {
                tipText.text = "Try installing solar panels or solar water heating in your home. This will greatly reduce your carbon footprint!";
            }
            else if (randTip == 6)
            {
                tipText.text = "Try eating vegetarian more often! Producing meat costs great amounts of energy and water. Eating vegetarian or vegan once in a while will reduce this waste.";
            }
            else if (randTip == 7)
            {
                tipText.text = "Change your energy supplier to one that’s 100% renewable. It’s simple to switch and hassle-free! And you’ll reduce your carbon footprint!";
            }
            else if (randTip == 8)
            {
                tipText.text = "Bring a reusable grocery bag to the store when you shop! That way you’re not dependent on plastic bags that get thrown away most of the time!";
            }
            else if (randTip == 9)
            {
                tipText.text = "Try buying things locally, that way you’ll cut down on transportation, congestion and pollution!";
            }
            else if (randTip == 10)
            {
                tipText.text = "Try line drying your clothes instead of using a dryer! ";
            }
            else if (randTip == 11)
            {
                tipText.text = "Try to use your car less to help reduce global warming. Walking or cycling are alternatives that are also good for your health! If that’s not an option you could try carpooling or using public transport!";
            }
            else if (randTip == 12)
            {
                tipText.text = "Recycling is an easy way to lessen the pollution of our soil, oceans, water sources and more! Taking a few seconds to recycle your trash will greatly help you combat pollution!";
            }
            else if (randTip == 13)
            {
                tipText.text = "Put on an extra layer of clothing instead of turning up the heating. This will also save you some money on your energy bill!";
            }
            else if (randTip == 14)
            {
                tipText.text = "Open up the blinds instead of turning on the lights. A bit of sunshine will brighten up your day!";
            }
            else if (randTip == 15)
            {
                tipText.text = "Try shortening your shower time and cut out long baths! This way you can reduce water waste!";
            }
            else if (randTip == 16)
            {
                tipText.text = "Turn off devices you aren’t using instead of letting them stay in standby mode!";
            }
            else if (randTip == 17)
            {
                tipText.text = "Try taking the stairs instead of the elevator! This will be a good workout as well!";
            }
            else if (randTip == 18)
            {
                tipText.text = "Invest in better quality items that last longer. Whether it’s fashion items, furniture, or anything else!";
            }
            else if (randTip == 19)
            {
                tipText.text = "Buy items that are ethical and environmentally conscious!";
            }
            else if (randTip == 20)
            {
                tipText.text = "Limit the amount of water you use to brush your teeth!";
            }
            else if (randTip == 21)
            {
                tipText.text = "Start using rechargeable batteries and solar chargers for your electronic devices!";
            }
            else if (randTip == 22)
            {
                tipText.text = "Remember to turn off the lights when you leave your room!";
            }
            else if (randTip == 23)
            {
                tipText.text = "Try to let your hair air dry instead of using a dryer! The heat damages your hair anyways!";
            }
            else if (randTip == 24)
            {
                tipText.text = "If you eat meat, try to stick to “bio” meat! That way you can at least stop supporting mass meat production that has high carbon dioxide emissions!";
            }
            else if (randTip == 25)
            {
                tipText.text = "Buy seasonal fruit and vegetables! Non-seasonal fruit and vegetables need to be flown in, which is bad for our planet!";
            }
            else if (randTip == 26)
            {
                tipText.text = "If you want to, you can think about supporting environment-friendly organizations, such as WWF and Greenpeace. ";
            }
            else if (randTip == 27)
            {
                tipText.text = "Try to avoid plastic packaging or articles that are wrapped in countless layers of plastic! It is hard to recycle and harms the environment!";
            }
            else if (randTip == 28)
            {
                tipText.text = "Don’t leave your window cracked in winter when the heating is on! Instead, open all windows for five minutes and then close them shut. This way you’ll get fresh air without having to have extra heating on.";
            }
            else if (randTip == 29)
            {
                tipText.text = "Try to avoid ordering food! Most of the items come in plastic containers or produce a lot of waste! Instead, either go out for food or cook it yourself!";
            }
            else if (randTip == 30)
            {
                tipText.text = "Tap water not only has 0 calories, but also produces no waste! Cut out plastic bottles and instead use reusable ones that you can fill with tap water!";
            }
            else if (randTip == 31)
            {
                tipText.text = "Put a “no junk mail” sign on your door in order to limit the amount of paper you consume!";
            }
            else if (randTip == 32)
            {
                tipText.text = "A lot of companies have the option of getting e-mails instead of paper mail. Try switching to that to keep your paper waste low!";
            }
            else if (randTip == 33)
            {
                tipText.text = "Try growing your own herbs! You don’t need a big garden for that, but if you want to grow your own vegetables, you can participate in a community garden!";
            }
            else if (randTip == 34)
            {
                tipText.text = "Buy second-hand clothing! Thrift stores are becoming more and more popular and the clothes are way cheaper than in normal clothing stores!";
            }
            else if (randTip == 35)
            {
                tipText.text = "Low-flow showerheads keep provide your shower with a lower waterflow and will save you liters of water (and money) once installed!";
            }
            else if (randTip == 36)
            {
                tipText.text = "Try to stick to non-toxic cleaners such as borax, vinegar, baking soda or lemon juice! Toxic cleaners are bad for the environment and non-toxic ones do just as good of a job!";
            }
            else if (randTip == 37)
            {
                tipText.text = "If you have a garden, store rainwater in buckets and use that for watering your plants!";
            }
            else if (randTip == 38)
            {
                tipText.text = "Use washable cloths instead of paper towels or napkins! Those are 0 waste and stay with you for a very long time!";
            }
            else
            {

            }

        }
        else
        {
            Tips.gameObject.SetActive(false);
        }
    }

    public void closeWhatever()
    {
        if (counter2 % 2 == 1)
        {
            Tips.gameObject.SetActive(false);
            counter2++;
        }

        if (counter % 2 == 1)
        {
            Panel.gameObject.SetActive(false);
            counter++;
        }
    }
}
