using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delayBetweenShoots;             
    [SerializeField] private float _tankMoveDistance;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;              
        if (Input.GetMouseButton(0))                    
        {            
            if (_timeAfterShoot > _delayBetweenShoots)      
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _tankMoveDistance, _delayBetweenShoots / 2).SetLoops(2,LoopType.Yoyo); 
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
    }
}
