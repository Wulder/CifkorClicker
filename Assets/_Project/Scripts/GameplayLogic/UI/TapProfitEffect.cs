using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CifkorClicker 
{
    public class TapProfitEffect : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _pool;
        [SerializeField] private float _appearingDuration, _movePosition;
        [SerializeField] private Ease _ease;
        [SerializeField] private Vector2 _randomXRange;
        private int _lastIndexFromPool = 0;

        private void OnEnable()
        {
            Init();
        }
        public void DoEffect(double amount)
        {
            if (_lastIndexFromPool >= _pool.Length) _lastIndexFromPool = 0;

            _pool[_lastIndexFromPool].text = amount.ToString("#.##");
            var obj = _pool[_lastIndexFromPool].gameObject;
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);
            obj.transform.DOKill();
            obj.transform.position = transform.position;
            obj.transform.DOScale(Vector3.zero, _appearingDuration).SetDelay(_appearingDuration / 2);
            obj.transform.DOMove(obj.transform.position + new Vector3(Random.Range(_randomXRange.x,_randomXRange.y), _movePosition,0), _appearingDuration).SetEase(_ease).OnComplete(() =>
            {
                obj.transform.localScale = Vector3.one;
                obj.transform.gameObject.SetActive(false);
            });

            _lastIndexFromPool++;
        }

       

        private void Init()
        {
            foreach (var obj in _pool)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
}
