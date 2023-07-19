using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public new ParticleSystem particleSystem;
    public float timeToHide = 3;
    public GameObject graphicItens;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void HideItens()
    {
        if (graphicItens != null) graphicItens.SetActive(false);
        Invoke("HideObject", timeToHide);
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null)
        {
            particleSystem.transform.SetParent(null);
            particleSystem.Play();
        }

        if (audioSource != null) audioSource.Play();
    }

}
