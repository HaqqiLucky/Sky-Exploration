using TMPro;
using UnityEngine;

public class SceneControlMainMenu : MonoBehaviour
{

    [Header("Spawn bintang")]
    [SerializeField] private GameObject starPrefab;
    private int totalStars = 52;

    private float minX = -2.7f;
    private float maxX = 2.7f;
    private float minY = -4.9f;
    private float maxY = 4.9f;


    [Header("Version")]
    [SerializeField] private TMP_Text versionNow;

    [Header("Line Renderer")]
    [SerializeField] private Transform[] points;
    [SerializeField] private LineController lc;
    
    void Start()
    {
        SpawnStars();
        AmbilVersiApp();
        lc.SetUpLine(points);
    }

    private void SpawnStars()
    {
        for (int i = 0; i < totalStars; i++)
        {
            // Acak posisi antara min dan max
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 randomPos = new Vector3(randomX, randomY, 0f);

            // Instantiate prefab
            Instantiate(starPrefab, randomPos, Quaternion.identity);
        }
    }

    private void AmbilVersiApp()
    {
        versionNow.text = "V" + Application.version;
    }
}
