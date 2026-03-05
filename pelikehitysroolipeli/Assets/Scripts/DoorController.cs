using UnityEngine;
using UnityEngine.Rendering;

using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Oven tilat
    public enum OvenTila
    {
        Auki,
        Kiinni,
        Lukittu
    }

    // Ovelle tehtävät toiminnot
    public enum Toiminto
    {
        Avaa,
        Sulje,
        Lukitse,
        AvaaLukitus
    }

    [SerializeField]
    private OvenTila ovenTila = OvenTila.Kiinni;

    // Tätä kutsutaan PlayerControllerista
    public void ReceiveAction(Toiminto toiminto)
    {
        bool onnistuiko = false;

        switch (toiminto)
        {
            case Toiminto.Avaa:
                if (ovenTila == OvenTila.Kiinni)
                {
                    ovenTila = OvenTila.Auki;
                    OpenDoor();
                    onnistuiko = true;
                }
                break;

            case Toiminto.Sulje:
                if (ovenTila == OvenTila.Auki)
                {
                    ovenTila = OvenTila.Kiinni;
                    CloseDoor();
                    onnistuiko = true;
                }
                break;

            case Toiminto.Lukitse:
                if (ovenTila == OvenTila.Kiinni)
                {
                    ovenTila = OvenTila.Lukittu;
                    LockDoor();
                    onnistuiko = true;
                }
                break;

            case Toiminto.AvaaLukitus:
                if (ovenTila == OvenTila.Lukittu)
                {
                    ovenTila = OvenTila.Kiinni;
                    UnlockDoor();
                    onnistuiko = true;
                }
                break;
        }

        Debug.Log("Oven tila: " + ovenTila +
                  " | Toiminto: " + toiminto +
                  " | Onnistui: " + onnistuiko);
    }

    // Ulkonäkö / animaatiot (esimerkit)
    private void OpenDoor()
    {
        Debug.Log("Ovi avautuu");
        // animaatio / rotaatio tänne
    }

    private void CloseDoor()
    {
        Debug.Log("Ovi sulkeutuu");
    }

    private void LockDoor()
    {
        Debug.Log("Ovi lukittu");
    }

    private void UnlockDoor()
    {
        Debug.Log("Oven lukitus avattu");


    }
}