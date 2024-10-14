using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Naujugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefabProyectil;
    [SerializeField] private GameObject prefabExplosio;

    private int videsNau;

    [SerializeField] TMPro.TextMeshProUGUI textvidesNau;

    public string PantallaResultat { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _vel = 8f;

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float meitatMidaimatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float meitatMidaimatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;


        minPantalla.x = minPantalla.x + meitatMidaimatgeX;
        maxPantalla.x = maxPantalla.x - meitatMidaimatgeX;
        minPantalla.y += meitatMidaimatgeY;
        maxPantalla.y -= meitatMidaimatgeY;

        videsNau = 3;


    }

    // Update is called once per frame
    void Update()
    {
        MoureNau();
        DispararProyectil();

    }

    private void DispararProyectil()
    {
        if (Input.GetKeyDown(name: "space"))
        {
            GameObject proyectil = Instantiate(prefabProyectil);
            proyectil.transform.position = transform.position;
        }
    }


    private void MoureNau()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);
        Vector2 direccioindicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position; // pos actual de la nau 
        novaPos = novaPos + direccioindicada * _vel * Time.deltaTime;
        // Debug.Log(Time.deltaTime);


        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;

    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        Debug.Log("hola");
        if (objecteTocat.tag == "Numero")
        {
            videsNau--;
            textvidesNau.text = "Vides: " + videsNau.ToString();


            if (videsNau <= 0)
            {
                GameObject explosio = Instantiate(prefabExplosio);
                explosio.transform.position = transform.position;

                SceneManager.LoadScene("PantallaResultat");

                Destroy(gameObject);

            }
        }
    }

}

