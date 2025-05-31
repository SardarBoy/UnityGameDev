# AI-Enhanced FPS Game in Unity

This project is a Unity-based first-person shooter (FPS) game featuring two distinct game modes, integrated with machine learning components for performance tracking and adaptive difficulty.

## Game Modes

- **Bhop Runner Mode**: A movement-focused mode inspired by bunny hopping mechanics.
- **Target Shooter Mode**: A timed shooting mode where the player must hit all targets efficiently.

## AI and ML Integration

- Player performance data (e.g., accuracy, shots, reaction time) is logged and structured.
- A Python-based machine learning pipeline analyzes session data to classify difficulty levels and cluster player behaviors.
- AI hooks within Unity (C# scripts) simulate dynamic difficulty adjustments based on player metrics.

## Project Structure

- `Assets/Scripts/` contains all gameplay and AI C# scripts.
- `exploratory/` includes Python prototypes and structured gameplay data for potential modeling and analysis.
