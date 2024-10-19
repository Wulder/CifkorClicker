using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    public class ClickerApplication : MonoBehaviour
    {
        //� ������ �������� ������ ����� ��������� ���������� DI.
        //� ������ ������ ����� ClickerApplication ����� ������� � ���� �������� ������ ��� ������ ����������

        private static ClickerApplication _instance;
        public static ClickerApplication Instance => _instance;

        //���������� � ������������ � ��� �������
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
