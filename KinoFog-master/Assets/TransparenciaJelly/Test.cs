using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Range(0.1f, 1.0f)]
    public float fadeSpeed = 1f;    // How fast alpha value decreases.
    public Color fadeColor = new Color(0, 0, 0, 0);

    public Material m_cabeza;    // Used to store material reference.
    public Material m_tentaculos;
    public Material m_interior;
    private Color m_Color;            // Used to store color reference.
    Color m_Color_tentaculos;
    Color m_Color_interior;


    void Start()
    {
        // Get reference to object's material.
       // m_Material = GetComponent<Renderer>().material;

        // Get material's starting color value.
        m_Color = m_cabeza.color;
        m_Color_tentaculos = m_tentaculos.color;
        m_Color_interior = m_interior.color;
        // Must use "StartCoroutine()" to execute 
        // methods with return type of "IEnumerator".
        StartCoroutine(ColorFade());
    }

    // This method fades only the alpha.
    IEnumerator AlphaFade()
    {
        // Alpha start value.
        float alpha = 1.0f;

        // Loop until aplha is below zero (completely invisalbe)
        while (alpha > 0.0f)
        {
            // Reduce alpha by fadeSpeed amount.
            alpha -= fadeSpeed * Time.deltaTime;

            // Create a new color using original color RGB values combined
            // with new alpha value. We have to do this because we can't 
            // change the alpha value of the original color directly.
            m_cabeza.color = new Color(m_Color.r, m_Color.g, m_Color.b, alpha);

            yield return null;
        }
    }


    // This method fades from original color to "fadeColor"
    IEnumerator ColorFade()
    {
        // Lerp start value.
        float change = 0.0f;

        // Loop until lerp value is 1 (fully changed)
        while (change < 1.0f)
        {
            // Reduce change value by fadeSpeed amount.
            change += fadeSpeed * Time.deltaTime;

            m_cabeza.color = Color.Lerp(m_Color, fadeColor, change);
            m_tentaculos.color = Color.Lerp(m_Color_tentaculos, fadeColor, change);
            m_interior.color = Color.Lerp(m_Color_interior, fadeColor, change);

            yield return null;
        }
        StartCoroutine(ColorFadeIn());
    }
    IEnumerator ColorFadeIn()
    {
        yield return new WaitForSeconds(3.0f);
        float change = 0.0f;

        // Loop until lerp value is 1 (fully changed)
        while (change < 1.0f)
        {
            // Reduce change value by fadeSpeed amount.
            change += fadeSpeed * Time.deltaTime;

            m_cabeza.color = Color.Lerp(fadeColor, m_Color, change);
            m_tentaculos.color = Color.Lerp(fadeColor, m_Color_tentaculos, change);
            m_interior.color = Color.Lerp(fadeColor, m_Color_interior, change);

            yield return null;
        }
    }
}