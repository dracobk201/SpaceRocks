using System.Collections;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifespan = 2f;

    private void OnEnable()
    {
        StopCoroutine(DesactivateProjectile());
        StartCoroutine(DesactivateProjectile());
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    private IEnumerator DesactivateProjectile()
    {
        yield return new WaitForSeconds(lifespan);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            gameObject.SetActive(false);
        }
    }
}
