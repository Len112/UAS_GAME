using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerLook : MonoBehaviour
{
    public Transform player;

    public float MouseSensitivity = 0f;

    private float x = 0;

    private float y = 0;

    public PlayerHealth playerhealth;
    public EnemyHealth enemyhealth;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth.CurrentHealth > 0 && enemyhealth.CurrentHealth > 0)
        {
            x += -Input.GetAxis("Mouse Y") * MouseSensitivity;
            y += Input.GetAxis("Mouse X") * MouseSensitivity;

            x = Mathf.Clamp(x, -90, 90);

            transform.localRotation = Quaternion.Euler(x, 0, 0);
            player.transform.localRotation = Quaternion.Euler(0, y, 0);
        }
    }
}
