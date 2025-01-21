using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPickup : MonoBehaviour
{
    public Transform pickupPoint; // Taškas, kur dinozauras bus laikomas
    public Transform playerTransform; // Žaidėjo transform
    public float pickupRange = 3f; // Maksimalus atstumas paėmimui
    private GameObject pickedUpDino; // Dinozauras, kurį žaidėjas laiko

    void Update()
    {
        // Patikriname, ar žaidėjas paspaudė pelės kairįjį mygtuką
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedUpDino == null) // Paėmimas
            {
                TryPickupDino();
            }
            else // Paleidimas
            {
                DropDino();
            }
        }
    }

    void TryPickupDino()
    {
        // Surandame visus objektus aplink žaidėją
        Collider[] hitColliders = Physics.OverlapSphere(playerTransform.position, pickupRange);

        foreach (Collider collider in hitColliders)
        {
            // Tikriname, ar objektas yra dinozauras
            if (collider.CompareTag("Dino"))
            {
                pickedUpDino = collider.gameObject;
                pickedUpDino.GetComponent<Rigidbody>().isKinematic = true; // Išjungiam fizikos judėjimą
                pickedUpDino.transform.position = pickupPoint.position; // Perkeliame į „rankos“ tašką
                pickedUpDino.transform.SetParent(pickupPoint); // Tvirtiname prie rankos
                return;
            }
        }

        Debug.Log("Nėra dinozauro arti!");
    }

    void DropDino()
    {
        // Paleidžiame dinozaurą
        pickedUpDino.GetComponent<Rigidbody>().isKinematic = false; // Įjungiame fizikos judėjimą
        pickedUpDino.transform.SetParent(null); // Atsiejame nuo rankos
        pickedUpDino = null; // Pamirštame objektą
    }

    // Rodyk sferą, rodydamas paėmimo diapazoną
    void OnDrawGizmosSelected()
    {
        if (playerTransform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(playerTransform.position, pickupRange);
        }
    }
}
