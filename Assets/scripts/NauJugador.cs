using UnityEngine;

public class Naujugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minpantalla, maxPantalla;

    public object ViewsportToWorldPoint { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _vel = 8f;

        minPantalla = Camera.main.ViewsportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewsportToWorldPoint(new Vector2(1, 1));

    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);
        Vector2 direccioindicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position; // pos actual de la nau 
        novaPos = novaPos + direccioindicada * _vel * Time.deltaTime;
        // Debug.Log(Time.deltaTime);


        novaPos.x = Mathf.Clamp (novaPos.x, minpantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minpantalla.y, maxPantalla.y);

        transform.position = novaPos;

    }
}
