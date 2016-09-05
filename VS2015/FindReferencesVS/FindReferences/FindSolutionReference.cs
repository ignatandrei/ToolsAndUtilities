//------------------------------------------------------------------------------
// <copyright file="FindSolutionReference.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using VSLangProj;
using VS_Nuget_Extensions_DAL;

namespace FindReferences
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class FindSolutionReference
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("ed960ef0-c101-4b56-8496-3af5b975ade5");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindSolutionReference"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private FindSolutionReference(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService =
                this.ServiceProvider.GetService(typeof (IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static FindSolutionReference Instance { get; private set; }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get { return this.package; }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new FindSolutionReference(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            string message = string.Format(CultureInfo.CurrentCulture, "Saving references to ",
                this.GetType().FullName);
            string title = "FindSolutionReference";
            IVsUIShell uiShell = (IVsUIShell) ServiceProvider.GetService(typeof (SVsUIShell));
            Guid clsid = Guid.Empty;
            var dte = ServiceProvider.GetService(typeof (DTE)) as DTE;
            var createdDate = DateTime.UtcNow;
            var tasks = new List<Task>();
            var id = Guid.NewGuid().ToString();
            //foreach (var addIn in dte.AddIns)
            //{
            //    var a = addIn as AddIn;
            //    if (a == null)
            //        continue;

            //    //this is a package                    
            //    var pa = new PackageAdd();
            //    pa.ProjectName = "";
            //    pa.IdentifierPackage = a.ProgID;
            //    pa.VersionPackage = a.Guid;
            //    pa.NamePackage = a.Name;
            //    pa.TypePackage = "extension";
            //    pa.PCName = Environment.MachineName;
            //    pa.UserPCName = Environment.UserName;
            //    pa.CreatedDate = createdDate;
            //    pa.VS = dte.Version;
            //    var res = SavePackageAdd(pa);
            //    tasks.Add(res);
            //}
            var sb = new StringBuilder();
            var saveFile = dte.Solution.FullName +".txt";

            foreach (var project in dte.Solution.Projects)
            {
                var p = project as Project;
                if (p == null)
                {
                    continue;
                }

                var vsproject = p.Object as VSLangProj.VSProject;
                if (vsproject == null)
                    continue;

                string nameProject = p.Name;
                foreach (var reference in vsproject.References)
                {
                    var r = reference as Reference;
                    if (r == null)
                        continue;

                    var pathRef = r.Path;

                    //this is a package                    
                    var pa = new PackageAdd();
                  
                    pa.ProjectName = p.Name;
                    pa.IdentifierPackage = r.Identity;
                    pa.VersionPackage = r.Version;
                    pa.NamePackage = r.Name;

                  



                    if (r.SourceProject != null)
                    {
                        
                        pa.NamePackage = r.SourceProject.Name;
                    }
                    sb.AppendLine(pa.ToString());
                }
            }
            File.WriteAllText(saveFile,sb.ToString());
            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            System.Diagnostics.Process.Start(saveFile);
        }
    }
}