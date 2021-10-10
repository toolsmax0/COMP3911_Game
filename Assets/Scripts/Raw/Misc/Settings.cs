using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public Slider jumpQueueSlider;
    public static double jumpQueueProb = 0; // 顾客是否插队

    

    public static int maxNumOfCustomers = 3; // 同时出现顾客的最大数量

    public Slider paymentSlider;

    public static double paymentProb = 0.5; // 顾客询问支付手段的概率

    public static bool voiceEnabled = false;

}
