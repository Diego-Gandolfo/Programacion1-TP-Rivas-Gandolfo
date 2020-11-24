using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace OnceUponAMemory.Main
{
    public class FragmentosCounter : MonoBehaviour
    {
        TextMeshProUGUI CounterText;
        public static int Amount;

        void Start()
        {
            CounterText = GetComponent<TextMeshProUGUI>(); // Lo cambie por un MeshPro
        }

        void Update()
        {
            if (CounterText != null)  CounterText.text = Amount.ToString(); // Solo le puse un chequeo por las dudas
        }
    }
}
