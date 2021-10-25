using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BagPanel.numBag=UnityEngine.Random.Range(13,31);
        gameObject.GetComponent<TMP_Text>().text="一共需要"+BagPanel.numBag+"个垃圾袋.";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
