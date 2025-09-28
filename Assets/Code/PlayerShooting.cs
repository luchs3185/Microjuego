using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerShooting : MonoBehaviour
{
    public BulletSpawner spawner;
    public float fireRate = 0.15f;
    private float nextFireTime = 0f;

    PlayerInput playerInput;
    InputAction fireAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    
        fireAction = playerInput.actions["Fire"];
    }

    void OnEnable()
    {
        fireAction.performed += Fire;
        fireAction.Enable();
    }

    void OnDisable()
    {
        fireAction.performed -= Fire;
        fireAction.Disable();
    }

   private void Fire(InputAction.CallbackContext ctx)
    {

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            spawner.SpawnBullet();
        }
    }

}
