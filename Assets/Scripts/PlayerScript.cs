using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	public GameObject soundCircle;
	private GameObject mySound;
	public GameState state;
	public Vector3 spawn;
	public AudioClip[] jingles;
	private int cooldown = 1000;
	private float lastTime = 0;
	private float startingSoundRadius = 4;
	private float soundRadius;
	private int money = 0;
	private float modRadius;
	private Rigidbody2D body;
	private System.Random rnd;
	void Start()
	{
		rnd = new System.Random();
		body = GetComponent<Rigidbody2D>();
		Vector3 soundVector = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
		mySound = Instantiate(soundCircle, soundVector, Quaternion.identity);
		mySound.transform.parent = gameObject.transform;
		soundRadius = state.getScore();
		modRadius = soundRadius;
		mySound.transform.localScale = new Vector2(modRadius, modRadius);
	}
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500.0f;
        var y = Input.GetAxisRaw("Vertical") * Time.deltaTime * 500.0f;

        Vector3 moveDirection = new Vector3(x, y, 0);
		if(!state.isCaught() && !state.isFrozen())  {
			body.AddForce(moveDirection);
		}
		mySound.transform.localScale = new Vector2(modRadius, modRadius);
		if(state.isCaught() || state.isFrozen()) {
			body.velocity = body.velocity * 0.5f;
			
		}
		else if(moveDirection == new Vector3(0,0, 0)) {
			body.velocity = body.velocity * 0.8f;
			modRadius = 0;
		}
		else {
			AudioSource audio = GetComponent<AudioSource>();
			if(state.getScore() > 0 && !audio.isPlaying && ((Time.time*1000) > lastTime + cooldown)) {
				lastTime = Time.time * 1000;
				int randomInt = rnd.Next(0, jingles.Length);
				audio.clip = jingles[randomInt];
				audio.Play();
			}
			soundRadius = state.getScore()/2.5f;
			modRadius = soundRadius * Mathf.Abs(Mathf.Sin(Time.time * 5));
			if(modRadius < soundRadius / 2) {
				modRadius = soundRadius / 2;
			}
		}
		transform.Rotate(0,0,(body.velocity.x + body.velocity.y)*2.0f);
	}


	public void respawn() {
		transform.position = spawn;
		soundRadius = startingSoundRadius;
	}
}