using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public partial class Mouse {
    [DllImport("user32.dll")]
    static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
    [StructLayout(LayoutKind.Sequential)]
    struct LASTINPUTINFO {
        public uint cbSize;
        public int dwTime;
    }
    public bool IsInactive(int inactivity_threshold) {
        LASTINPUTINFO lii = new LASTINPUTINFO();
        lii.cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO));
        GetLastInputInfo(ref lii);
        int idleTime = Environment.TickCount - lii.dwTime;
        return idleTime > inactivity_threshold;
    }
}