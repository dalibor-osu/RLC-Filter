using System;
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
        private double _endX = 1000;
        private int _numberOfPoints = 10000;

        public MainViewModel()
        {
            FreqModel = new PlotModel { Title = "Frequency Response" };
            PhaseModel = new PlotModel { Title = "Phase Shift" };

            ResetPlotAxes();
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
            
            FreqModel.Series.Add(new FunctionSeries(value => Filter.FrequencyResponseInDb(value * 2 * Math.PI), _startX, _endX,
                (_endX - _startX) / _numberOfPoints, Filter.Name));
            PhaseModel.Series.Add(new FunctionSeries(value => Filter.PhaseShift(value * 2 * Math.PI), _startX, _endX,
                (_endX - _startX) / _numberOfPoints, Filter.Name));
            
            ResetPlotAxes();
            
            FreqModel.InvalidatePlot(true);
            PhaseModel.InvalidatePlot(true);
            
            return Task.CompletedTask;
        }

        private void ResetPlotAxes()
        {
            FreqModel.Axes.Clear();
            PhaseModel.Axes.Clear();

            FreqModel.Axes.Add(GetXAxis());
            FreqModel.Axes.Add(GetYAxis("Magnitude"));
            PhaseModel.Axes.Add(GetXAxis());
            PhaseModel.Axes.Add(GetYAxis("Phase"));
        }

        private LogarithmicAxis GetXAxis()
        {
            return new LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = _startX,
                Maximum = _endX,
                Title = "Frequency [Hz]"
            };
        }
        
        private LinearAxis GetYAxis(string title)
        {
            return new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = title
            };
        }
    }
}