using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CifkorClicker
{
    public class LocalDataTransfer : DataTransfer
    {
        public LocalDataTransfer()
        {
            _sender = new LocalDataSender();
            _receiver = new LocalDataReceiver();
        }
    }
}
