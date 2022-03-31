using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation
{
    public class FollowSplinePath : MonoBehaviour
    {
        // Moves along path at constant speed
        // Depending on end of path instruction, loops, reverses or stops at end of path
        [SerializeField] PathCreator pathCreator;
        [SerializeField] EndOfPathInstruction endOfPathInstruction;
        [SerializeField] float speed = 5;
        float distanceTravelled;

        private Rigidbody rigidBody;


        private void Start()
        {
            if (pathCreator != null)
            {
                Debug.Log("Path creator is not null");
                // Notifies if path changed during the game
                pathCreator.pathUpdated += OnPathChanged;
                rigidBody = GetComponent<Rigidbody>();
            }
        }

        private void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                rigidBody.MovePosition( pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction));
                //Debug.Log(rigidBody.velocity);
                //Remove or enable to limit rotation of path object i.e. comment out to maintain rotation
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

    }
}


