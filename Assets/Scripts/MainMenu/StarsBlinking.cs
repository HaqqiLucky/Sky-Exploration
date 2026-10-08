using UnityEngine;

public class StarsBlinking : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    [Header("Alpha Limits (0-255)")]
    public float minAlphaLimit = 7f;
    public float maxAlphaLimit = 210f; // Turun dari 255 ke 210 biar gak terlalu terang

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Mengonversi batas alpha 0-255 ke skala 0.0-1.0 yang digunakan SpriteRenderer
        float minAlpha = minAlphaLimit / 255f;
        float maxAlpha = maxAlphaLimit / 255f;

        // Set alpha awal secara acak di antara batas yang telah ditentukan
        float initialAlpha = Random.Range(minAlpha, maxAlpha);
        SetAlpha(initialAlpha);

        // Mulai siklus kedip pertama
        FadeToMax();
    }

    void FadeToMax()
    {
        // Mengonversi batas alpha maksimal ke skala 0.0-1.0
        float maxAlpha = maxAlphaLimit / 255f;

        // Mengacak durasi transisi naik dan durasi diam di titik terang
        float fadeDuration = Random.Range(0.5f, 1.5f); // Berapa lama waktu untuk mencapai maxAlpha
        float stayDuration = Random.Range(0.1f, 0.6f); // Berapa lama diam di maxAlpha

        LeanTween.value(gameObject, GetAlpha(), maxAlpha, fadeDuration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnUpdate((float val) => SetAlpha(val))
            .setOnComplete(() =>
            {
                // Setelah mencapai maxAlpha, tahan selama 'stayDuration', lalu panggil FadeToMin
                LeanTween.delayedCall(gameObject, stayDuration, FadeToMin);
            });
    }

    void FadeToMin()
    {
        // Mengonversi batas alpha minimal ke skala 0.0-1.0
        float minAlpha = minAlphaLimit / 255f;

        // Mengacak durasi transisi turun dan durasi diam di titik redup
        float fadeDuration = Random.Range(0.5f, 1.5f); // Berapa lama waktu untuk mencapai minAlpha
        float stayDuration = Random.Range(0.2f, 0.8f); // Berapa lama diam di minAlpha

        LeanTween.value(gameObject, GetAlpha(), minAlpha, fadeDuration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnUpdate((float val) => SetAlpha(val))
            .setOnComplete(() =>
            {
                // Setelah mencapai minAlpha, tahan selama 'stayDuration', lalu panggil FadeToMax lagi
                LeanTween.delayedCall(gameObject, stayDuration, FadeToMax);
            });
    }

    void SetAlpha(float alpha)
    {
        // Pastikan alpha tidak keluar dari batas
        alpha = Mathf.Clamp01(alpha);
        Color c = spriteRenderer.color;
        c.a = alpha;
        spriteRenderer.color = c;
    }

    float GetAlpha()
    {
        return spriteRenderer.color.a;
    }
}
