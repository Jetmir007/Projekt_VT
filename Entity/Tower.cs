using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projekt_VT
{
    public class Tower : GameObject
    {
        private Texture2D _texture;
        private Texture2D _projectileTexture;
    
        private float _range = 120f;
        private float _timer = 0f;
    
        public List<Projectile> Projectiles = new();
    
        public Tower(Texture2D texture, Texture2D projectileTexture, Vector2 pos)
        {
            _texture = texture;
            _projectileTexture = projectileTexture;
            Position = pos;
        }
    
        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    
        public void TryShoot(List<Enemy> enemies)
        {
            if (_timer < 1f) return;
    
            foreach (var enemy in enemies)
            {
                if (Vector2.Distance(Position, enemy.Position) < _range)
                {
                    Projectiles.Add(new Projectile(_projectileTexture, Position, enemy));
                    _timer = 0f;
                    break;
                }
            }
        }
    
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
