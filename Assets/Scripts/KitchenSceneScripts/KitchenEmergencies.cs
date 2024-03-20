using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenEmergencies : MonoBehaviour
{
    public float MinTime;
    public float MaxTime;
    public float Timer;

    // OIL FIRE
    public GameObject OilFireStart;
    public GameObject OilFireSpread;

    // OVEN FIRE
    public GameObject OvenSmoke;
    public GameObject OvenExplosion;

    // Start is called before the first frame update
    void Start()
    {
        OilFireStart.SetActive(false);
        OilFireSpread.SetActive(false);

        OvenSmoke.SetActive(false);
        OvenExplosion.SetActive(false);

        Timer = Random.Range(MinTime, MaxTime);
        StartOilFireScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
        Scene starts
        10s later -> pan catches on fire
        50s later -> pan fire strenghtens
        1min later -> fire spreads to whole stove if unattended
        10s later -> stove fire strengthens
    */
    void StartOilFireScene()
    {
        Invoke("StartOilFireEffect", 10.0f);
        Invoke("StrenghtenOilFireEffect", 60.0f);
        Invoke("StartOilFireSpreadEffect", 120.0f);
        Invoke("StrenghtenOilFireSpreadEffect", 130.0f);
    }

    void StartOilFireEffect()
    {
        OilFireStart.SetActive(true);
        Transform childTransform = OilFireStart.transform.Find("OilFireStartEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireStartEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            OilFireStartEffect.Play();
        }
    }

    void StrenghtenOilFireEffect()
    {   
        Transform childTransform = OilFireStart.transform.Find("OilFireStartEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireStartEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            var Emission = OilFireStartEffect.emission;
            Emission.rateOverTime = 30.0f;
        }
    }

    void StartOilFireSpreadEffect()
    {
        OilFireSpread.SetActive(true);
        Transform childTransform = OilFireStart.transform.Find("OilFireSpreadEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireSpreadEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            OilFireSpreadEffect.Play();
        }
    }

    void StrenghtenOilFireSpreadEffect()
    {   
        Transform childTransform = OilFireSpread.transform.Find("OilFireSpreadEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireSpreadEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            var Emission = OilFireSpreadEffect.emission;
            Emission.rateOverTime = 45.0f;
        }
    }

    public void ExtinguishOilFire()
    {
        OilFireStart.SetActive(false);
        OilFireSpread.SetActive(false);
    }
}
