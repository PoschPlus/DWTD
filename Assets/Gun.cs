using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] Bulit bulit;
    [SerializeField] Transform gunSpawnPos = null;
    [SerializeField] GameObject prefab;
    [SerializeField] PlayerInput playerInput;

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(prefab, gunSpawnPos.parent);
        playerInput = GetComponentInChildren<PlayerInput>();
    }
    private void OnEnable()
    {
        //playerInput.onActionTriggered += SpawnBulit;
        playerInput.onActionTriggered += PlayerInput_OnactionTriggered;
    }

    private void PlayerInput_OnactionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    private void OnDisable()
    {
        //playerInput.onActionTriggered -= SpawnBulit;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBulit(InputAction.CallbackContext context)
    {
        Debug.Log("Something");
        if (context.performed)
        {
            Debug.Log("gun shooting");
            Instantiate(bulit, transform.position, Quaternion.identity);
        }
    }
}
