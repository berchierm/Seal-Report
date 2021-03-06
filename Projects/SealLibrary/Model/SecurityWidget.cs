﻿//
// Copyright (c) Seal Report (sealreport@gmail.com), http://www.sealreport.org.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. http://www.apache.org/licenses/LICENSE-2.0..
//
using DynamicTypeDescriptor;
using Seal.Forms;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Seal.Model
{
    /// <summary>
    /// A SecurityWidget defines the security applied to a widget for the Dashboard Manager
    /// </summary>
    public class SecurityWidget : RootEditor
    {
        #region Editor
        protected override void UpdateEditorAttributes()
        {
            if (_dctd != null)
            {
                //Disable all properties
                foreach (var property in Properties) property.SetIsBrowsable(false);
                //Then enable
                GetProperty("ReportName").SetIsBrowsable(true);
                GetProperty("Tag").SetIsBrowsable(true);
                GetProperty("Name").SetIsBrowsable(true);
                GetProperty("Right").SetIsBrowsable(true);

                TypeDescriptor.Refresh(this);
            }
            }
        #endregion

        /// <summary>
        /// The name of the report containing the widget (optional)
        /// </summary>
        [Category("Definition"), DisplayName("\tReport Name"), Description("The name of the report containing the widget (optional)."), Id(1, 1)]
        public string ReportName { get; set; }

        /// <summary>
        /// The name of the security tag (optional, must match with the tags defined in the widget)
        /// </summary>
        [Category("Definition"), DisplayName("Security Tag"), Description("The name of the security tag (optional, must match with the tags defined in the widget)."), Id(2, 1)]
        public string Tag { get; set; }

        /// <summary>
        /// The name of the widget (optional, must match with name defined in the widget)
        /// </summary>
        [Category("Definition"), DisplayName("Name"), Description("The name of the widget (optional, must match with name defined in the widget)."), Id(3, 1)]
        public string Name { get; set; }

        /// <summary>
        /// The right applied for the widget having this security tag or this name
        /// </summary>
        [Category("Rights"), DisplayName("Widget Right"), Description("The right applied for the widget having this security tag or this name."), Id(1, 2)]
        [TypeConverter(typeof(NamedEnumConverter))]
        [DefaultValue(EditorRight.NoSelection)]
        public EditorRight Right { get; set; } = EditorRight.NoSelection;

        /// <summary>
        /// Display name
        /// </summary>
        [XmlIgnore]
        public string DisplayName
        {
            get
            {
                var result = "";
                if (!string.IsNullOrEmpty(ReportName)) result = "Report Name:" + ReportName;
                if (!string.IsNullOrEmpty(Name)) result += (result != "" ? "; " : "") + "Widget Name:" + Name;
                if (!string.IsNullOrEmpty(Tag)) result += (result != "" ? "; " : "") + "Tag:" + Tag;
                return result;
            }
        }
    }
}
