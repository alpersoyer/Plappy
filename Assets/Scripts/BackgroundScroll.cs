using UnityEngine;

public class CloudScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Bulutların kayma hızı
    public GameObject cloud1; // İlk bulut sprite'ı
    public GameObject cloud2; // İkinci bulut sprite'ı

    void Update()
    {
        // Bulutların konumlarını sola kaydırıyoruz
        cloud1.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        cloud2.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Eğer bulut ekranın sol tarafına geçerse, sağ tarafa yerleştiriyoruz
        if (cloud1.transform.position.x <= -cloud1.GetComponent<SpriteRenderer>().bounds.size.x)
        {
            // cloud1, cloud2'nin sağ tarafına yerleşir
            cloud1.transform.position = new Vector3(cloud2.transform.position.x + cloud2.GetComponent<SpriteRenderer>().bounds.size.x, cloud1.transform.position.y, cloud1.transform.position.z);
        }

        if (cloud2.transform.position.x <= -cloud2.GetComponent<SpriteRenderer>().bounds.size.x)
        {
            // cloud2, cloud1'in sağ tarafına yerleşir
            cloud2.transform.position = new Vector3(cloud1.transform.position.x + cloud1.GetComponent<SpriteRenderer>().bounds.size.x, cloud2.transform.position.y, cloud2.transform.position.z);
        }
    }
}
