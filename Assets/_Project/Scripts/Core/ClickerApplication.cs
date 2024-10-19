using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    public class ClickerApplication : MonoBehaviour
    {
        //в боевых проектах вместо этого синглтона используем DI.
        //в данном случае класс ClickerApplication будет держать в себе ключевые модули для работы приложения

        private static ClickerApplication _instance;
        public static ClickerApplication Instance => _instance;

        //информация о пользователе и его балансе
        private UserData _userData;
        public UserData UserData => _userData;

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
                Init();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning("Trying create other Application Object!");
                Destroy(this);
            }
        }
        
        private void Init()
        {
            _userData = new UserData();
        }
    }
}
