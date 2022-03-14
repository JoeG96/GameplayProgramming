using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{

    public TextMeshPro useText;
    public Transform playerObject;
    public float maxUseDistance = 5f;
    public LayerMask useLayers;

    public void OnInteract()
    {
        if (Physics.Raycast(playerObject.position, playerObject.forward, out RaycastHit hit, maxUseDistance, useLayers))
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                if (door.isOpen)
                {
                    door.Close();
                }
                else
                {
                    door.Open(transform.position);
                }
            }
        }
    }

    private void Update()
    {
        if (Physics.Raycast(playerObject.position, playerObject.forward, out RaycastHit hit, maxUseDistance, useLayers) 
            && hit.collider.TryGetComponent<Door>(out Door door))
        {
            if (door.isOpen)
            {
                useText.SetText("Close \"X\"");
            }
            else
            {
                useText.SetText("Open \"X\"");
            }
            useText.gameObject.SetActive(true);
            useText.transform.position = hit.point - (hit.point - playerObject.position).normalized * 0.01f;
            useText.transform.rotation = Quaternion.LookRotation((hit.point - playerObject.position).normalized);
        }
        else
        {
            useText.gameObject.SetActive(false);
        }
    }
}
