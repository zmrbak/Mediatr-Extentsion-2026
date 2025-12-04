using EnvDTE;
using EnvDTE90;
using System;

namespace Mediatr_Extentsion_2026.Decorators
{
    internal class DteWrapper
    {
        private DTE _dte;
        public DteWrapper(DTE dte)
        {
            _dte = dte ?? throw new ArgumentNullException(nameof(dte));
        }

        public bool HasNoSelectedItems
        {
            get
            {
                Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
                return _dte.SelectedItems?.Count == 0;
            }
        }

        private SelectedItem _firstSelectedItem;
        public SelectedItem FirstSelectedItem
        {
            get
            {
                Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
                if (null == _firstSelectedItem)
                {
                    _firstSelectedItem = HasNoSelectedItems ? null : _dte.SelectedItems?.Item(1);
                }

                return _firstSelectedItem;
            }
        }


        private Project _selectedProject;
        public Project SelectedProject
        {
            get
            {
                Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
                if (null == _selectedProject)
                {
                    _selectedProject = null != FirstSelectedItem?.Project ? FirstSelectedItem.Project : FirstSelectedItem?.ProjectItem?.ContainingProject;
                }

                return _selectedProject;
            }
        }

        public Solution3 Solution
        {
            get
            {
                Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
                return _dte.Solution as Solution3;
            }
        }

        private string _defaultClassTemplate;
        public string DefaultClassTemplate
        {
            get
            {
                Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
                if (null == _defaultClassTemplate)
                {
                    _defaultClassTemplate = Solution.GetProjectItemTemplate("Class", "CSharp");
                }

                return _defaultClassTemplate;
            }
        }


        private ProjectItems _selectedItemProjectItems;
        public ProjectItems SelectedItemProjectItems
        {
            get
            {
                Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
                if (null == _selectedItemProjectItems)
                {
                    _selectedItemProjectItems = FirstSelectedItem.ProjectItem.ProjectItems ?? SelectedProject.ProjectItems;
                }

                return _selectedItemProjectItems;
            }
        }
    }
}
