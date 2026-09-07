# umut-league-starter

Starter Unity project for a licenseless, optimized mobile football game (iOS / iPhone 11).

This repository contains a minimal Unity project structure and prototype C# scripts to get a playable, highly-optimized mobile football prototype running on iPhone 11 using only free tools (Unity Personal, Blender, Mixamo, MakeHuman/UMA, etc.).

Important notes
- Do NOT use real player names, faces, logos or other licensed content without permission. This starter uses procedural/original characters only.
- iOS distribution: you can sideload to your own device with a free Apple ID for temporary testing (7-day provisioning). For broader distribution use Apple Developer Program ($99/yr).

What’s included
- Assets/Scripts/PlayerController.cs — basic player movement & animator hookup
- Assets/Scripts/BallController.cs — simple ball physics + kick API
- Assets/Scripts/RosterGenerator.cs — random roster generator (parametric)
- Assets/Scripts/SimpleTeamAI.cs — very simple team decision logic
- Assets/Editor/ApplyiOSSettings.cs — editor tool to apply iOS 60FPS recommended settings
- Assets/Editor/UmutLeagueSetup.cs — editor tool to create example scene, player & ball prefabs
- README with quickstart + iPhone 11 optimization tips

Requirements
- macOS with Xcode (for building to iOS)
- Unity 2022 LTS or 2023 LTS (URP recommended) with iOS Build Support
- Optional: Blender, MakeHuman/MB-Lab or UMA2, Mixamo for animations

Quickstart (summary)
1) Clone this repo to your Mac:
   git clone https://github.com/umut631/umut-league-starter.git
2) Open Unity (recommended 2022/2023 LTS) and open the project folder.
3) In Unity Editor menu: UmutLeague > Create Example Scene & Prefabs — this will create Assets/Scenes/Main.unity, Prefabs/Player.prefab, Prefabs/Ball.prefab and a simple material.
4) UmutLeague > Apply iOS 60FPS Settings — applies PlayerSettings (bundle id, iOS target, IL2CPP, ARM64, Metal) and assigns a URP asset if present. It can also add a runtime script that sets Application.targetFrameRate = 60.
5) Create a scene or open Assets/Scenes/Main.unity and press Play to test in Editor, then File > Build Settings > iOS > Build.
6) Open the generated Xcode project, set Signing Team, connect your iPhone 11 and Run.

iPhone 11 optimization notes (target 60 FPS)
- Use URP with SRP Batcher & GPU Instancing enabled.
- Single directional light + baked GI; small shadow distance (20–30m).
- Use ASTC compression for textures (4x4 hero, 6x6/8x8 for others).
- Use LOD groups and impostors for distant players; limit active skinned meshes.
- Avoid expensive post-processing; prefer cheap color grading and subtle bloom.
- Profiler workflow: Unity Profiler attached to device + Xcode Metal capture.

Menu tools
- UmutLeague > Create Example Scene & Prefabs
- UmutLeague > Apply iOS 60FPS Settings

License
- MIT


---

If you want further automation (example AnimatorController, demo UI, or packaged ProjectSettings) tell me and I will push them too.