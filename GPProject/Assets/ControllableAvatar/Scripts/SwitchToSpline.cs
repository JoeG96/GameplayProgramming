using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace PathCreation
{
    public class SwitchToSpline : MonoBehaviour
    {
        [Header("Cameras")]
        [SerializeField] CinemachineFreeLook freeLookCam;
        [SerializeField] CinemachineVirtualCamera splineCam;

        [Header("Path")]
        [SerializeField] PathCreator pathCreator;
        [SerializeField] EndOfPathInstruction endOfPathInstruction;
        [SerializeField] float speed;
        private float distanceTravelled;

        [Header("Objects")]
        [SerializeField] GameObject playerObject;
        private Rigidbody rigidBody;

        private PlayerLocomotion playerLocomotion;
        private InputManager inputManager;

        private void OnTriggerEnter(Collider other)
        {
            if (pathCreator != null)
            {
                // Notifies if path changed during the game
                pathCreator.pathUpdated += OnPathChanged;
                rigidBody = playerObject.GetComponent<Rigidbody>();

                splineCam.Priority = 11;
                freeLookCam.Priority = 1;

                playerLocomotion = playerObject.GetComponent<PlayerLocomotion>();
                inputManager = playerObject.GetComponent<InputManager>();

            }
        }

        private void OnTriggerStay(Collider other)
        {
            
            rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        }

        private void OnTriggerExit(Collider other)
        {
            freeLookCam.Priority = 11;
            splineCam.Priority = 1;
            rigidBody.constraints = RigidbodyConstraints.None;
        }

        private void Update()
        {
            if (inputManager.moveAmount > 1)
            {
                distanceTravelled += inputManager.moveAmount * Time.deltaTime;
            }
            else
            {
                distanceTravelled -= inputManager.moveAmount * Time.deltaTime;
            }    
            playerObject.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            //playerObject.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }

        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(playerObject.transform.position);
        }
    }
}


