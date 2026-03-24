using UnityEngine;

public class GunLight : MonoBehaviour
{

    public Light gunSpotLight;
    public float startSpotAngle;
    public float spotAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        spotAngle = startSpotAngle;

    }

    // Update is called once per frame
    void Update()
    {
        
        gunSpotLight.innerSpotAngle -= Time.deltaTime * 5f;
        gunSpotLight.spotAngle -= Time.deltaTime * 5f;

        if(gunSpotLight.innerSpotAngle <= 0)
        {     
            gunSpotLight.spotAngle = startSpotAngle;
            gunSpotLight.innerSpotAngle = startSpotAngle;

        }

    }
}
