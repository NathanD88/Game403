// script to render explosion
using UnityEngine;
using System.Collections;

public class GraphicExplosion : MonoBehaviour {
    public float loopduration;
    private float ramptime=0;
    private float alphatime=1;

    private float radius = 20.0f;
    private float power = 100.0f;
    private void Start()
    {
        Vector3 explosionPos = this.gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Car"))
            {
                Rigidbody rb = hit.gameObject.transform.parent.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    hit.gameObject.transform.parent.GetComponent<Car>().TakeDamage(50);
                }
            }
        }
    }
    void Update () {
		Destroy(gameObject, 3);
        ramptime+=Time.deltaTime*2;
        alphatime-=Time.deltaTime;		
        float r = Mathf.Sin((Time.time / loopduration) * (2 * Mathf.PI)) * 0.5f + 0.25f;
        float g = Mathf.Sin((Time.time / loopduration + 0.33333333f) * 2 * Mathf.PI) * 0.5f + 0.25f;
        float b = Mathf.Sin((Time.time / loopduration + 0.66666667f) * 2 * Mathf.PI) * 0.5f + 0.25f;
        float correction = 1 / (r + g + b);
        r *= correction;
        g *= correction;
        b *= correction;
        GetComponent<Renderer>().material.SetVector("_ChannelFactor", new Vector4(r,g,b,0));
        GetComponent<Renderer>().material.SetVector("_Range", new Vector4(ramptime,0,0,0));
        GetComponent<Renderer>().material.SetFloat("_ClipRange", alphatime);
	}
}
