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
            // ����� / ����������� ������ ���������
        }

        public void _on_OneStepButton_pressed()
        {
            // ��������� ���������� �� 1 ���� ������
        }

        public void _on_PopulationAmountInput_text_entered(String newText)
        {
            // ���� ��������� ������� ���������
        }
    }
}
