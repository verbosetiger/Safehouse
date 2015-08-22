using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Safehouse
{
    public class TextureManager
    {
        private Dictionary<string, Texture2D> textures;
        private ContentManager content;

        public TextureManager()
        {
            textures = new Dictionary<string, Texture2D>();
        }

        public void Initialize(ContentManager content)
        {
            this.content = content;
        }

        public void Load(string filename, string key)
        {
            Texture2D texture;
            texture = content.Load<Texture2D>(filename);
            textures.Add(key, texture);
        }

        public bool IsTextureLoaded(string key)
        {
            return textures.ContainsKey(key);
        }

        public Texture2D GetTexture(string key)
        {
            if (textures.ContainsKey(key) == true)
            {
                Texture2D texture = null;
                textures.TryGetValue(key, out texture);
                return texture;
            }
            else
            {
                return null;
            }
        }
    }
}
