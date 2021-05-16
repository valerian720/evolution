using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.GUI_handlers
{
    class NetworkGuiContainer : MarginContainer
    {
        NetManager manager;

        public override void _Ready()
        {
            this.Visible = false;
        }

        public void _on_VisibilityButton_pressed()
        {
            this.Visible = !this.Visible;
        }
    }
}
