using Microsoft.Xna.Framework;

namespace Pong;

public class Ball
{
  private Rectangle rect;
  private int right = 1;
  private int top = 1;
  private int moveSpeed = 200;

  public Ball()
  {
    rect = new Rectangle(Globals.WIDTH / 2 - 20, Globals.HEIGHT / 2 - 20, 40, 40);
  }

  public void resetGame()
  {
    rect.X = Globals.WIDTH / 2 - 20;
    rect.Y = Globals.HEIGHT / 2 - 20;
    moveSpeed = 200;
  }

  public void Update(GameTime gameTime, Paddle player1, Paddle player2)
  {
    int deltaSpeed = (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
    rect.X += right * deltaSpeed;
    rect.Y += top * deltaSpeed;

    if (player1.rect.Right > rect.Left && rect.Top > player1.rect.Top && rect.Bottom < player1.rect.Bottom)
    {
      right = 1;
      moveSpeed += 10;
    }

    if (player2.rect.Left < rect.Right && rect.Top > player2.rect.Top && rect.Bottom < player2.rect.Bottom)
    {
      right = -1;
      moveSpeed += 10;
    }

    if (rect.Y < 0)
    {
      top *= -1;
    }

    if (rect.Y > Globals.HEIGHT - rect.Height)
    {
      top *= -1;
    }

    if (rect.X < 0)
    {
      Globals.PLAYER_2_SCORE += 1;
      resetGame();
    }

    if (rect.X > Globals.WIDTH - rect.Width)
    {
      Globals.PLAYER_1_SCORE += 1;
      resetGame();
    }
  }

  public void Draw()
  {
    Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
  }
}
