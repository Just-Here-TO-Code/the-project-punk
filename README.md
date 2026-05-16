# Project Punk

Open-world game project developed by the Game Development Club using Unity.

---

# Tech Stack

- Unity 2022.3 LTS
- Universal Render Pipeline (URP)
- Git + GitHub
- Git LFS
- Blender

---

# Branch Structure

```text
main
dev
feat/*
fix/*
chore/*
```

## Branch Rules

### `main`
- Stable production-ready branch
- Always playable
- Protected branch
- No direct commits

### `dev`
- Main development branch
- All features merge here first
- All PRs should merge to this branch

### `feat/*`
Feature branches.

Examples:

```text
feat/player-controller
feat/inventory-system
feat/combat-ai
```

### `fix/*`
Bugfix branches.

Examples:

```text
fix/player-jump
fix/audio-bug
fix/save-system
```
### `chore/*`
Repo routine maintenance or technical tasks.

Examples:

```text
chore/readme-update
chore/license-update
chore/gitignore-update
```

---

# Repository Structure

```text
project-punk/
│
├── Assets/
│   ├── _Project/
│   │   ├── Art/
│   │   ├── Audio/
│   │   ├── Characters/
│   │   ├── Environment/
│   │   ├── Materials/
│   │   ├── Prefabs/
│   │   ├── Scenes/
│   │   ├── Scripts/
│   │   ├── UI/
│   │   ├── VFX/
│   │   └── Animations/
│   │
│   ├── ThirdParty/
│   ├── Plugins/
│   └── Addressables/
│
├── Packages/
├── ProjectSettings/
├── .github/
├── README.md
├── .gitignore
└── .gitattributes
```

---

# Unity Setup

## Required Unity Version

```text
Unity 6000.3.7f1 LTS
```

# Git LFS Setup

We will need this to track and store large files. It will be implemented in the repo, in case you come across any issues, just do this, try tracking before installing.

Install Git LFS:

```bash
git lfs install
```

Track large files:

```bash
git lfs track "*.psd"
git lfs track "*.blend"
git lfs track "*.fbx"
git lfs track "*.png"
git lfs track "*.wav"
git lfs track "*.mp4"
```

---

# Contribution Workflow

## 1. Pull Latest Changes

```bash
git checkout dev
git pull origin dev
```

---

## 2. Create Branch

Feature:

```bash
git checkout -b feat/my-feature
```

Fix:

```bash
git checkout -b fix/my-fix
```
Chore:

```bash
git checkout -b chore/my-chore
```

---

## 3. Make Changes

- Keep commits small
- Test before pushing
- Avoid modifying unrelated files

---

## 4. Commit Changes

```bash
git add .
git commit -m "feat/my-feat [OR] fix/my-fix [OR] chore/my-chore"
```

---

## 5. Push Branch

```bash
git push origin feat/my-feature
```

---

## 6. Open Pull Request

Create PR:

```text
feat/my-feature → dev
```

---

# Collaboration Rules

## NEVER

- Push directly to `main`
- Push directly to `dev`
- Delete `.meta` files
- Commit `Library/`
- Upgrade Unity version yourself
- Move assets outside Unity Editor

---

## ALWAYS

- Pull before working
- Use feature/fix/chore branches
- Write meaningful commit messages
- Test before creating PR
- Ask before changing core systems
- Check for changes in the dev branch before creating a pull request to avoid merge conflicts

---

# Scene Management Rules

- Avoid editing the same scene simultaneously
- Use additive scenes whenever possible
- Convert reusable objects into prefabs

---

# Coding Standards

## Naming Conventions

### Scripts

```text
PlayerController.cs
InventoryManager.cs
EnemySpawner.cs
```

### Prefabs

```text
PF_Player
PF_Enemy
PF_Weapon
```

### Materials

```text
MAT_Stone
MAT_Metal
```

### Textures

```text
T_Grass_D
T_Grass_N
```

---

# CI/CD

GitHub Actions will automatically:

- Verify project compiles
- Run tests
- Validate pull requests
- Generate builds for releases

---

# Final Notes

This project prioritizes:

- Clean collaboration
- Stable workflows
- Learning professional pipelines
- Finishing a playable game

If unsure about anything, ask before making project-wide changes.