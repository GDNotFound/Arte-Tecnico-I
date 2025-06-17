using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Fireball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] float _speed = 10;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Transform _explosionPivot;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        Vector3 impulse = transform.up * _speed;
        _rigidbody.AddForce(impulse, ForceMode.Impulse);
    }
    private void OnDisable()
    {
        _rigidbody.linearVelocity = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        _explosion.transform.position = _explosionPivot.position;
        _explosion.SetActive(true);
        gameObject.SetActive(false);
    }
}
