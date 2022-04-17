using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private Vector2 lookDirection;
    private float lookAngle;
    private float maxWater = 100;
    private float maxSoap = 100; 

    [SerializeField] private Transform playerShot;
    [SerializeField] private GameObject waterBullet;
    [SerializeField] private GameObject soapBullet;

    public WaterBar waterbar;
    public SoapBar soapbar;
    // Start is called before the first frame update
    void Start()
    {
        waterbar.SetMaxWater(maxWater);
        soapbar.SetMaxSoap(maxSoap);
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetMouseButton(0) && maxWater > 0)
        {
            ShootWater();
            maxWater -= .1f;
            waterbar.SetWater(maxWater);
        }
        else if (Input.GetMouseButton(1) && maxSoap > 0) {
            ShootSoap();
            maxSoap -= .1f;
            soapbar.SetSoap(maxSoap);
        }
    }
    private void ShootWater()
    {
        GameObject waterShot = Instantiate(waterBullet, playerShot.position, playerShot.rotation);
        waterShot.GetComponent<Rigidbody2D>().velocity = playerShot.up * bulletSpeed;
    }

    private void ShootSoap()
    {
        GameObject soapShot = Instantiate(soapBullet, playerShot.position, playerShot.rotation);
        soapShot.GetComponent<Rigidbody2D>().velocity = playerShot.up * bulletSpeed;
    }
}
