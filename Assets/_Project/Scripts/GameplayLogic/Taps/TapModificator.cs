
using UnityEngine;

namespace CifkorClicker 
{
    public abstract class TapModificator : MonoBehaviour
    {
        public virtual double GetAddition(double sourceCount)
        {
            return 0;
        }
    }
}
