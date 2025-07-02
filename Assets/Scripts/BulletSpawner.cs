using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    private AudioSource spawnSound;
    public AudioClip spawnClip;
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindFirstObjectByType<PlayerController>().transform;
        spawnSound = GetComponent<AudioSource>();

    }

   void Update()
{
    timeAfterSpawn += Time.deltaTime;

    if (timeAfterSpawn >= spawnRate)
    {
        if (spawnSound != null && spawnClip != null)
        {
            spawnSound.PlayOneShot(spawnClip);
        }
        timeAfterSpawn = 0f;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        bullet.transform.LookAt(target);
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
}
}