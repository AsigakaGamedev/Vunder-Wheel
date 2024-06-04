using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject gunBallPrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform gunBody;
    [SerializeField] private float shotForce = 40;
    [SerializeField] private Vector3 rotateAngle;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        laserPrefab.SetActive(false);
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play(); 
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(gunBody.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gunBody.localRotation = Quaternion.AngleAxis(angle, rotateAngle);

            laserPrefab.SetActive(true);

            GameObject newGunBall = Instantiate(gunBallPrefab, startPoint.position, Quaternion.identity);
            
            Rigidbody2D ballRb = newGunBall.GetComponent<Rigidbody2D>();
            ballRb.AddForce(startPoint.up * shotForce, ForceMode2D.Impulse);

            Destroy(newGunBall, 5);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            laserPrefab.SetActive(false);
        }
    }
}
