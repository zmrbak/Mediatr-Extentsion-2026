using EnvDTE;
using System;

namespace Mediatr_Extentsion_2026.Extensions
{
    public static class CodeClassExtensions
    {
        public static CodeClass InsertInterfaceToTheEnd(this CodeClass codeClass, string interfaceValue)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            if (null == codeClass) throw new ArgumentNullException(nameof(codeClass));

            var editPoint = codeClass.StartPoint.CreateEditPoint();
            editPoint.EndOfLine();
            editPoint.Insert(interfaceValue);
            return codeClass;
        }
    }
}
