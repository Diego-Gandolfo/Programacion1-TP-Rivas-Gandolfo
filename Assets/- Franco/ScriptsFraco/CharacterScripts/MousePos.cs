
using System.Net.Http.Headers;
using UnityEngine;


namespace OnceUponAMemory.Franco
{
    public class MousePos : MonoBehaviour
    {
        public Transform target;
        public float speed;
        public Camera mainCam;
  
        void Update()
        {
            //transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }
}

