using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaintBrush_SCRPT : MonoBehaviour
{
    [SerializeField] private GameObject[] colorParticles;
    private bool changePaint;

    public Material brushMaterial;

    [Header("CRYSTAL MATERIALS")]
    [SerializeField] private Material blueCrystalMaterial;
    [SerializeField] private Material purpleCrystalMaterial;
    [SerializeField] private Material redCrystalMaterial;
    [SerializeField] private Material noPaintMaterial;

    [Header("TIP MATERIALS")]
    [SerializeField] private Material redTipMaterial;
    [SerializeField] private Material purpleTipMaterial;
    [SerializeField] private Material blueTipMaterial;
    [SerializeField] private Material noPaintTipMaterial;

    private string paintTouched;

    void Start()
    {
        brushMaterial = transform.GetChild(1).GetComponent<Renderer>().material;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Purple Bubble"))
        {
            paintTouched = "Purple";
        }
        else if (collision.CompareTag("Green Bubble"))
        {
            paintTouched = "Green";
        }
        else if (collision.CompareTag("Blue Bubble"))
        {
            paintTouched = "Blue";
        }
        else if (collision.CompareTag("Red Bubble"))
        {
            paintTouched = "Red";
        }
        else if (collision.CompareTag("Water"))
        {
            paintTouched = "Water";
        }

        ChangeBrushPaint();
    }

    private void ChangeBrushPaint()
    {
        switch (paintTouched)
        {
            case "Purple":
                {
                    brushMaterial = purpleCrystalMaterial;

                    //Changes brush materials
                    transform.GetChild(0).GetComponent<Renderer>().material = purpleTipMaterial;
                    transform.GetChild(1).GetComponent<Renderer>().material = purpleCrystalMaterial;

                    //Activates particles
                    DeactivateParticles();
                    transform.GetChild(6).gameObject.SetActive(true);
                    break;
                }

            case "Green":
                {
                    brushMaterial.color= Color.green;
                    break;
                }

            case "Blue":
                {
                    brushMaterial= blueCrystalMaterial;

                    //Changes brush materials
                    transform.GetChild(0).GetComponent<Renderer>().material = blueTipMaterial;
                    transform.GetChild(1).GetComponent<Renderer>().material = blueCrystalMaterial;

                    //Activates particles
                    DeactivateParticles();
                    transform.GetChild(5).gameObject.SetActive(true);
                    break;
                }

            case "Red":
                {
                    brushMaterial = redCrystalMaterial;

                    //Changes brush materials
                    transform.GetChild(0).GetComponent<Renderer>().material = redTipMaterial;
                    transform.GetChild(1).GetComponent<Renderer>().material = redCrystalMaterial;

                    //Activates particles
                    DeactivateParticles();
                    transform.GetChild(4).gameObject.SetActive(true);
                    break;
                }

            case "Water":
                {
                    brushMaterial = noPaintMaterial;

                    //Changes brush materials
                    transform.GetChild(0).GetComponent<Renderer>().material = noPaintTipMaterial;
                    transform.GetChild(1).GetComponent<Renderer>().material = noPaintMaterial;

                    //Deactivates particles
                    DeactivateParticles();
                    break;
                }

            default:
                {
                    return;
                }

        }
    }

    private void DeactivateParticles()
    {
        foreach (GameObject particle in colorParticles)
        {
            particle.gameObject.SetActive(false);
            Debug.Log($"{particle.name} has been set false");
        }
    }
}
