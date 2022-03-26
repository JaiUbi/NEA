using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardLogic : MonoBehaviour
{
    public enum SUIT
    {
        HEARTS,
        SPADES,
        DIAMONDS,
        CLUBS
    }

    public enum VALUE
    {
        TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
    }

        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    
}
