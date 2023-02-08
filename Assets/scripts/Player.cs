using Abstract;

public class Player : BaseSumo
{


    private CollisionPush _colPush;


    override protected void Start()
    {
        base.Start();
        _colPush = GetComponent<CollisionPush>();
    }


    override protected void GrowUp()
    {
        base.GrowUp();
        _colPush.ForceUp();
    }
    private void Update()
    {
        if (transform.position.y < 0)
        {
            GameManager.Instance.LoseGame();
            Destroy(this.gameObject);

            GameManager.Instance.Buttonactive();
        }
    }

}