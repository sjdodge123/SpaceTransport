using UnityEngine;
using System.Collections;

public class TradeShipController : MonoBehaviour
{
    public int carryCapacity;
    private SpriteRenderer shipSprite;
    private int greenTransport;
    private Rigidbody2D shipBody;

    public void Start()
    {
        shipBody = GetComponent<Rigidbody2D>();
        shipSprite = GetComponent<SpriteRenderer>();
        greenTransport = LayerMask.NameToLayer("GreenTransport");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameBounds"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("GreenResource") && gameObject.layer != greenTransport)
        {
            gameObject.layer = greenTransport;
            carryCapacity = 1;
            SpriteRenderer collisionSprite = collision.gameObject.GetComponent<SpriteRenderer>();
            shipSprite.color = collisionSprite.color;
            ReverseTrajectory();
            return;
        }

        if (collision.gameObject.CompareTag("RedSpawn"))
        {
            GameVars.playerMoney += carryCapacity;
            Debug.Log("Money has increased to: " + GameVars.playerMoney);
        }
        Destroy(gameObject);

     }

    public void ReverseTrajectory()
    {
        shipBody.velocity = -shipBody.velocity;
    }
}
