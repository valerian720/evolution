using evolution.Core.Net;
using evolution.Core.Net.NetTopologyExecutions;
using evolution.Core.Util;
using Godot;
using System;

namespace evolution.Core.GUI_handlers
{
    class NetworkGuiContainer : MarginContainer
    {

        WorldManager manager;
        public override void _Ready()
        {
            manager = StaticWorldManagerDispenser.GetWorldManager(this);

            this.Visible = false;
        }

        public void _on_VisibilityButton_pressed()
        {
            this.Visible = !this.Visible;
        }

        static NetTopology[] netTopologies = new NetTopology[] { new AllToAllNetTopology(), new StarNetTopology(), new RingNetTopology() };

        public void _on_OptionTopology_item_selected(int index)
        {
            manager.SetNetTopology(netTopologies[index]);

            GD.Print(netTopologies[index].ToString());
        }

        

        //LineEdit PopulationAmount;
        //LineEdit CromosomeAmount;
        //LineEdit CromosomeLength;
        //LineEdit MutationAmount;
        //LineEdit MutationRate;
        //LineEdit SelectionCount;
        //LineEdit IterationCount; 
        //LineEdit SimulationRate; 
        // //
        //TextEdit BestSpeciesGenome;
        ////
        //Label ProcessDisplay;
        ////
        ////
        //private Timer geneticIterationTimer = new Timer();
        //private bool canIterate = true;
        ////
        //private bool isRunnig = false;
        //// инициализация класса
        //public NetworkGuiContainer()
        //{
        //    geneticIterationTimer.OneShot = true;
        //    geneticIterationTimer.Connect("timeout", this, nameof(OnCalculatePathTimer));
        //}

        //// инициализация компонента
        //public override void _Ready()
        //{
        //    AddChild(geneticIterationTimer);
        //    //
        //    manager = StaticWorldManagerDispenser.GetWorldManager(this);
        //    this.Visible = false;
        //    //
        //    PopulationAmount = ((LineEdit) GetTree().GetNodesInGroup("PopulationAmount")[0]);
        //    CromosomeAmount = ((LineEdit) GetTree().GetNodesInGroup("CromosomeAmount")[0]);
        //    CromosomeLength = ((LineEdit) GetTree().GetNodesInGroup("CromosomeLength")[0]);
        //    MutationAmount = ((LineEdit) GetTree().GetNodesInGroup("MutationAmount")[0]);
        //    MutationRate = ((LineEdit) GetTree().GetNodesInGroup("MutationRate")[0]);
        //    SelectionCount = ((LineEdit) GetTree().GetNodesInGroup("SelectionCount")[0]);
        //    IterationCount = ((LineEdit) GetTree().GetNodesInGroup("IterationCount")[0]);
        //    //
        //    SimulationRate = ((LineEdit) GetTree().GetNodesInGroup("SimulationRate")[0]);
        //    //
        //    BestSpeciesGenome = ((TextEdit) GetTree().GetNodesInGroup("BestSpeciesGenome")[0]);
        //    //
        //    ProcessDisplay = ((Label) GetTree().GetNodesInGroup("ProcessDisplay")[0]);
        //    //
        //    UpdateValuesInInput();
        //}

        //private void UpdateValuesInInput()
        //{
        //    PopulationAmount.Text = this.manager.PopulationAmount.ToString();
        //    CromosomeAmount.Text = this.manager.CromosomeAmount.ToString();
        //    CromosomeLength.Text = this.manager.CromosomeLength.ToString();
        //    MutationAmount.Text = this.manager.MutationAmount.ToString();
        //    MutationRate.Text = this.manager.MutationRateOutOf100.ToString();
        //    SelectionCount.Text = this.manager.SelectionCount.ToString();
        //    IterationCount.Text = this.manager.IterationCount.ToString();
        //    //
        //    SimulationRate.Text = calculatePerSecond.ToString();
        //    //
        //    BestSpeciesGenome.Text = "";
        //    //
        //    UpdateProcessDisplay();
        //}

        //// срабатывание каждый фрем
        //public override void _PhysicsProcess(float delta)
        //{
        //    // bruh
        //    // таймер работает в ui
        //    TryProgressPopulationWithLimitedRate();
        //}

