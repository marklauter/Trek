# Game Model

Idea is to record the rules of the game here. Rules, actions, mechanics, rewards, etc. It's just a brain dump.

## Help System

Help system should be called Ships Computer or Data Banks or something goofy like that.

## Physics

As much as possible I want to create "real" physics. This means equations for acceleration, force, energy, and others, will be based on real physics. 
However, the units of time will be restricted to Turn and Star Day. Early prototyping shows that realistic depictions of energy for star ships is problematic. 
No one wants to be dealing in scientific notation for things like kilometers, joules, watts, etc. So as much as possible we'll use units from Star Trek, such as Cochrane for warp field displacement'

With consistent physics it should be possible to balance the game by tweaking equipment parameters instead of formulas.

### Energy/Power

1. Movement, scanning, weapons, shields, cloaking and other equipment and activities require power. 

2. If possible I'd like to use real world units.

Joule is energy intensity. (energy required to move 1kg thing 1 meter.) Measures instantaneous energy.
Watt is energy intensity over time, aka power. (Joule/s) Measures instantaneous power.
Watt Hours is power over time. (Joule/s/h). Measures power over time.

### Speed

1. In the real world, like flying an airplane, you would set a course and power setting, the power setting would determine the speed which in turn would determine the time from the point of origin to the destination. 

2. The power setting would determine how much fuel was being used.

3. In a turn based game, this seems problamatic. For one thing, asking the player to pick a course on a grid or hex board would be tricky. 

4. idea (based on Star Fleet Battles): https://en.wikipedia.org/wiki/Impulse-based_turn_system

Speed of light is 299,792,458 meters per second
Speed of light is ~ 300,000 km/s

### Mass

Memory alpha says the Enterprise D had a mass of 5 million gross tons - gross tons seems a useless measurement 
Intrepid class star ship (Voyager) had mass of 700,000 metric tons - that's 700 million kg

### Distance

Parallax Arc Second: Parsec == (360 * 60 * 60) / (2 * PI) au == ~3.26 light years == 206,264.8 au (better check these values with calculator. au seems off)
Astronomical Unit: Au == 150 million km == ~ 8 minutes at warp 1 

### Time

Game time is measured in turns and days. 
24 turns per day. So a turn is 60 minutes and should help giving realistic movement and action limitations in game.

## Ships

### Crew

Crew can be trained up on various ratings. This would work just like world of tanks. Just need to identify crew members, what types of ratings are appropriate, how long it takes for a rating to improve.

### Detecting and being detected

Similar to World of Tanks (3 rings of visibility) or the old hex-style Panzer board games, certain ships are more stealthy and certain ships have better sensing equipment. On any given turn
it makes sense to roll for detection. 

1. Ships have passive and active stealth

    a. Cloaking is active stealth and works against both active and passive scanning. Active stealth costs energy units per turn.

    b. Passive stealth is how well the ship's shape and materials absorb active sensor beams. Passive costs nothing.

2. Ships have passive and active scanners.

    a. Passive scanners are probably visual, so we'll say a ship is within passive scanning range when they can be detected with passive visual scanning.

    b. Active scanners are like radar or a sub's active ping. Active scanners have longer range than passive, but have the disadvatage that they can give the ship's position away.

    c. Active scanners can be set to short range or long range. Both scan types have a chance to alert enemy ships. Long range scanners give information on the adjacent sectors.

3. There are four ways that a ship might be detected.

    a. Passive Detection: Move into passive scanning range of enemy ship (or enemy ship moves to within it's passive scanning range of the player ship).

    b. Passive Detection: Move. Moving ships give off energy signatures that can be detected passively. Like dust from a moving tank, Deuterium fusion plasma output from impulse engines can be seen for some distance.

    c. Passive Detection: Shoot at someone. Firing weapons is a good way to get everyone's attention in the sector.

    d. Active Detection: Scan or be scanned. Some enemy ships will actively scan. Others won't. The player can detect enemy ships with a short range scan. Even cloaked ships have a chance to be detected, but it's very low. Like using a cammo net. Active scanning is like turning on a siren that says "HERE I AM!"

4. Enemy ships will tend to converge on your last spotted location. If you engage a scan pulse, but are out of view range of enemy ships, you can move to try to avoid detection. If you're in view range of an enmey ship you will remain in detected state until you move out of range, or behind an obtacle such as a dust cloud, planet nebula, etc. You could move into a zone that makes sensing difficult, like a radiation belt or something like that.
    
    a. Some enemy ships will actively scan while hunting for the player.

    b. Cloaked ships are very difficult to ahieve target lock against, even if they're actively scanning, though actively scanning will lower their cloak effectiveness.

    c. Cloaked ships must uncloak to fire. Presumably this is due to the high energy cost of cloaking. 



