using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        TestWaves testWaves = other.GetComponent<TestWaves>();
        if (testWaves != null)
            Destroy(this.gameObject);
    }
}
