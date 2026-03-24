using System.Collections;
using UnityEngine;

public class ScarabDetectScript : MonoBehaviour
{

    [SerializeField] private int blinksToDetect = 3;
    [SerializeField] private int blinkCounter;

    public Light scarabLight;
    public float baseLightIntensity;
    public float baseEmissiveMatIntensity;
    public Renderer bulbMat;

    [SerializeField] private float blinkTimer;

    [SerializeField] private Coroutine blinkRoutine;

    [SerializeField] private bool enemyInSight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyInSight)
        {

            if(blinkTimer <= 0)
            {

                blinkTimer = 5;
                Debug.Log("Blink!");
                Blink();

            }

        }

        if(scarabLight.intensity >= 0)
        {

            scarabLight.intensity -= Time.deltaTime * 20;

        }

        blinkTimer -= Time.deltaTime;

    }

    private void Blink()
    {

        scarabLight.intensity = baseLightIntensity;
        blinkCounter++;

    }

}
