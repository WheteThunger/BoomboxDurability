## Features

- Allows customizing decay damage that deployable boomboxes take while playing

## Notes

- This plugin does not affect portable boomboxes. For those, you can use [Never Wear](https://umod.org/plugins/never-wear) and add the `fun.boomboxportable` item to the config.
- As of the August 2021 Rust update, deployable boom boxes no longer take decay damage by default. However, you can continue to use this plugin to add decay damage if you want.

## Permission

The following permissions come with this plugin's **default configuration**. Granting one to a player determines the decay rate of boomboxes they deploy, overriding the default.

- `boomboxdurability.fastdecay` -- approximately 15 minutes of play time with server convar `decay.scale 1.0`
- `boomboxdurability.slowdecay` -- approximately 4 hours of play time with server convar `decay.scale 1.0`
- `boomboxdurability.nodecay` -- unlimited play time

You can add more profiles in the plugin configuration (`ProfilesRequiringPermission`), and the plugin will automatically generate permissions of the format `boomboxdurability.<suffix>` when reloaded. If a player has permission to multiple profiles, only the last one will apply, based on the order in the config.

Note: Granting a permission to a player will not apply to existing boomboxes they have already deployed, unless you reload the plugin. This can be improved upon request if necessary for your server design.

## Configuration

Default configuration:

```json
{
  "DefaultDecayRate": 0.025,
  "ProfilesRequiringPermission": [
    {
      "PermissionSuffix": "fastdecay",
      "DecayRate": 0.111
    },
    {
      "PermissionSuffix": "slowdecay",
      "DecayRate": 0.007
    },
    {
      "PermissionSuffix": "nodecay",
      "DecayRate": 0.0
    }
  ]
}
```

- `DefaultDecayRate` -- Damage per second dealt to boom boxes while they are playing. Keep in mind that Rust multiplies this value times the server's `decay.scale`, so faster overall decay will cause boomboxes to decay faster while playing as well.
  - As of this writing, the vanilla value for boombox decay rate is `0.025`, which allows for approximately one hour of play time.
- `ProfilesRequiringPermission` -- Here you can define profiles that will override the default decay rate, if the player who deployed the boombox has the `boomboxdurability.<suffix>` permission.

## FAQ

#### Why do boomboxes decay so quickly while playing in the first place?

Vanilla Rust currently allows boomboxes to play music for approximately one hour. If you are seeing boomboxes decay faster, it's probably because you have a high value for the `decay.scale` convar, which multiplies the damage boomboxes take while playing.
