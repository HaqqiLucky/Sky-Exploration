using UnityEngine;

public class IdleStars : MonoBehaviour
{
    private float moveSpeed = 0.4f;     // Kecepatan keliling gerakan
    private float moveDistance = 0.4f; // Batas seberapa jauh objek boleh bergeser dari posisi awal

    private Vector3 startPos;
    private float randomOffset;

    void Start()
    {
        // Simpan posisi awal objek saat pertama kali spawn
        startPos = transform.position;

        // Berikan offset acak supaya tiap objek tidak bergerak dengan pola yang sama persis
        randomOffset = UnityEngine.Random.Range(0f, 10f);
    }

    void Update()
    {
        // Menggunakan Mathf.Sin dan Mathf.Cos untuk menghasilkan gerakan melingkar/mengambang yang halus
        float x = Mathf.Sin(Time.time * moveSpeed + randomOffset) * moveDistance;
        float y = Mathf.Cos((Time.time * moveSpeed * 0.8f) + randomOffset) * moveDistance;

        // Terapkan ke posisi awal ditambah offset gerakan
        transform.position = startPos + new Vector3(x, y, 0f);
    }
}
