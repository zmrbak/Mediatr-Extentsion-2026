using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediatr_Extentsion_2026.Extensions
{
    public static class FileCodeModel2Extensions
    {
        public static FileCodeModel2 AddNotExistingImports(this FileCodeModel2 fileCodeModel, IEnumerable<string> importsToAdd)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (null == fileCodeModel)
            {
                throw new ArgumentNullException(nameof(fileCodeModel));
            }

            var currentImports = fileCodeModel.CodeElements
                .OfType<CodeImport>()
                .Select(x =>
                {
                    Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
                    return x.Namespace;
                })
                .ToList();

            foreach (var import in importsToAdd)
            {
                if (!currentImports.Any(x => x == import))
                {
                    fileCodeModel.AddImport(import, 0);
                }
            }

            return fileCodeModel;
        }
    }
}
