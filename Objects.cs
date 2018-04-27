namespace TaskBarRenamer
{
    public class TaskBarWindow
    {
        #region Fields

        public long Handle
        {
            get;
            private set;
        }
        public string OriginalName
        {
            get;
            private set;
        }
        public string NewName
        {
            get;
            set;
        }
        public bool ForceName
        {
            get;
            set;
        }

        public bool IsRenamed
        {
            get
            {
                return (NewName != null);
            }
        }

        #endregion

        #region Methods

        public void SetPredecessor(TaskBarWindow predecessor)
        {
            if (predecessor == null)
                return;

            NewName = OriginalName;
            OriginalName = predecessor.OriginalName;
            ForceName = predecessor.ForceName;
        }

        // Constructor
        public TaskBarWindow(EnumWindowsItem window)
        {
            if (window == null)
                return;

            ForceName = false;
            Handle = (long)window.Handle;
            OriginalName = window.Text;
        }
        public TaskBarWindow(long handle, string originalName, string newName, bool forceName)
        {
            Handle = Handle;
            OriginalName = originalName;
            NewName = newName;
            ForceName = forceName;
        }

        #endregion
    }

    public class AutomaticEntry
    {
        #region Fields

        public string FromName
        {
            get;
            set;
        }
        public string ToName
        {
            get;
            set;
        }
        public bool ForceName
        {
            get;
            set;
        }

        #endregion

        #region Methods

        // Constructor
        public AutomaticEntry(string fromName, string toName, bool forceName)
        {
            FromName = fromName;
            ToName = toName;
            ForceName = forceName;
        }

        #endregion
    }
}