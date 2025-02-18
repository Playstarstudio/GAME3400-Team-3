using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public GameObject projectile;

    public GameObject rootObject;
    public float projectileSpeed = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot(){
        if(projectile){
            GameObject projectileObject = Instantiate(projectile, transform.position, rootObject.transform.rotation);
        

        Rigidbody rb = projectileObject.GetComponent<Rigidbody>();

        if(rb){
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);
        }
        }
    }
}
