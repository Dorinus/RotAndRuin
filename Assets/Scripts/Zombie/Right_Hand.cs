using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Hand : MonoBehaviour
{
    private GameObject hand_R;

    private Rigidbody hand_R_Rigidbody;
    private Zombie_Attack zombie_Attack;

    private void Start()
    {
        //hand_R = GameObject.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_R/Shoulder_R/Elbow_R/Hand_R");
        hand_R = transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_R/Shoulder_R/Elbow_R/Hand_R").gameObject;

        SphereCollider collider = hand_R.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.enabled = false;
        collider.radius = 0.2f;
        collider.center = new Vector3(0.1f, 0f, 0f);

        hand_R_Rigidbody = hand_R.AddComponent<Rigidbody>();
        hand_R_Rigidbody.useGravity = false;

        zombie_Attack = hand_R.AddComponent<Zombie_Attack>();
    }
    
    public void activateZombieAttack()
    {
        Debug.Log("Activated!");
        hand_R.GetComponent<Collider>().enabled = true;
    }
    
    public void deactivateZombieAttack()
    {
        Debug.Log("Deactivated!");
        hand_R.GetComponent<Collider>().enabled = false;
    }
}
