using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TddShooter.Model;

namespace TddShooter
{
    internal class ScenarioReader
    {
        internal static Dictionary<int, List<AbstractEnemy>> Read(string content)
        {
            var story = new Dictionary<int,List<AbstractEnemy>>();
            var json = (dynamic) JsonConvert.DeserializeObject(content);
            foreach (var dynamic in json)
            {
                long time = dynamic["time"].Value;
                long type = dynamic["type"].Value;
                long x = dynamic["x"].Value;
                long y = dynamic["y"].Value;
                long sx = dynamic["sx"]?.Value ?? 0;
                long sy = dynamic["sy"]?.Value ?? 0;

                AbstractEnemy enemy = null;
                switch (type)
                {
                    case 0: 
                        enemy = new Enemy0(x, y);
                        break;
                    case 1:
                        enemy = new Enemy1(x, y);
                        break;
                    case 2:
                        var t = sx > 0 ? -1 : +1;
                        enemy = new Enemy2(x,y,sx,sy,t);
                        break;
                    case 3:
                        enemy = new Enemy3(x,y);
                        break;
                    case 4:
                        enemy = new Enemy4(x,y);
                        break;
                }

                List<AbstractEnemy> enemies;
                if (story.ContainsKey((int) time))
                {
                    enemies = story[(int) time];
                }else
                {
                    enemies = new List<AbstractEnemy>();
                    story[(int) time] = enemies;
                }
                enemies.Add(enemy);
            }

            return story;
        }
    }
}
