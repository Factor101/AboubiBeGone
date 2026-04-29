<<<<<<< HEAD
# AboubiBeGone
A simple Straftat mod that disables ragdoll spawns on player death
=======
# yet another straftistics clone
## 

## Overview
This mod for *STRAFTAT* displays player's ranks under their name in lobbies and in game

### How It Works
the mod listens to `setPlayerValues` and `UpdatePLayerList`.
- SetPlayerValues:
    - on call, the mod will either replace the current displayed name with a cached string in the format `name \n rank(score)`,
    or fetch the single player's rank and cache it if it is not available
- UpdatePlayerList:
  - this is used to avoid caching too many users. the game calls this func when you leave the game (and other instances i guess)
  when called, the mod will clear unnecessary cached players if the cache has more than 5 players.

## Data Source
The mod retrieves rank and score from the game's leaderboard system via Steamworks API

## Safety
- No evidence of harmful behavior.
- Uses BepInEx for logging, with no unauthorized file or system access.

## Usage
1. Install the mod using a compatible mod loader (e.g., BepInEx).
2. Ensure *STRAFTAT* and Steam are running.
3. Opponent stats will appear under their names in the lobby and in the tab menu

## Notes
- Requires a working Steam integration for leaderboard data.
- Tested with *STRAFTAT*'s official leaderboard system.
- The mod may break and stop displaying ranks at times, it is a known issue -- PRs welcome!

>>>>>>> 7f81ca7 (init)
