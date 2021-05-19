using Godot;
using System;

public class Settings : Control
{
    private const double VolumeFractions = 100;
	private Slider _volumeMaster;
    private Slider _volumeMusic;
    private Slider _volumeEffects;
    private AudioStreamPlayer _sfx;
    private ItemList _ballStylesItemList;

    public override void _Ready()
    {         
        _sfx = GetNode<AudioStreamPlayer>("SFX");
        _volumeMaster = GetNode<Slider>("SettingsItems/MasterVolume");
        _volumeMusic = GetNode<Slider>("SettingsItems/MusicVolume");
        _volumeEffects = GetNode<Slider>("SettingsItems/Effects/EffectsVolume");
        _ballStylesItemList = GetNode<ItemList>("SettingsItems/BallStylesItemList");

        _volumeMaster.MaxValue = VolumeFractions;
        _volumeMusic.MaxValue = VolumeFractions;
        _volumeEffects.MaxValue = VolumeFractions;
        
        _volumeMaster.Value = Convert.ToDouble(Userdata.GetConfig("volume_master")) * VolumeFractions;
        _volumeMusic.Value = Convert.ToDouble(Userdata.GetConfig("volume_music")) * VolumeFractions;
        _volumeEffects.Value = Convert.ToDouble(Userdata.GetConfig("volume_sfx")) * VolumeFractions;
        _ballStylesItemList.Select(Convert.ToInt32(Userdata.GetConfig("ball_texture_style")));
    }

    private void OnMasterVolumeValueChanged(float value)
    {
        Userdata.SaveConfig("volume_master", value  / VolumeFractions);     
    }

    private void OnMusicVolumeValueChanged(float value)
    {
        Userdata.SaveConfig("volume_music", value / VolumeFractions);     
    }

    private void OnEffectsVolumeValueChanged(float value)
    {
        Userdata.SaveConfig("volume_sfx", value / VolumeFractions);     
    }
    private void OnTestButtonPressed()
    {
       _sfx.Play(); 
    }

    private void OnBallStylesItemListItemSelected(float value)
    {
        Userdata.SaveConfig("ball_texture_style", value);     
    }

    private void OnBackButtonPressed()
    {
        GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
    }
}
