using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Solution.MouseMover.WinFormsApp
{
  unsafe class MouseMoverEngine
  {
    //
    //http://www.pinvoke.net/default.aspx/user32/sendinput.html
    //
    [StructLayout(LayoutKind.Sequential, Size = 28)]
    private struct INPUT
    {
      public int TYPE;
      public int dx;
      public int dy;
      public int mouseData;
      public int dwFlags;
      public int time;
      public IntPtr dwExtraInfo;
    }
    [Flags]
    enum MouseDataFlags : uint
    {
      /// <summary>
      /// First button was pressed or released
      /// </summary>
      XBUTTON1 = 0x0001,
      /// <summary>
      /// Second button was pressed or released
      /// </summary>
      XBUTTON2 = 0x0002
    }
    [Flags]
    enum MouseEventFlags : uint
    {
      /// <summary>
      /// Movement occured
      /// </summary>
      MOUSEEVENTF_MOVE = 0x0001,
      /// <summary>
      /// button down (pair with an up to create a full click)
      /// </summary>
      MOUSEEVENTF_LEFTDOWN = 0x0002,
      /// <summary>
      /// button up (pair with a down to create a full click)
      /// </summary>
      MOUSEEVENTF_LEFTUP = 0x0004,
      /// <summary>
      /// button down (pair with an up to create a full click)
      /// </summary>
      MOUSEEVENTF_RIGHTDOWN = 0x0008,
      /// <summary>
      /// button up (pair with a down to create a full click)
      /// </summary>
      MOUSEEVENTF_RIGHTUP = 0x0010,
      /// <summary>
      /// button down (pair with an up to create a full click)
      /// </summary>
      MOUSEEVENTF_MIDDLEDOWN = 0x0020,
      /// <summary>
      /// button up (pair with a down to create a full click)
      /// </summary>
      MOUSEEVENTF_MIDDLEUP = 0x0040,
      /// <summary>
      /// button down (pair with an up to create a full click)
      /// </summary>
      MOUSEEVENTF_XDOWN = 0x0080,
      /// <summary>
      /// button up (pair with a down to create a full click)
      /// </summary>
      MOUSEEVENTF_XUP = 0x0100,
      /// <summary>
      /// Wheel was moved, the value of mouseData is the number of movement values
      /// </summary>
      MOUSEEVENTF_WHEEL = 0x0800,
      /// <summary>
      /// Map X,Y to entire desktop, must be used with MOUSEEVENT_ABSOLUTE
      /// </summary>
      MOUSEEVENTF_VIRTUALDESK = 0x4000,
      /// <summary>
      /// The X and Y members contain normalised Absolute Co-Ords. If not set X and Y are relative
      /// data to the last position (i.e. change in position from last event)
      /// </summary>
      MOUSEEVENTF_ABSOLUTE = 0x8000
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MouseInputData
    {
      /// <summary>
      /// The x value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
      /// otherwise it is a delta from the last position
      /// </summary>
      public int dx;
      /// <summary>
      /// The y value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
      /// otherwise it is a delta from the last position
      /// </summary>
      public int dy;
      /// <summary>
      /// Wheel event data, X buttons
      /// </summary>
      public uint mouseData;
      /// <summary>
      /// ORable field with the various flags about buttons and nature of event
      /// </summary>
      public MouseEventFlags dwFlags;
      /// <summary>
      /// The timestamp for the event, if zero then the system will provide
      /// </summary>
      public uint time;
      /// <summary>
      /// Additional data obtained by calling app via GetMessageExtraInfo
      /// </summary>
      public IntPtr dwExtraInfo;
    }


    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);
    //private const int INPUT_MOUSE_EVENT = 0;
    public const int INPUT_MOUSE_EVENT = 0;
    public const int INPUT_KEYBOARD = 1;
    public const int INPUT_HARDWARE = 2;
    private const int INPUT_MOUSE_EVENT_MOVE = 0x0001; 

    public void Move()
    {
      //MouseMoverEngine.MouseInputData mouseInputData = new MouseMoverEngine.MouseInputData();
      //mouseInputData.dx = 0;
      //mouseInputData.dy = 0;
      //mouseInputData.mouseData = 0;
      //input.time = 0;
      //input.dwExtraInfo = (IntPtr)0;
      //mouseInputData.dwFlags = MouseEventFlags.MOUSEEVENTF_MOVE;

      INPUT input = new INPUT();
      input.TYPE = MouseMoverEngine.INPUT_MOUSE_EVENT;
      input.dx = 0;
      input.dy = 0;
      input.mouseData = 0;
      input.dwFlags = MouseMoverEngine.INPUT_MOUSE_EVENT_MOVE;
      input.time = 0;
      input.dwExtraInfo = (IntPtr)0;

      if (SendInput(1, ref input, 28) != 1)
      //if (SendInput(1, ref input, Marshal.SizeOf(new INPUT())) != 1)
      {
        throw new Win32Exception();
      }
    }

  }

}