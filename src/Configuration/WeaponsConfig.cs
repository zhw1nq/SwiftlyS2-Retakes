namespace SwiftlyS2_Retakes.Configuration;

/// <summary>
/// Configuration for weapons.
/// </summary>
public sealed class WeaponsConfig
{
  public bool BuyMenuEnabled { get; set; } = true;

  public DefaultWeaponsConfig Defaults { get; set; } = new()
  {
    Pistol = new()
    {
      Primary = new() { T = "weapon_glock", Ct = "weapon_usp_silencer" },
      Secondary = new() { T = "weapon_glock", Ct = "weapon_usp_silencer" }
    },
    HalfBuy = new()
    {
      Primary = new() { T = "weapon_mac10", Ct = "weapon_mp9" },
      Secondary = new() { T = "weapon_glock", Ct = "weapon_usp_silencer" }
    },
    FullBuy = new()
    {
      Primary = new() { T = "weapon_ak47", Ct = "weapon_m4a1_silencer" },
      Secondary = new() { T = "weapon_glock", Ct = "weapon_usp_silencer" }
    }
  };

  public RoundWeaponsConfig Pistols { get; set; } = new()
  {
    All = new() { "weapon_elite", "weapon_deagle", "weapon_revolver", "weapon_cz75a", "weapon_p250" },
    Ct = new() { "weapon_fiveseven", "weapon_usp_silencer", "weapon_hkp2000" },
    T = new() { "weapon_glock", "weapon_tec9" }
  };

  public RoundWeaponsConfig HalfBuy { get; set; } = new()
  {
    All = new(),
    T = new() { "weapon_mac10", "weapon_mp7", "weapon_bizon", "weapon_mp5sd", "weapon_p90", "weapon_ump45" },
    Ct = new() { "weapon_mp7", "weapon_mp9", "weapon_bizon", "weapon_mp5sd", "weapon_p90", "weapon_ump45" },
  };

  public RoundWeaponsConfig FullBuy { get; set; } = new()
  {
    All = new(),
    T = new() { "weapon_ak47", "weapon_galilar", "weapon_sg556" },
    Ct = new() { "weapon_aug", "weapon_famas", "weapon_m4a1", "weapon_m4a1_silencer" },
  };
}

/// <summary>
/// Configuration for server-defined default loadouts when players have no saved preference yet.
/// </summary>
public sealed class DefaultWeaponsConfig
{
  public DefaultRoundLoadoutConfig Pistol { get; set; } = new();
  public DefaultRoundLoadoutConfig HalfBuy { get; set; } = new();
  public DefaultRoundLoadoutConfig FullBuy { get; set; } = new();
}

/// <summary>
/// Default loadout for a given round type.
/// </summary>
public sealed class DefaultRoundLoadoutConfig
{
  public DefaultWeaponSelectionConfig Primary { get; set; } = new();
  public DefaultWeaponSelectionConfig Secondary { get; set; } = new();
}

/// <summary>
/// Team-aware default weapon selection.
/// </summary>
public sealed class DefaultWeaponSelectionConfig
{
  public string? T { get; set; }
  public string? Ct { get; set; }
}

/// <summary>
/// Configuration for weapons per round type.
/// </summary>
public sealed class RoundWeaponsConfig
{
  public List<string> All { get; set; } = new();
  public List<string> T { get; set; } = new();
  public List<string> Ct { get; set; } = new();
}
