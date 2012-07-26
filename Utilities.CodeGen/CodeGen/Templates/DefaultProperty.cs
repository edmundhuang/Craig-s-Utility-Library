﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

#region Usings
using Utilities.CodeGen.Interfaces;
using Utilities.CodeGen.Templates.BaseClasses;
using Utilities.CodeGen.Templates.Enums;
using Utilities.CodeGen.Templates.Interfaces;
#endregion

namespace Utilities.CodeGen.Templates
{
    /// <summary>
    /// Default property
    /// </summary>
    public class DefaultProperty : ObjectBase, IProperty
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Parser">Parser</param>
        public DefaultProperty(IParser Parser)
            : base(Parser)
        {
        }

        #endregion

        #region Functions

        /// <summary>
        /// Sets up the template
        /// </summary>
        protected override void SetupTemplate()
        {
            Template = new DefaultTemplate(@"@AccessModifier @ExtraModifiers @PropertyType @PropertyName{ get; set; }");
        }

        /// <summary>
        /// Sets up the input
        /// </summary>
        protected override void SetupInput()
        {
            Input.Values.Add("AccessModifier", AccessModifier.ToString().ToLower());
            if (Modifier == Modifiers.None)
                Input.Values.Add("ExtraModifiers", "");
            else
                Input.Values.Add("ExtraModifiers", Modifier.ToString().ToLower());
            Input.Values.Add("PropertyType", PropertyType);
            Input.Values.Add("PropertyName", Name);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Access modifier
        /// </summary>
        public virtual AccessModifier AccessModifier { get; set; }

        /// <summary>
        /// Property modifier
        /// </summary>
        public virtual Modifiers Modifier { get; set; }

        /// <summary>
        /// Property type
        /// </summary>
        public virtual string PropertyType { get; set; }

        /// <summary>
        /// Property name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Code of the get function
        /// </summary>
        public virtual string GetFunction { get; set; }

        /// <summary>
        /// Code of the set function
        /// </summary>
        public virtual string SetFunction { get; set; }

        #endregion
    }
}