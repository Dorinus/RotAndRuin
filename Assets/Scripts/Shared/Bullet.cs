using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 40;
    [SerializeField]
    private int speed = 10;

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