        //public void _on_VisibilityButton_pressed()
        //{
        //    this.Visible = !this.Visible;
        //}

        //public void _on_RunPauseButton_pressed()
        //{
        //    isRunnig = !isRunnig;
        //}

        //public void _on_OneStepButton_pressed()
        //{
        //    BestSpeciesGenome.Text = manager.ProgressPopulation();
        //    UpdateProcessDisplay();
        //}

        //public void _on_Regenerate_pressed()
        //{
        //    manager.Regenerate();
        //    UpdateValuesInInput();
        //}

        //private void UpdateProcessDisplay()
        //{
        //    ProcessDisplay.Text = $"simulation mode {manager.GetCurrentIteration()}/{manager.IterationCount}";
        //}
        //////////////////////////////////////////////////////
        //// таймер
        //float calculatePerSecond = 100f;
        //float CalculateDelay => 1f / calculatePerSecond;

        //public void TryProgressPopulationWithLimitedRate()
        //{
        //    if (canIterate && isRunnig)
        //    {
        //        try
        //        {
        //            _on_OneStepButton_pressed();

        //            canIterate = false;
        //            geneticIterationTimer.Start(CalculateDelay);
        //        }
        //        catch (Exception e)
        //        {
        //            GD.PrintErr(e);
        //        }
        //    }
        //}
        //private void OnCalculatePathTimer()
        //{
        //    canIterate = true;
        //}
        //////////////////////////////////////////////////////
        //private bool TrueFunc(int num) => true;

        //private int ProcessIntInputValue(String inputStr, LineEdit field, int currentValue, Func<int, bool> additionalTest)
        //{
        //    int tmpVal = currentValue;
        //    if (int.TryParse(inputStr, out int val))
        //    {
        //        if (val > 0 && additionalTest(val))
        //        {
        //            tmpVal = val;
        //        }
        //        else
        //        {
        //            field.Text = tmpVal.ToString();
        //        }
        //    }
        //    else
        //    {
        //        field.Text = currentValue.ToString();
        //    }
        //    return tmpVal;
        //}
        //private void SetFloatInternalValue(String inputStr, LineEdit field, ref float targetField)
        //{
        //    if (float.TryParse(inputStr, out float val))
        //    {
        //        if (val > 0)
        //        {
        //            targetField = val;
        //        }
        //        else
        //        {
        //            field.Text = targetField.ToString();
        //        }
        //    }
        //    else
        //    {
        //        field.Text = targetField.ToString();
        //    }
        //}
        ///// 
        //private bool CheckLower100(int num) => num<=100;
        //private bool CheckLowerThanPopulation(int num) => num<this.manager.PopulationAmount;


        //public void _on_SimulationRate_text_entered(String newText) => SetFloatInternalValue(newText, SimulationRate, ref calculatePerSecond);

        //public void _on_PopulationAmountInput_text_entered(String newText) => this.manager.PopulationAmount = ProcessIntInputValue(newText, PopulationAmount, this.manager.PopulationAmount, TrueFunc);
        //public void _on_CromosomeAmount_text_entered(String newText) => this.manager.CromosomeAmount = ProcessIntInputValue(newText, CromosomeAmount, this.manager.CromosomeAmount, TrueFunc);
        //public void _on_CromosomeLength_text_entered(String newText) => this.manager.CromosomeLength = ProcessIntInputValue(newText, CromosomeLength, this.manager.CromosomeLength, TrueFunc);
        //public void _on_MutationAmount_text_entered(String newText) => this.manager.MutationAmount = ProcessIntInputValue(newText, MutationAmount, this.manager.MutationAmount, TrueFunc);
        //public void _on_MutationRate_text_entered(String newText) => this.manager.MutationRateOutOf100 = ProcessIntInputValue(newText, MutationRate, this.manager.MutationRateOutOf100, CheckLower100);
        //public void _on_SelectionCount_text_entered(String newText) => this.manager.SelectionCount = ProcessIntInputValue(newText, SelectionCount, this.manager.SelectionCount, CheckLowerThanPopulation);
        //public void _on_IterationCount_text_entered(String newText) => this.manager.IterationCount = ProcessIntInputValue(newText, IterationCount, this.manager.IterationCount, TrueFunc);

    }
}
