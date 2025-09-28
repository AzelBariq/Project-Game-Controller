using UnityEngine;
using UnityEngine.UI; 

public class Character_Base : MonoBehaviour
{
    public int HP = 100;
    public float SPD = 2f;
    public int ATK = 10;
    public Slider healthBarSlider;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (healthBarSlider != null)
        {
            healthBarSlider.maxValue = HP;
            healthBarSlider.value = HP;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Kalau sudah mati, jangan kena damage lagi

        HP -= damage;

        if (healthBarSlider != null)
        {
            healthBarSlider.value = HP;
        }

        if (HP <= 0)
        {
            Die(); // HP habis → jalankan animasi mati
        }
    }

    protected virtual void Die()
    {
        isDead = true;
        animator.SetTrigger("Die"); // Mulai animasi mati
    }

    // Fungsi ini dipanggil lewat Animation Event di frame terakhir animasi death
    public void OnDeathAnimationFinished()
    {
        Destroy(gameObject); // Hilangkan object setelah animasi selesai
    }
}
