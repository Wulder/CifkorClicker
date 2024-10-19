
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

        public void FullEnergy()
        {
            ClickerApplication.Instance.UserDataHandler.SetEnergy(1000);
        }
    }
}
