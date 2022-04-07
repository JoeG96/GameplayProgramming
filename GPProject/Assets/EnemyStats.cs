using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] Transform target;
    Rigidbody rigidBody;
    [SerializeField] float knockback = 10f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    public override void Die()
    {
        base.Die();

        // Death effects/animation go here
        
        Destroy(gameObject);
    }

    public override void TakeHit()
    {
        base.TakeHit();
        // What happens when enemy takes a hit
        Debug.Log("Take Hit Override");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Weapon Collision");
            Vector3 moveDirection = transform.position - target.transform.position;
            rigidBody.AddForce(moveDirection.normalized * -8000f, ForceMode.Impulse);
            Debug.Log("Move Direction: " + moveDirection);

        }
    }

}
