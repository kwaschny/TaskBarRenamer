using System;
using System.Text.RegularExpressions;

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
            Handle = handle;
            OriginalName = originalName;
            NewName = newName;
            ForceName = forceName;
        }

        #endregion
    }

    public enum RenameType
    {
        Exact,
        Wildcard,
        RegExp
    }

    public class AutomaticEntry
    {
        #region Fields

        public RenameType Type
        {
            get;
            set;
        }
        public string From
        {
            get
            {
                switch (Type)
                {
                    case RenameType.Wildcard:
                        return ("wc$" + FromName);
                    case RenameType.RegExp:
                        return ("re$" + FromName);
                    default:
                        return FromName;
                }
            }
        }
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

        private Regex wildcard;
        private Regex regexp;

        #endregion

        #region Methods

        public AutomaticEntry(string fromName, string toName, bool forceName)
        {
            if (fromName.StartsWith("wc$"))
            {
                Type = RenameType.Wildcard;
                FromName = fromName.Remove(0, 3);
            }
            else if (fromName.StartsWith("re$"))
            {
                Type = RenameType.RegExp;
                FromName = fromName.Remove(0, 3);
            }
            else
            {
                Type = RenameType.Exact;
                FromName = fromName;
            }

            switch (Type)
            {
                case RenameType.Wildcard:
                    wildcard = BuildRegex(FromName, Type);
                    break;

                case RenameType.RegExp:
                    regexp = BuildRegex(FromName, Type);
                    break;
            }

            ToName = toName;
            ForceName = forceName;
        }

        public bool Matches(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            switch (Type)
            {
                case RenameType.Wildcard:
                    return wildcard.IsMatch(name);

                case RenameType.RegExp:
                    return regexp.IsMatch(name);
            }

            return name.Equals(FromName, StringComparison.OrdinalIgnoreCase);
        }

        public string Rename(string name)
        {
            const int MAX_CAPTURES = 20;

            switch (Type)
            {
                case RenameType.RegExp:

                    string result = ToName;

                    MatchCollection matches = regexp.Matches(name);
                    if (matches.Count > 0)
                    {
                        GroupCollection captures = matches[0].Groups;
                        for (int i = 0; i < MAX_CAPTURES; i++)
                        {
                            string replacement;
                            if (captures.Count > i) {
                                replacement = captures[i].Value;
                            }
                            else
                            {
                                replacement = string.Empty;
                            }

                            result = result.Replace((@"\" + i), replacement);
                        }
                    }
                    return result;
            }

            return ToName;
        }

        public static Regex BuildRegex(string pattern, RenameType type)
        {
            try
            {
                switch (type)
                {
                    case RenameType.Wildcard:
                        return new Regex(
                            Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", "."),
                            RegexOptions.IgnoreCase
                        );

                    case RenameType.RegExp:
                        return new Regex(pattern, RegexOptions.IgnoreCase);
                }
            }
            catch { }

            return null;
        }

        #endregion
    }
}