﻿namespace Squalr.Source.ProjectExplorer.ProjectItems
{
    using Squalr.Engine.Projects;
    using Squalr.Source.Controls;
    using Squalr.Source.Editors.ScriptEditor;
    using Squalr.Source.Utils.TypeConverters;
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;

    /// <summary>
    /// Decorates the base project item class with annotations for use in the view.
    /// </summary>
    internal class ScriptItemView : ProjectItemView
    {
        public ScriptItemView(ScriptItem scriptItem)
        {
            this.ScriptItem = scriptItem;
        }

        [Browsable(false)]
        private ScriptItem ScriptItem { get; set; }

        /// <summary>
        /// Gets or sets the raw script text.
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        [TypeConverter(typeof(ScriptConverter))]
        [Editor(typeof(ScriptEditorModel), typeof(UITypeEditor))]
        [SortedCategory(SortedCategory.CategoryType.Common), DisplayName("Script"), Description("C# script to interface with engine")]
        public String Script
        {
            get
            {
                return this.ScriptItem.Script;
            }

            set
            {
                this.ScriptItem.Script = value;
            }
        }
    }
    //// End class
}
//// End namespace