using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;      // Boru oluşma süresi
    public float gapSize = 2f;        // Borular arasındaki boşluk
    public float minHeight = -1f;     // Boruların alt sınırı
    public float maxHeight = 3f;      // Boruların üst sınırı
    private Bird bird;

    void Start()
    {
        bird = FindObjectOfType<Bird>();
        InvokeRepeating("SpawnPipePair", 0f, spawnRate);
    }

    void SpawnPipePair()
    {
        if (!bird.isGameOver)
        {
            // Rastgele bir yükseklik belirleyerek borular arasındaki boşluğu oluşturuyoruz
            float randomHeight = Random.Range(minHeight, maxHeight);

            // Üst ve alt boruları ayarlıyoruz
            Vector3 topPipePosition = transform.position + new Vector3(0, randomHeight + gapSize / 2, 0);
            Vector3 bottomPipePosition = transform.position + new Vector3(0, randomHeight - gapSize / 2, 0);

            Instantiate(pipePrefab, topPipePosition, Quaternion.identity);   // Üst boru
            Instantiate(pipePrefab, bottomPipePosition, Quaternion.Euler(0, 0, 180)); // Alt boru (ters çevirilmiş)
        }
    }
}
