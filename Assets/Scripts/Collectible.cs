using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Color collectibleColor;  // The color of this object
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = collectibleColor;
    }
}
