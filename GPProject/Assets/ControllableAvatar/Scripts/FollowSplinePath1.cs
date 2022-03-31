using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace PathCreation
{
    public class FollowSplinePath1 : MonoBehaviour
    {
        // Moves along path at constant speed
        // Depending on end of path instruction, loops, reverses or stops at end of path
        [SerializeField] PathCreator pathCreator;
        [SerializeField] EndOfPathInstruction endOfPathInstruction;
        [SerializeField] float speed = 5;
        float distanceTravelled;

        private InputManager inputManager;
        [SerializeField] GameObject playerObject;
        [SerializeField] CinemachineVirtualCamera splineCam;
        [SerializeField] CinemachineFreeLook freeLookCam;

        private Rigidbody rigidBody;

        private void Start()
        {
            if (pathCreator != null)
            {
                // Notifies if path changed during the game
                pathCreator.pathUpdated += OnPathChanged;
                rigidBody = playerObject.GetComponent<Rigidbody>();
            }
        }

        private void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

    }
}


