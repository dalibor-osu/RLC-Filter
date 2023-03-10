using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Axes;
using RLC_Filter.RLCFilter;

namespace RLC_Filter.Pages
{
    internal class MainViewModel
    {
        public PlotModel MyModel { get; private set; }
        private Filter _filter;
        public Filter Filter
        {
            get => _filter;
            set
            {
                _filter = value; 
                RefreshPlot();
            }
        }

        private double _startX = 1;
        private double _endX = 5000;
        private int _numberOfPoints = 10000;
        public MainViewModel()
        {
            MyModel = new PlotModel { Title = "Frequency Response" };
            
            LogarithmicAxis yAxis = new LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = _startX,
                Maximum = _endX
            };
            MyModel.Axes.Add(yAxis);
        }

        public void ChangeAxes(double startX, double endX, int numberOfPoints)
        {
            _startX = startX;
            _endX = endX;
            _numberOfPoints = numberOfPoints;
            RefreshPlot();
        }

        private void RefreshPlot()
        {
            MyModel.Series.Clear();
            MyModel.Series.Add(new FunctionSeries(value => Filter.FrequencyResponseInDb(value), _startX, _endX, (_endX - _startX) / _numberOfPoints, "Band Pass"));
            MyModel.Axes.Clear();
            MyModel.Axes.Add(new LogarithmicAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = _startX,
                Maximum = _endX
            });
            MyModel.InvalidatePlot(true);
        }
    }
}
