using System;
using System.Diagnostics;
using UnityEngine;  

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
    }
    private const int firstBodyPart = 1;
    private int positionX;
    private int positionY;
    private float timer;
    private Direction snakeCurrent;
    private Direction snakeNext;
    private float speed = 2f;
    private int snakeLenght = 2;
    private bool endGame = false;
    private int score = 0;

    void Start()
    {
        positionX = 2;
        positionY = 7;
        snakeCurrent = Direction.RIGHT;
        snakeNext = Direction.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey("up") && snakeCurrent != Direction.DOWN)
        {
            snakeNext = Direction.UP;
        }
        else if (Input.GetKey("down") && snakeCurrent != Direction.UP)
        {
            snakeNext = Direction.DOWN;
        }
        else if (Input.GetKey("left") && snakeCurrent != Direction.RIGHT)
        {
            snakeNext = Direction.LEFT;
        }
        else if (Input.GetKey("right") && snakeCurrent != Direction.LEFT)
        {
            snakeNext = Direction.RIGHT;
        }

        if (timer*speed > 1)
        {
            GameObject.Find("Body1").SendMessage("positionSet", new Vector3(positionX, positionY, firstBodyPart));
            switch (snakeNext)
            {
                case Direction.DOWN:
                    positionY += 1;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                    break;
                case Direction.UP:
                    positionY -= 1;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
                case Direction.LEFT:
                    positionX -= 1;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    break;
                case Direction.RIGHT:
                    positionX += 1;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
            }
            snakeCurrent = snakeNext;
            transform.position = new Vector3(-9.5f + positionX, 3.5f - positionY, 0);
            timer = 0.0f;
        }

        if (endGame) {
            if (timer < 0.3f)
                this.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 1f);
            else
                this.GetComponent<SpriteRenderer>().color = Color.white;

            if (timer > 0.6f)
                timer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        String scoreText;
        if (other.name.Equals("Cherry"))
        {
            other.gameObject.SetActive(false);
            GameObject.Find("CherrySpawn").SendMessage("newCherry");
            GameObject.Find("Body" + snakeLenght).SendMessage("fruitEaten", snakeLenght);
            score += (10 * snakeLenght);
            scoreText = String.Format("{0,4:D4}", score);
            GameObject.Find("Canvas/Score").GetComponent<UnityEngine.UI.Text>().text = scoreText;
            snakeLenght += 1;
        }
        else
        {
            GameObject.Find("CherrySpawn").SendMessage("stopCherryAnimation");
            endGame = true;
            speed = 0.0f;
        }
    }
}
