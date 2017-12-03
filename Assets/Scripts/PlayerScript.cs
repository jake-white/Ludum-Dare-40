using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public GameObject soundCircle;
	private GameObject mySound;
	public GameState state;

	public Vector3 spawn;
	private float soundRadius = 10;
	private int money = 0;
	private float modRadius;
	public Rigidbody2D body;
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		Vector3 soundVector = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
		mySound = Instantiate(soundCircle, soundVector, Quaternion.identity);
		mySound.transform.parent = gameObject.transform;
		modRadius = soundRadius;
		mySound.transform.localScale = new Vector2(modRadius, modRadius);
	}
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500.0f;
        var y = Input.GetAxisRaw("Vertical") * Time.deltaTime * 500.0f;

        Vector3 moveDirection = new Vector3(x, y, 0);
		body.AddForce(moveDirection);
		mySound.transform.localScale = new Vector2(modRadius, modRadius);

		if(moveDirection == new Vector3(0,0, 0)) {
			body.velocity = body.velocity * 0.8f;
			modRadius = 0;
		}
		else {
			modRadius = soundRadius * Mathf.Abs(Mathf.Sin(Time.time * 5));
			if(modRadius < soundRadius / 2) {
				modRadius = soundRadius / 2;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.name == "Safe" && !collider.GetComponent<Safe>().isOpened()) {
			collider.GetComponent<Safe>().open();
			money++;
			soundRadius *= 1.1f;
		}
	}

	public void respawn() {
		transform.position = spawn;
		soundRadius = 10;
	}
}