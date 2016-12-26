using UnityEngine;
using System.Collections;

public class TradeShipController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
