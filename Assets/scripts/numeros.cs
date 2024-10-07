      using UnityEngine;

public class Numeros : MonoBehaviour
{
    private float vel;
    private  Vector2 minPantalla;

    [SerializeField] private Sprite[] arraySpritesNumeros = new Sprite[9];

    // Start is called once before the first execution of Update after the MonoBehaviour is create
    // d

    private int ValorNumero;
    [SerializeField] private GameObject prefabExplosio;

    void Start()
    {
        vel = 3f;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        System.Random numAleatori = new System.Random();
        ValorNumero = numAleatori.Next(1, 9);
        GetComponent<SpriteRenderer>().sprite = arraySpritesNumeros[ValorNumero];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual = posActual + new Vector2(0, -1) * vel * Time.deltaTime;
        transform.position = posActual;

        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Jugador" || objecteTocat.tag == "ProjectilJugador")
        {
            GameObject explosio = Instantiate(prefabExplosio);
            explosio.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
