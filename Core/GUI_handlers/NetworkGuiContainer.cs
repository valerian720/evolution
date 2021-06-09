using evolution.Core.Util;
using Godot;

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

        public void _on_RunPauseButton_pressed()
        {
            StaticWorldManagerDispenser.GetWorldManager(this).Regenerate();
        }
    }
}
