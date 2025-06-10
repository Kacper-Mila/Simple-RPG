using Simple_RPG.Interfaces;

namespace Simple_RPG.Entities;

public class EnemyEntity : Entity
{
    public string AsciiArt { get; }
    
    public EnemyEntity(string name, int hp, (int Min, int Max) attackPower, string asciiArt) 
        : base(name, hp, attackPower)
    {
        AsciiArt = asciiArt;
    }
    
    // Factory method to create enemies of different types
    public static EnemyEntity CreateEnemy(string type)
    {
        return type.ToLower() switch
        {
            "goblin" => new EnemyEntity(
                "Goblin",
                hp: 30,
                attackPower: (Min: 3, Max: 8),
                asciiArt: @"
     ,      ,
    /(.-""-.)\
|\  \/      \/  /|
| \ / =.  .= \ / |
\( \   o\/o   / )/
 \_, '-/  \-' ,_/
   /   \__/   \
   \ \__/\__/ /
 ___\ \|--|/ /___
/`    \      /    `\
/       '----'       \"
            ),
            
            "troll" => new EnemyEntity(
                "Troll",
                hp: 50,
                attackPower: (Min: 5, Max: 15),
                asciiArt: @"
      .-""-.
     /      \
    /  _.--._\
   /  <      >
   \  |-..-| /
    '.|    |.'
      '-.__.'
"
            ),
            
            "dragon" => new EnemyEntity(
                "Dragon",
                hp: 80,
                attackPower: (Min: 8, Max: 20),
                asciiArt: @"
                /\            /\
               / \'._   (\_/) / \
              / .''._'--(o.o)--'
             / /   \     (u)
            / | @)  \   _)=/
           /  \     \.='  \
          /    \     \     \
"
            ),
            
            // Default enemy (used if type is not recognized)
            _ => new EnemyEntity(
                "Unknown Monster",
                hp: 20,
                attackPower: (Min: 2, Max: 6),
                asciiArt: @"
   _____
  /     \
 | () () |
  \  ^  /
   |||||
"
            )
        };
    }
}