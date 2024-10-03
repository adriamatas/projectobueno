using UnityEngine;

public class ProyectilJugador : MonoBehaviour
{
    private float _vel;
    private Vector2 maxPantalla;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _vel = 10f;
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posInicial = transform.position;
        posInicial = posInicial + new Vector2(0, 1) * _vel * Time.deltaTime;
        transform.position = posInicial;

        if (transform.position.y > maxPantalla.y)
        {
            Destroy(gameObject); 
        }
    }
}
