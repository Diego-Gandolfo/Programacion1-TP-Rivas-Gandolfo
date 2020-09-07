using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class FragmentosCounter : MonoBehaviour
    {
        Text CounterText;
        public static int Amount;

        void Start()
        {
            
            CounterText = GetComponent<Text>();
            
        }

        void Update()
        {
            CounterText.text = Amount.ToString();
        }
    }
}
