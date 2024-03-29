using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace TaskBarRenamer
{
    #region External Code

    [Flags]
    public enum WindowStyleFlags : uint
    {
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = 0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_GROUP = 0x00020000,
        WS_TABSTOP = 0x00010000,
        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,
    }

    [Flags]
    public enum ExtendedWindowStyleFlags
    {
        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,

        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,

        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,

        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,

        WS_EX_LAYERED = 0x00080000,

        WS_EX_NOINHERITLAYOUT = 0x00100000,
        WS_EX_LAYOUTRTL = 0x00400000,

        WS_EX_COMPOSITED = 0x02000000,
        WS_EX_NOACTIVATE = 0x08000000
    }

    #region EnumWindows

    public class EnumWindows
    {
        #region Delegates

        private delegate int EnumWindowsProc(IntPtr hwnd, int lParam);

        #endregion

        #region UnManagedMethods

        private class UnManagedMethods
        {
            [DllImport("user32")]
            public static extern int EnumWindows(
                EnumWindowsProc lpEnumFunc,
                int lParam);

            [DllImport("user32")]
            public static extern int EnumChildWindows(
                IntPtr hWndParent,
                EnumWindowsProc lpEnumFunc,
                int lParam);
        }

        #endregion

        public EnumWindowsCollection Items
        {
            get;
            private set;
        }

        public void GetWindows()
        {
            this.Items = new EnumWindowsCollection();
            UnManagedMethods.EnumWindows(
                new EnumWindowsProc(this.WindowEnum), 0);
        }

        public void GetWindows(IntPtr hWndParent)
        {
            this.Items = new EnumWindowsCollection();
            UnManagedMethods.EnumChildWindows(
                hWndParent,
                new EnumWindowsProc(this.WindowEnum), 0);
        }

        #region EnumWindows callback

        private int WindowEnum(
            IntPtr hWnd,
            int lParam)
        {
            return this.OnWindowEnum(hWnd) ? 1 : 0;
        }

        #endregion

        protected virtual bool OnWindowEnum(IntPtr hWnd)
        {
            Items.Add(hWnd);
            return true;
        }
    }

    #endregion EnumWindows

    #region EnumWindowsCollection

    public class EnumWindowsCollection : ReadOnlyCollectionBase
    {
        public void Add(IntPtr hWnd)
        {
            EnumWindowsItem item = new EnumWindowsItem(hWnd);
            InnerList.Add(item);
        }

        public EnumWindowsItem this[int index]
        {
            get
            {
                if ((index >= InnerList.Count) | (index < 0))
                    throw new ArgumentOutOfRangeException();

                return (EnumWindowsItem)InnerList[index];
            }
        }
    }

    #endregion

    #region EnumWindowsItem

    public class EnumWindowsItem
    {
        #region Structures

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private readonly struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private readonly struct FLASHWINFO
        {
            private readonly int cbSize;
            private readonly IntPtr hwnd;
            private readonly int dwFlags;
            private readonly int uCount;
            private readonly int dwTimeout;
        }

        #endregion

        #region UnManagedMethods

        private class UnManagedMethods
        {
            [DllImport("user32")]
            public static extern int IsWindowVisible(
                IntPtr hWnd);

            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int GetWindowText(
                IntPtr hWnd,
                StringBuilder lpString,
                int cch);

            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int GetWindowTextLength(
                IntPtr hWnd);

            [DllImport("user32")]
            public static extern int BringWindowToTop(IntPtr hWnd);

            [DllImport("user32")]
            public static extern int SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32")]
            public static extern int IsIconic(IntPtr hWnd);

            [DllImport("user32")]
            public static extern int IsZoomed(IntPtr hwnd);

            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int GetClassName(
                IntPtr hWnd,
                StringBuilder lpClassName,
                int nMaxCount);

            [DllImport("user32")]
            public static extern int FlashWindow(
                IntPtr hWnd,
                ref FLASHWINFO pwfi);

            [DllImport("user32")]
            public static extern int GetWindowRect(
                IntPtr hWnd,
                ref RECT lpRect);

            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int SendMessage(
                IntPtr hWnd,
                int wMsg,
                IntPtr wParam,
                IntPtr lParam);

            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern uint GetWindowLong(
                IntPtr hwnd,
                int nIndex);

            public const int WM_COMMAND = 0x111;
            public const int WM_SYSCOMMAND = 0x112;

            public const int SC_RESTORE = 0xF120;
            public const int SC_CLOSE = 0xF060;
            public const int SC_MAXIMIZE = 0xF030;
            public const int SC_MINIMIZE = 0xF020;

            public const int GWL_STYLE = (-16);
            public const int GWL_EXSTYLE = (-20);

            public const int FLASHW_STOP = 0;
            public const int FLASHW_CAPTION = 0x00000001;
            public const int FLASHW_TRAY = 0x00000002;
            public const int FLASHW_ALL = (FLASHW_CAPTION | FLASHW_TRAY);
            public const int FLASHW_TIMER = 0x00000004;
            public const int FLASHW_TIMERNOFG = 0x0000000C;
        }

        #endregion

        private readonly IntPtr hWnd = IntPtr.Zero;

        public override Int32 GetHashCode()
        {
            return (Int32)this.hWnd;
        }

        public IntPtr Handle
        {
            get
            {
                return this.hWnd;
            }
        }

        public string Text
        {
            get
            {
                StringBuilder title = new StringBuilder(260, 260);
                UnManagedMethods.GetWindowText(this.hWnd, title, title.Capacity);
                return title.ToString();
            }
        }

        public string ClassName
        {
            get
            {
                StringBuilder className = new StringBuilder(260, 260);
                UnManagedMethods.GetClassName(this.hWnd, className, className.Capacity);
                return className.ToString();
            }
        }

        public bool Iconic
        {
            get
            {
                return (UnManagedMethods.IsIconic(this.hWnd) != 0);
            }
            set
            {
                UnManagedMethods.SendMessage(
                    this.hWnd,
                    UnManagedMethods.WM_SYSCOMMAND,
                    (IntPtr)UnManagedMethods.SC_MINIMIZE,
                    IntPtr.Zero);
            }
        }

        public bool Maximised
        {
            get
            {
                return (UnManagedMethods.IsZoomed(this.hWnd) != 0);
            }
            set
            {
                UnManagedMethods.SendMessage(
                    this.hWnd,
                    UnManagedMethods.WM_SYSCOMMAND,
                    (IntPtr)UnManagedMethods.SC_MAXIMIZE,
                    IntPtr.Zero);
            }
        }

        public bool Visible
        {
            get
            {
                return (UnManagedMethods.IsWindowVisible(this.hWnd) != 0);
            }
        }

        public Rectangle Rect
        {
            get
            {
                RECT rc = new RECT();
                UnManagedMethods.GetWindowRect(
                    this.hWnd,
                    ref rc);
                Rectangle rcRet = new Rectangle(
                    rc.Left, rc.Top,
                    rc.Right - rc.Left, rc.Bottom - rc.Top);
                return rcRet;
            }
        }

        public Point Location
        {
            get
            {
                Rectangle rc = Rect;
                Point pt = new Point(
                    rc.Left,
                    rc.Top);
                return pt;
            }
        }

        public Size Size
        {
            get
            {
                Rectangle rc = Rect;
                Size sz = new Size(
                    rc.Right - rc.Left,
                    rc.Bottom - rc.Top);
                return sz;
            }
        }

        public void Restore()
        {
            if (Iconic)
            {
                UnManagedMethods.SendMessage(
                    this.hWnd,
                    UnManagedMethods.WM_SYSCOMMAND,
                    (IntPtr)UnManagedMethods.SC_RESTORE,
                    IntPtr.Zero);
            }
            UnManagedMethods.BringWindowToTop(this.hWnd);
            UnManagedMethods.SetForegroundWindow(this.hWnd);
        }

        public WindowStyleFlags WindowStyle
        {
            get
            {
                return (WindowStyleFlags)UnManagedMethods.GetWindowLong(
                    this.hWnd, UnManagedMethods.GWL_STYLE);
            }
        }

        public ExtendedWindowStyleFlags ExtendedWindowStyle
        {
            get
            {
                return (ExtendedWindowStyleFlags)UnManagedMethods.GetWindowLong(
                    this.hWnd, UnManagedMethods.GWL_EXSTYLE);
            }
        }

        public EnumWindowsItem(IntPtr hWnd)
        {
            this.hWnd = hWnd;
        }
    }

    #endregion

    #endregion
}