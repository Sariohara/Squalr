﻿namespace Squalr.Source.ProjectExplorer.ProjectItems
{
    using Squalr.Engine.DataTypes;
    using Squalr.Engine.Projects;
    using Squalr.Source.Controls;
    using Squalr.Source.Utils.TypeConverters;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Decorates the base project item class with annotations for use in the view.
    /// </summary>
    internal class JavaItemView : ProjectItemView
    {
        public JavaItemView(JavaItem javaItem)
        {
            this.JavaItem = javaItem;
        }

        [Browsable(false)]
        private JavaItem JavaItem { get; set; }

        /// <summary>
        /// Gets or sets the data type of the value at this address.
        /// </summary>
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [TypeConverter(typeof(DataTypeConverter))]
        [SortedCategory(SortedCategory.CategoryType.Advanced), DisplayName("Data Type"), Description("Data type of the calculated address")]
        public DataType DataType
        {
            get
            {
                return this.JavaItem.DataType;
            }

            set
            {
                this.JavaItem.DataType = value;
            }
        }

        /// <summary>
        /// Gets or sets the value at this address.
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(DynamicConverter))]
        [SortedCategory(SortedCategory.CategoryType.Common), DisplayName("Value"), Description("Value at the calculated address")]
        public Object AddressValue
        {
            get
            {
                return this.JavaItem.AddressValue;
            }

            set
            {
                this.JavaItem.AddressValue = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the value at this address should be displayed as hex.
        /// </summary>
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [SortedCategory(SortedCategory.CategoryType.Advanced), DisplayName("Value as Hex"), Description("Whether the value is displayed as hexedecimal")]
        public Boolean IsValueHex
        {
            get
            {
                return this.JavaItem.IsValueHex;
            }

            set
            {
                this.JavaItem.IsValueHex = value;
            }
        }

        /// <summary>
        /// Gets the effective address after tracing all pointer offsets.
        /// </summary>
        [ReadOnly(true)]
        [TypeConverter(typeof(AddressConverter))]
        [SortedCategory(SortedCategory.CategoryType.Common), DisplayName("Calculated Address"), Description("The final computed address of this variable")]
        public UInt64 CalculatedAddress
        {
            get
            {
                return this.JavaItem.CalculatedAddress;
            }
        }
    }
    //// End class
}
//// End namespace