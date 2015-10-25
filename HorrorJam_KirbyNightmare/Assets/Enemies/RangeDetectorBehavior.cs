using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Enemies
{
    
    class RangeDetectorBehavior : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                this.SendMessage("OnPlayerEnterRange");
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                this.SendMessage("OnPlayerExitRange");
            }
        }
    }
}
