using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 40;
    [SerializeField]
    private int speed = 10;

    private int timeToLive = 100;

    private void Awake() {
        Destroy(gameObject, timeToLive);
    }

    public int Damage
    {
        get
        {
            return damage;
        }
    }

    private void Update() {
        transform.position += Time.deltaTime * transform.forward * speed;
    }
}