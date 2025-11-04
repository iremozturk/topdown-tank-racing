# Top-Down Tank Racing Game

A Unity-based top-down racing game featuring player-controlled tank mechanics and AI opponent cars that navigate through waypoint-based tracks. Built as part of CS361 coursework.

## 🎮 Game Overview

This is a 2D top-down racing game where players control a tank using arrow keys to navigate through a track while competing against AI-controlled enemy cars. The game features physics-based movement, waypoint navigation systems, and a finish line goal.

## ✨ Features

### Player Controls
- **Tank Movement**: Arrow keys for forward/backward movement and rotation
- **Turret Control**: Enter key to automatically rotate turret toward base
- **Physics-Based**: Realistic physics with ground detection and drag systems
- **Game Over Screen**: Triggered upon reaching the finish line

### AI System
- **Waypoint Navigation**: AI cars follow a looping track with 9 checkpoints
- **Automatic Steering**: AI cars automatically rotate to face the next waypoint
- **Character Controller**: Smooth AI movement using Unity's CharacterController

### Track System
- **Dynamic Waypoints**: Track system manages 9 checkpoint cubes
- **Progress Tracking**: Real-time marker updates based on AI progress
- **Collision Detection**: Checkpoints disable temporarily after AI passes through

## 🛠️ Technical Details

### Scripts

#### `tank_drive.cs`
Player tank controller with movement and rotation mechanics.
- **Speed**: 10.0 units/second
- **Rotation Speed**: 40.0 degrees/second
- **Turret Rotation**: Smooth interpolation toward base position

#### `Movement.cs` (CarController)
Alternative physics-based car controller using Rigidbody.
- Ground detection via raycasting
- Separate air and ground drag values
- Forward/reverse speed controls
- Surface alignment using Quaternion rotation

#### `CarAIScript.cs`
AI enemy car controller with waypoint following.
- **Speed**: 15.0 units/second
- **Gravity**: 100.0 units/second²
- **Waypoint System**: 9-cube checkpoint loop (Cube1 → Cube2 → ... → Cube9 → Cube1)

#### `CarTrack.cs`
Track management system for waypoint progression.
- Updates marker position based on AI car progress
- Handles checkpoint triggers with cooldown system
- Loops track after 8 checkpoints

### Project Structure

```
cs361/
├── scripts/                    # Core game scripts
│   ├── Movement.cs            # Physics-based car controller
│   ├── CarAIScript.cs         # AI enemy car controller
│   ├── CarTrack.cs            # Track waypoint management
│   └── FollowCar.cs           # Third-party RVP package (optional)
├── tank_player/               # Unity project directory
│   ├── Assets/
│   │   ├── tank_drive.cs      # Player tank controller
│   │   ├── Scenes/
│   │   │   └── SampleScene.unity
│   │   └── Kenney/            # Game assets (sprites, textures)
│   ├── ProjectSettings/       # Unity project configuration
│   └── Library/               # Unity generated files (gitignored)
├── project/                   # Asset files and documentation
│   ├── Spritesheet/          # Sprite atlases
│   ├── PNG/                  # Individual sprite files
│   └── Tilesheet/            # Terrain tiles
├── validate_scripts.py       # Script validation tool
└── simulate_game_logic.py   # Logic simulation tests
```

## 🚀 Getting Started

### Prerequisites

- **Unity Editor**: Version 2020.3.3f1 or compatible
- **Git**: For version control

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/topdown-tank-racing.git
   cd topdown-tank-racing
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Open" and select the `tank_player/` directory
   - Unity will import all assets automatically

3. **Open the Scene**
   - Navigate to `Assets/Scenes/SampleScene.unity`
   - Click the Play button to start the game

### Controls

| Input | Action |
|-------|--------|
| `↑` / `↓` | Move forward/backward |
| `←` / `→` | Rotate tank |
| `Enter` | Rotate turret toward base |
| `ESC` | Exit game (when implemented) |

## 🧪 Testing

The project includes validation tools that can be run without Unity:

### Script Validation
```bash
python3 validate_scripts.py
```
Checks all C# scripts for syntax errors, common issues, and best practices.

### Logic Simulation
```bash
python3 simulate_game_logic.py
```
Simulates game logic to verify:
- Waypoint tracking and looping
- AI car navigation
- Player movement mechanics
- Checkpoint progression

## 📋 Requirements

### Unity Version
- **Recommended**: Unity 2020.3.3f1
- **Minimum**: Unity 2020.1 or later

### Dependencies
- Unity Standard Assets (included)
- Kenney Game Assets (included in project)

## 🎯 Game Mechanics

### Player Objective
- Navigate the tank through the track
- Reach the finish line ("end" trigger)
- Avoid or compete with AI cars

### AI Behavior
- AI cars continuously loop through 9 waypoints
- Each car rotates to face the next checkpoint upon collision
- Collision detection disables checkpoints temporarily to prevent multiple triggers

### Physics
- **Ground Detection**: Raycasting for terrain alignment
- **Drag System**: Different drag values for air vs. ground movement
- **Gravity**: Applied to AI cars when not grounded


##  Code Quality

All scripts have been validated and tested:
-  No compilation errors
-  Proper null checks where needed
-  Correct Unity API usage
-  Logic simulation tests passed

##  Assets

Game assets are provided by [Kenney](https://kenney.nl/):
- Top-down tank sprites
- Terrain tiles
- Object sprites
- Sprite sheets (default and retina resolutions)

## � Documentation

- **Scripts**: All scripts include inline comments
- **Scene Setup**: Configure in Unity Editor:
  1. Attach `tank_drive.cs` to player tank GameObject
  2. Attach `CarAIScript.cs` to AI car GameObjects
  3. Set up 9 waypoint cubes (Cube1-Cube9) with appropriate tags
  4. Attach `CarTrack.cs` to track manager GameObject
  5. Configure all public GameObject references in Inspector


## 📄 License

This project uses assets from Kenney.nl. Please refer to the License.txt file in the `project/` directory for asset licensing information.


## 🙏 Acknowledgments

- [Kenney](https://kenney.nl/) for game assets
- Unity Technologies for the game engine


---

**Note**: This project requires Unity Editor to run. The validation scripts can test code logic without Unity, but full gameplay testing requires Unity runtime.

