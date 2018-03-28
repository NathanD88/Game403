using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoLogic : MonoBehaviour {

    public GameObject tornado;
    public Vector3 spawnValues;
    public int tornadoCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine (SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < tornadoCount; i ++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                Quaternion spawnRotation = new Quaternion();
                Instantiate(tornado, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
