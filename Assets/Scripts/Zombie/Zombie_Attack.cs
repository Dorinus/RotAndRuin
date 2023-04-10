using UnityEngine;

public class Zombie_Attack : MonoBehaviour
{
    [SerializeField]
    private int damage = 15;




    public int Damage
    {
        get
        {
            return damage;
        }
    }

}