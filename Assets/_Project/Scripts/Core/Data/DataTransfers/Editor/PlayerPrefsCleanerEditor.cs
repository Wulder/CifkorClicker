using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CifkorClicker 
{
    [CustomEditor(typeof(PlayerPrefsCleaner))]
    public class PlayerPrefsCleanerEditor : Editor
    {
        PlayerPrefsCleaner _cleaner;

        private void OnEnable()
        {
            _cleaner = (PlayerPrefsCleaner)target;
        }
        public override void OnInspectorGUI()
        {
            if(GUILayout.Button("Clear"))
            {
                _cleaner.Clear();
            }
        }
    }
}
