using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong;

public class Paddle
{
  public Rectangle rect;
  private float moveSpeed = 500f;
  private bool isSecondPlayer;

  public Paddle(bool isSecondPlayer)
  {
    this.isSecondPlayer = isSecondPlayer;
    rect = new Rectangle((this.isSecondPlayer ? Globals.WIDTH - 40 : 0), 140, 40, 200);
  }

  public void Update(GameTime gameTime) 
  {
    KeyboardState kState = Keyboard.GetState();

    if ((this.isSecondPlayer ? kState.IsKeyDown(Keys.Up) : kState.IsKeyDown(Keys.W)) && rect.Y > 0)
    {
      rect.Y -= (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
    }

    if ((this.isSecondPlayer ? kState.IsKeyDown(Keys.Down) : kState.IsKeyDown(Keys.S)) && rect.Y < Globals.HEIGHT - rect.Height)
    {
      rect.Y += (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
    }
  }

  public void Draw() 
  {
    Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
  }
}
