using OxyPlot.Series;
using OxyPlot;
using System.Threading.Tasks;
using OxyPlot.Axes;
using RLC_Filter.RLCFilter;

namespace RLC_Filter.Pages
{
    internal class MainViewModel
    {
        public PlotModel FreqModel { get; private set; }
        public PlotModel PhaseModel { get; private set; }

        private Filter _filter;

        public Filter Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                Task.Run(RefreshPlot);
            }
        }

        private double _startX = 1;
        private double _endX = 5000;
        private int _numberOfPoints = 10000;

        public MainViewModel()
        {
            FreqModel = new PlotModel { Title = "Frequency Response" };
            PhaseModel = new PlotModel { Title = "Phase Shift" };

            LogarithmicAxis yAxisFreq = new LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = _startX,
                Maximum = _endX
            };

            LogarithmicAxis yAxisPhase = new LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = _startX,
                Maximum = _endX
            };

            PhaseModel.Axes.Add(yAxisPhase);
            FreqModel.Axes.Add(yAxisFreq);
        }

        public void ChangeAxes(double startX, double endX, int numberOfPoints)
        {
            if (_startX > _endX)
                return;

            if (numberOfPoints <= 0)
                return;

            _startX = startX;
            _endX = endX;
            _numberOfPoints = numberOfPoints;
            Task.Run(RefreshPlot);
        }

        private Task RefreshPlot()
        {
            FreqModel.Series.Clear();
            PhaseModel.Series.Clear();
            
            FreqModel.Series.Add(new FunctionSeries(value => Filter.FrequencyResponseInDb(value), _startX, _endX,
                (_endX - _startX) / _numberOfPoints, Filter.Name));
            PhaseModel.Series.Add(new FunctionSeries(value => Filter.PhaseShift(value), _startX, _endX,
                (_endX - _startX) / _numberOfPoints, Filter.Name));
            
            FreqModel.Axes.Clear();
            PhaseModel.Axes.Clear();
            
            LogarithmicAxis yAxisFreq = new LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = _startX,
                Maximum = _endX
            };

            LogarithmicAxis yAxisPhase = new LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = _startX,
                Maximum = _endX
            };
            
            FreqModel.Axes.Add(yAxisFreq);
            PhaseModel.Axes.Add(yAxisPhase);
            FreqModel.InvalidatePlot(true);
            PhaseModel.InvalidatePlot(true);
            
            return Task.CompletedTask;
        }
    }
}