# Archipelago XIV

This repo contains two separate, yet intertwined projects.

`src` contains an APWorld for Final Fantasy 14, built on top of Manual.
`ArchipelagoXIV` contains a Dalamud plugin that is a tracker/client for PC players

Both of them probably need more love.

## Summary

Checks: Duties and overworld activities
Items: Zone access and Progressive Level Caps

What you need: A character that's up to date on the MSQ, and has everything unlocked.


## Locations

Note: Almost everything listed below can be disabled with yaml options, have a read of the template yaml for customization details

* Fates
  * With fatesanity enabled, each named fate is a unique check.  Otherwise, do up to 5 fates per zone.
* Dungeons
* Trials
* Normal Raids
* Alliance Raids
* Guildhests
* Ocean Fishing Routes (bihourly fishing raids)
* Bozja ARs (CLL, DR, DAL)
* Fishsanity: Catch every fish
* Returning to the Waking Sands

## Items

* Progressive Level caps
  * 5 Levels per bundle, separated by class.  If you don't have everything at max, I suggest setting `force_classes` with the classes you have/can get to cap within the duration of your run.
* Zone Access
  * You cannot pass through zones you do not have access to. So Outer La Noscea is useless without Upper La Noscea, and so on.
  * You always have access to the three starting cities and their corresponding Central zone, and can use boats, airships, and zone edges to traverse when you have the appropriate access.
* Raid Unlocks
  * Because hitting a given expansion's postgame unlocks so much to do at once, this attempts to slow down how many checks unlock at once.
* Fishsanity: Permittted Baits
* "Memories of a Distant Land"
  * Collect these to finish the game.

## Important Things To Know

* Starting Zone
  * At the beginning of the game, you have access to checks in Gridania, Central Shroud, Ul'dah, Central Thanalan, Limsa Lominsa, and Middle La Noscea.
  * From there, you might get nearby zones (Such as South Shroud, Eastern Thanalan, etc). You might get Boat zones (Kugane, Old Sharlayan), or you might get Airship zones (Ishgard, Radz-at-Han, Gold Saucer).
* FATES
  * You can calculate your maxmium level access to a fate by allowing up to 4+ levels than your current level than the set level of the FATE.
    * This corresponds to the "Minimum" level a FATE will allow before ignoring your contribution.
	* For Example, If I want to check if I can currently participate in a FATE that is level 13, My current job level needs to be level 9 or higher.
* Tacker
  * If you are not using the Dalamud plugin, it is STRONGLY suggested you install [Universal Tracker](https://discord.com/channels/1097532591650910289/1176939614985011200).  There is a lot of complex logic, and far too many checks.  Please do not try to figure it out by hand.

## Fishsanity
* Fishing data is sourced from [Garland Tools](https://www.garlandtools.org/ffxivfisher/).
* You only have to catch each fish once, regardless of how many zones it appears in
* FSH level requirements round down.  This means that a level 1 hole is avilable with zero levels. A level 8 hole with 5, etc.
* A fish is in Logic if you have access to a zone, the primary bait for that zone, and FSH levels equal to the level of the fishing hole.
* As an example, Merlthor Goby can be caught in most places with a Lugworm, but in Western La Noscea there's a fishing hole where it prefers Pill Bugs.  As such,  Merlthor Goby is in logic if:
  * You have Lugworm and Limsa and FSH 0.
  * You have Pill Bug and Western La Noscea and FSH 50.
* Note that we're looking at the level of the fishing hole, not the level of the Fish.
  * This means that Octomammoth, the Big Fish for Limsa Lower Docks, is considered Level 1 (And therefore needs 0 FSH Levels)

## Dalamud Plugin

The plugin connects to the Archipelago Servers and does a few useful things:
* Shows text chat and recieved items
* Provides several in-game UI Elements to help you track what's in logic
* Automatically sends checks (only if they are in logic)

The Plugin does not:
* Prevent you from doing anything in-game
* Physically restrict access to zones or classes

It will warn you if you do something it deems not in logic.

## Dalamud UIs
(Note to self, add screenshots)
### Text Chat
This is sent via the in-game chat in the "PvP Team" channel.

### Recieving Items
This uses the Quest Notification popup

### In-Logic Checks
This is available in the "Server Info Bar" (Generally top right of your HUD), and in the ImGui window
In-Logic Dungeons are also shown with the "Bonus Rewards" icon in Duty Finder.

### Available Class Levels
Also in the Server Info bar.  Mouse over the Class info for a full list.
