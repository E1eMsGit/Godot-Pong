using Godot;
using System;
using System.Collections.Generic;

public class Userdata : Node
{
    private const string ConfigFile = "user://config.cfg";   
    private static Dictionary<string, double> _defaultConfig; 
    private static List<Texture> _ballTextures;
    private enum BUS 
    {
        MASTER, 
        MUSIC, 
        SFX
    };
    
    private Userdata()
    {
        _ballTextures = new List<Texture>()
        {
            (Texture)ResourceLoader.Load("res://Textures/Pong/ball.png"),
            (Texture)ResourceLoader.Load("res://Textures/Pong/RogozinFace.png")
        }; 

        _defaultConfig = new Dictionary<string, double>()
        {
            { "volume_master", 1.0 },
            { "volume_music", 1.0 },
            { "volume_sfx", 1.0 },
            { "ball_texture_style", 0.0 },
        };
        
        LoadConfig();
    }

    public static object GetConfig(string setting)
    {
        ConfigFile cfg = new ConfigFile();
        Error unexistant = cfg.Load(ConfigFile);
        
        if (unexistant == Error.FileNotFound)
        {
            cfg = RevertConfig(cfg);
        } 

	    var value = cfg.GetValue("settings", setting);
	    
        return value;
    }

    public static void SaveConfig(string setting, object value)
    {
        ConfigFile cfg = new ConfigFile();
        Error unexistant = cfg.Load(ConfigFile);
        
        if (unexistant == Error.FileNotFound)
        {
            cfg = RevertConfig(cfg);
        } 

        cfg.SetValue("settings", setting, value);
        cfg.Save(ConfigFile);

        SetAudio((int)BUS.MASTER, cfg.GetValue("settings", "volume_master"));
        SetAudio((int)BUS.MUSIC, cfg.GetValue("settings", "volume_music"));
        SetAudio((int)BUS.SFX, cfg.GetValue("settings", "volume_sfx"));
    }

    public static Texture GetBallTexture()
    {
        ConfigFile cfg = new ConfigFile();
        Error unexistant = cfg.Load(ConfigFile);
        
        if (unexistant == Error.FileNotFound)
        {
            RevertConfig(cfg);
            return null;
        } 
        
        return _ballTextures[Convert.ToInt32(cfg.GetValue("settings", "ball_texture_style"))];
    }
   
    public static void LoadConfig()
    {
        ConfigFile cfg = new ConfigFile();
        Error unexistant = cfg.Load(ConfigFile);
        
        if (unexistant == Error.FileNotFound)
        {
            RevertConfig(cfg);
            return;
        } 

        SetAudio((int)BUS.MASTER, cfg.GetValue("settings", "volume_master"));
        SetAudio((int)BUS.MUSIC, cfg.GetValue("settings", "volume_music"));
        SetAudio((int)BUS.SFX, cfg.GetValue("settings", "volume_sfx"));
    }

    private static ConfigFile RevertConfig(ConfigFile cfg)
    {
        foreach (var key in _defaultConfig.Keys)
        {
            cfg.SetValue("settings", key, _defaultConfig[key.ToString()]);
        }

        cfg.Save(ConfigFile);
        LoadConfig();

        return cfg;
    }

    private static void SetAudio(int bus, object value)
    {
        var db = Linear2Db((float)value);
        AudioServer.SetBusVolumeDb(bus, (float)db);
    }

    private static double Linear2Db(float pLinear) => Math.Log(pLinear) * 8.6858896380650365530225783783321;
}
