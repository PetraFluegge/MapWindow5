﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class MenuItem: IMenuItem
    {
        private const int ICON_SIZE = 24;
        protected BarItem _item;

        internal MenuItem(BarItem item)
        {
            _item = item;
            if (item == null)
            {
                throw new NullReferenceException("Bar item reference is null.");
            }
        }
        
        public string Text
        {
            get { return _item.Text; }
            set { _item.Text = value; }
        }

        public IMenuIcon Picture
        {
            get { return new MenuIcon(_item.Image.GetImage()); }
            set
            {
                _item.Image = new ImageExt(value.Image);
                _item.ImageSize = new Size(ICON_SIZE, ICON_SIZE);
            }
        }

        public string Category
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool Checked
        {
            get { return _item.Checked; }
            set { _item.Checked = value; }
        }

        public string Tooltip
        {
            get { return _item.Tooltip; }
            set { _item.Tooltip = value; }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool Displayed
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool Enabled
        {
            get { return _item.Enabled; }
            set { _item.Enabled = value; }
        }

        public string Name
        {
            get { return _item.ID; }
            set { _item.ID = value; }
        }

        public bool Visible
        {
            get { return _item.Visible; }
            set { _item.Visible = value; }
        }

        public object Tag
        {
            get { return _item.Tag; }
            set { _item.Tag = value; }
        }

        public event EventHandler Click
        {
            add
            {
                _item.Click += (sender, args) => value.Invoke(this, args);
            }
            remove
            {
                _item.Click -= value;       // TODO: remove handler
            }
        }

        public object GetInternalObject()
        {
            return _item;
        }
    }
}
