using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.BroadcastMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
