﻿#region CodeMaid is Copyright 2007-2010 Steve Cadwallader.

// CodeMaid is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License version 3
// as published by the Free Software Foundation.
//
// CodeMaid is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details <http://www.gnu.org/licenses/>.

#endregion CodeMaid is Copyright 2007-2010 Steve Cadwallader.

using System.ComponentModel.Design;
using EnvDTE;
using SteveCadwallader.CodeMaid.Helpers;

namespace SteveCadwallader.CodeMaid.Commands
{
    /// <summary>
    /// A command that provides for collapsing nodes in the solution explorer tool window.
    /// </summary>
    internal class CollapseAllSolutionExplorerCommand : BaseCommand
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CollapseAllSolutionExplorerCommand"/> class.
        /// </summary>
        /// <param name="package">The hosting package.</param>
        internal CollapseAllSolutionExplorerCommand(CodeMaidPackage package)
            : base(package,
                   new CommandID(GuidList.GuidCodeMaidCommandCollapseAllSolutionExplorer, (int)PkgCmdIDList.CmdIDCodeMaidCollapseAllSolutionExplorer))
        {
        }

        #endregion Constructors

        #region BaseCommand Methods

        /// <summary>
        /// Called to update the current status of the command.
        /// </summary>
        protected override void OnBeforeQueryStatus()
        {
            var topItem = TopUIHierarchyItem;

            Enabled = topItem != null && UIHierarchyHelper.HasExpandedChildren(topItem);
        }

        /// <summary>
        /// Called to execute the command.
        /// </summary>
        protected override void OnExecute()
        {
            UIHierarchyHelper.CollapseRecursively(TopUIHierarchyItem);
        }

        #endregion BaseCommand Methods

        #region Private Properties

        /// <summary>
        /// Gets the top level (solution) UI hierarchy item.
        /// </summary>
        private UIHierarchyItem TopUIHierarchyItem
        {
            get { return UIHierarchyHelper.GetTopUIHierarchyItem(Package); }
        }

        #endregion Private Properties
    }
}