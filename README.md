# Simple-RPG

<img alt="Simple RPG Banner" src="https://github.com/Kacper-Mila/Simple-RPG/blob/main/Resources/banner.png">

Simple RPG is a text-based dungeon crawler game built in C#. Navigate through dungeons, battle enemies, find and equip weapons, and use items as you explore the ASCII world.

## 🎮 Game Features
- 🗺️ __Dungeon Exploration__: Navigate through procedurally generated dungeons
- ⚔️ __Combat System__: Engage in turn-based battles with various enemies
- 🎒 __Inventory Management__: Collect and use items found throughout the dungeon
- 🧪 __Health System__: Manage your health with healing potions
- 🗡️ __Equipment__: Find and equip weapons with different damage capabilities

## 🎲 Game Elements
|Symbol           | Descryption                  |
|-----------------|------------------------------|
| `P`             | Player                       |
| `#`             | Wall (impassable)            |
| `.`             | Floor (Walkable)             |
| `E`             | Enemy (triggers combat)      |
| `!`             | Item (can be collected)      |

## 🎮 Controls
|Key              |Action          |
|-----------------|----------------|
| `↑` `↓` `←` `→` | Move Player    |
| `I`             | Open Inventory |
| `Q`             | Quit game      |
### During combat
|Key              |Action             |
|-----------------|-------------------|
| `A`             | Attack Enemy      |
| `H`             | Use health potion |
| `I`             | Access inventory  |

## 🏗️ Project Architecture
```
Simple-RPG/
├── Actions/
|   ├── AttackAction.cs          # Attack the enemy
|   ├── FightAction.cs           # Calls the fight
|   ├── HealAction.cs            # Heals the player 
|   └── IAction.cs               # interface for all Actions
├── Entities/
│   ├── Entity.cs                # Base class for all entities
│   ├── PlayerEntity.cs          # Player character with inventory
│   └── EnemyEntity.cs           # Enemy types with varying stats
├── Items/
│   ├── Item.cs                  # Base class for all items
|   ├── Potions/
|   |   └── HealthPotionItem.cs  # Healing consumables
│   ├── Weapons/
│   │   ├── WeaponItem.cs        # Base weapon class
│   │   ├── SwordItem.cs         # Sword implementation
│   │   └── AxeItem.cs           # Axe implementation
|   ├── Utils/
|   |   └── ItemFactory.cs       # Creates random items on the map
|   └── Inventory.cs             # Player inventory, handles item usage and pickup
├── Maps/
│   ├── Map.cs                   # Map generation and management
│   ├── tiles/                   # Different tile types
|   └── maps/                    # Storage for available maps
├── UI/
│   ├── Menu.cs                  # Start menu and player creation
│   ├── PlayerInfoUI.cs          # Player stats display
│   ├── InventoryUI.cs           # Inventory interface
│   └── FightUI.cs               # Combat interface
├── Utils/
|   ├── MapLoader.cs             # Used to load the map from file
|   └── Colors.cs                # Used to output strings in color
└── Game.cs                      # Core game loop
```

## 🎯 Game Flow
1. __Character Creation__: Enter your name and begin your adventure
2. __Dungeon Exploration__: Navigate through rooms and corridors
3. __Combat__: Battle enemies that block your path
4. __Item Collection__: Find weapons and potions to aid your journey
5. __Inventory Management__: Equip better weapons and use potions strategically

## 💻 Technical Implementation
Simple RPG demonstrates several object-oriented programming principles:
- __Inheritance__: Entity hierarchy (Player, Enemy) and Item hierarchy (Weapons, Potions)
- __Polymorphism__: Different item behaviors through the same interface
- __Encapsulation__: Protected data with appropriate access modifiers
- __Composition__: Complex relationships between game elements

## 🚀 Getting Started
```
# Clone the repository
git clone https://github.com/Kacper-Mila/Simple-RPG.git

# Navigate to the project directory
cd Simple-RPG

# Build the project
dotnet build

# Run the game
dotnet run
```

