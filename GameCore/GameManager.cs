using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projekt_VT
{
    public class GameManager
    {
        public List<Enemy> Enemies = new();
        public List<Tower> Towers = new();

        public WaveManager WaveManager = new();

        private Texture2D _enemyTexture;

        public GameManager(Texture2D enemyTexture)
        {
            _enemyTexture = enemyTexture;
        }

        public void Update(GameTime gameTime)
        {
            WaveManager.Update(gameTime, Enemies, _enemyTexture);

            foreach (var enemy in Enemies)
                enemy.Update(gameTime);

            foreach (var tower in Towers)
            {
                tower.Update(gameTime);
                tower.TryShoot(Enemies);
            }

            foreach (var tower in Towers)
            {
                foreach (var p in tower.Projectiles)
                    p.Update(gameTime);

                tower.Projectiles.RemoveAll(p => !p.IsActive);
            }

            Enemies.RemoveAll(e => e.Health <= 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in Enemies)
                enemy.Draw(spriteBatch);

            foreach (var tower in Towers)
            {
                tower.Draw(spriteBatch);

                foreach (var p in tower.Projectiles)
                    p.Draw(spriteBatch);
            }
        }
    }
}
