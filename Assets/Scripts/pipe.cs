using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;
    private Bird bird;

    void Start()
    {
        bird = FindObjectOfType<Bird>();
    }

    void Update()
    {
        if (!bird.isGameOver)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Ekranın soluna ulaştığında boruyu yok et
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
