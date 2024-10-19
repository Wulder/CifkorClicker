using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker 
{
    //tool for clear PlayerPrefs
    public class PlayerPrefsCleaner : MonoBehaviour
    {

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
