using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evolution.Core.GUI_handlers
{
    class GeneticGuiContainer: MarginContainer
    {
        WorldManager manager;
        public override void _Ready()
        {
            this.Visible = false;
            manager = (WorldManager) GetParent().GetParent().GetParent().GetParent().GetChild(0);
            GD.Print(manager);
        }

        public void _on_VisibilityButton_pressed()
        {
            this.Visible = !this.Visible;
            manager.Regenerate();
        }

        public void _on_RunPauseButton_pressed()
        {
            // пауза / продолжение работы симул€ции
        }

        public void _on_OneStepButton_pressed()
        {
            // симул€цию продвинуть на 1 цикл вперед
        }

        public void _on_PopulationAmountInput_text_entered(String newText)
        {
            // ввод параметра размера попул€ции
        }
    }
}
