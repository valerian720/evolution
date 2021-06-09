using evolution.Core.Util;
using Godot;

namespace evolution.Core.GUI_handlers
{
    class NetworkGuiContainer : MarginContainer
    {
        WorldManager manager;

        LineEdit PopulationAmount;
        LineEdit CromosomeAmount;
        LineEdit CromosomeLength;
        LineEdit MutationAmount;
        LineEdit MutationRate;
        LineEdit SelectionCount;
        LineEdit IterationCount;

        TextEdit BestSpeciesGenome;

        public override void _Ready()
        {
            manager = StaticWorldManagerDispenser.GetWorldManager(this);
            this.Visible = false;
            //
            PopulationAmount = ((LineEdit) GetTree().GetNodesInGroup("PopulationAmount")[0]);
            CromosomeAmount = ((LineEdit) GetTree().GetNodesInGroup("CromosomeAmount")[0]);
            CromosomeLength = ((LineEdit) GetTree().GetNodesInGroup("CromosomeLength")[0]);
            MutationAmount = ((LineEdit) GetTree().GetNodesInGroup("MutationAmount")[0]);
            MutationRate = ((LineEdit) GetTree().GetNodesInGroup("MutationRate")[0]);
            SelectionCount = ((LineEdit) GetTree().GetNodesInGroup("SelectionCount")[0]);
            IterationCount = ((LineEdit) GetTree().GetNodesInGroup("IterationCount")[0]);

            BestSpeciesGenome = ((TextEdit) GetTree().GetNodesInGroup("BestSpeciesGenome")[0]);
            //
            UpdateValuesInInput();
        }

        private void UpdateValuesInInput()
        {
            PopulationAmount.Text = this.manager.PopulationAmount.ToString();
            CromosomeAmount.Text = this.manager.CromosomeAmount.ToString();
            CromosomeLength.Text = this.manager.CromosomeLength.ToString();
            MutationAmount.Text = this.manager.MutationAmount.ToString();
            MutationRate.Text = this.manager.MutationRateOutOf100.ToString();
            SelectionCount.Text = this.manager.SelectionCount.ToString();
            IterationCount.Text = this.manager.IterationCount.ToString();
            //
            BestSpeciesGenome.Text = "";
        }

        public void _on_VisibilityButton_pressed()
        {
            this.Visible = !this.Visible;
        }

        public void _on_RunPauseButton_pressed()
        {
            manager.Regenerate();
        }

        public void _on_OneStepButton_pressed()
        {
            BestSpeciesGenome.Text = manager.ProgressPopulation();
        }
    }
}
