# Robots Game

Robots Game is an interactive Unity-based decision-making game where players consult robot advisors before answering questions. Each robot gives an opinion, and the player must review all robot inputs before selecting an answer. The game tracks the score and shows a win or loss result based on the final score.

## Features

- Interactive robot consultation gameplay
- Multiple robot advisors with opinions
- Question-and-answer based game flow
- Answer options unlock only after consulting all robots
- Score tracking system
- Winner and loser result scenes
- Unity scene-based structure
- Modular C# scripts for game logic, UI, scoring, and robot interaction

## Tech Stack

- Unity
- C#
- TextMeshPro
- Unity Input System
- Universal Render Pipeline
- ShaderLab / HLSL

## Gameplay Flow

```text
Start Game
   ↓
Question is displayed
   ↓
Player consults all robots
   ↓
Answer choices unlock
   ↓
Player selects an answer
   ↓
Score is updated
   ↓
Next question appears
   ↓
Final winner or loser scene is shown
