using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _speed;

    private Vector3 _moveDirection;            

    private void Start()
    {
        _moveDirection = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)             
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
        else if (other.TryGetComponent(out Obstacle obstacle))                 
            {
                Bounce();
                Debug.Log(obstacle);
            }      
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;         
        Rigidbody rb = GetComponent<Rigidbody>();           // получаем Rigidbody только сейчас, потому что он нужен только для отскока        
        rb.AddExplosionForce(_explosionForce, transform.position + new Vector3(0, -1, 1), _explosionRadius);     
    }
}

    
    