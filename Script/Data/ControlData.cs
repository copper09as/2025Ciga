using Godot;
using System;

public static class ControlData
{
    public static string[] keyCode = [StringResource.LeftControl, StringResource.UpControl, StringResource.DownControl, StringResource.RightControl];
    private static string[] roatControl;
    public static string[] RoatControl
    {
        get
        {
            if (roatControl == null)
                roatControl
                = new string[]
                { StringResource.LeftControl, StringResource.UpControl, StringResource.DownControl, StringResource.RightControl };
            return roatControl;
        }
    }
}
