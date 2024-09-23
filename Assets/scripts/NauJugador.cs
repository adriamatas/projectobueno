using UnityEngine;

public class Naujugador : MonoBehaviour
{
    private float _vel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _vel = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);
        Vector2 direccioindicada = new Vector2(direccioIndicadaX, direccioIndicadaY);

        Vector2 novaPos = transform.position; // pos actual de la nau 
        novaPos = novaPos + direccioindicada * _vel * Time.deltaTime;
        // Debug.Log(Time.deltaTime);

        transform.position = novaPos;

    }
}
