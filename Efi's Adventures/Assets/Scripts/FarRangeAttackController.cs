using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarRangeAttackController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletPrefab;
    public Transform stationaryBullet;

    public float fireForce;
    public float inBetweenShots;
    public float rotationSpeed;
    private float shotDelay;
    private float firingAngle = 5f;


    void Update()
    {
        shotDelay += Time.deltaTime;
    }

    private void onTriggerStay(Collider other)
    {
        if(other.tag == "Efi")
        {
            Vector3 targetPosition = new Vector3(other.transform.position.x, bullet.transform.position.y, other.transform.position.z);
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - bullet.transform.position);

            targetRotation *= Quaternion.Euler(0, 180, 0);

            bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation, targetRotation, rotationSpeed);

            float angle = Quaternion.Angle(bullet.transform.rotation, targetRotation);

            if(angle < firingAngle && shotDelay >= inBetweenShots)
            {
                FireBullet();
                inBetweenShots = 0f;
            }

        }

    }

    private void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, stationaryBullet.position, Quaternion.identity);

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.AddForce(bullet.transform.forward * -fireForce);
        }

        Destroy(newBullet, 3f);
    }



}
