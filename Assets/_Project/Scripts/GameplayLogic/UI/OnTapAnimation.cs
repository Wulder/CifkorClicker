using DG.Tweening;
using UnityEngine;

namespace CifkorClicker 
{
    public class OnTapAnimation : MonoBehaviour
    {
        [SerializeField] private float _shakeDuration = 0.1f, _strength = 0.1f;
        [SerializeField] int _vibrato = 10;
       public void Animate()
        {
            transform.DOKill();
            transform.localScale = Vector3.one;
            transform.DOShakeScale(_shakeDuration,_strength, _vibrato);
        }
    }
}
