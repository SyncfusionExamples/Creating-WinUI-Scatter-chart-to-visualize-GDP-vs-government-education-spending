using EducationSpendings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EducationSpendings
{
    public class EducationExpenditure : INotifyPropertyChanged
    {
        private int selectedYear;
        private double xAxisMax;
        private double yAxisMax;
        private readonly List<CountryEducationModel> completeData = new();

        public Dictionary<string, ObservableCollection<CountryEducationModel>> RegionData { get; } = new()
        {
            { "Asia", new ObservableCollection<CountryEducationModel>() },
            { "Europe", new ObservableCollection<CountryEducationModel>() },
            { "Africa", new ObservableCollection<CountryEducationModel>() },
            { "NorthAmerica", new ObservableCollection<CountryEducationModel>() },
            { "SouthAmerica", new ObservableCollection<CountryEducationModel>() },
            { "Oceania", new ObservableCollection<CountryEducationModel>() }
        };

        public ObservableCollection<CountryEducationModel> AsiaData => RegionData["Asia"];
        public ObservableCollection<CountryEducationModel> EuropeData => RegionData["Europe"];
        public ObservableCollection<CountryEducationModel> AfricaData => RegionData["Africa"];
        public ObservableCollection<CountryEducationModel> NorthAmericaData => RegionData["NorthAmerica"];
        public ObservableCollection<CountryEducationModel> SouthAmericaData => RegionData["SouthAmerica"];
        public ObservableCollection<CountryEducationModel> OceaniaData => RegionData["Oceania"];

        public int SelectedYear
        {
            get => selectedYear;
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    OnPropertyChanged(nameof(SelectedYear));
                    LoadDataForYear(selectedYear);
                }
            }
        }

        public double XAxisMax
        {
            get => xAxisMax;
            set
            {
                if (xAxisMax != value)
                {
                    xAxisMax = value;
                    OnPropertyChanged(nameof(XAxisMax));
                }
            }
        }

        public double YAxisMax
        {
            get => yAxisMax;
            set
            {
                if (yAxisMax != value)
                {
                    yAxisMax = value;
                    OnPropertyChanged(nameof(YAxisMax));
                }
            }
        }

        public EducationExpenditure()
        {
            LoadAllData();
            SelectedYear = 2000;
        }

        private void LoadAllData()
        {
            try
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                using var stream = assembly.GetManifestResourceStream("EducationSpendings.Assets.education_spendings.csv");
                if (stream == null) return;

                using var reader = new StreamReader(stream);
                reader.ReadLine(); // Skip header

                while (reader.ReadLine() is string line)
                {
                    var parts = line.Split(',').Select(p => p.Trim()).ToArray();
                    if (parts.Length >= 5 &&
                        int.TryParse(parts[2], out int year) &&
                        double.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out double gdp) &&
                        double.TryParse(parts[4], NumberStyles.Any, CultureInfo.InvariantCulture, out double mappingValue))
                    {
                        completeData.Add(new CountryEducationModel
                        {
                            Country = parts[0],
                            Region = parts[1],
                            Year = year,
                            GDPSpent = gdp,
                            GovtSpent = mappingValue
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading CSV: {ex.Message}");
            }
        }

        private void LoadDataForYear(int year)
        {
            var filtered = completeData.Where(d => d.Year == year).ToList();
            if (filtered.Any())
            {
                XAxisMax = filtered.Max(d => d.GDPSpent) + 1;
                YAxisMax = filtered.Max(d => d.GovtSpent) + 1;
            }

            foreach (var region in RegionData.Keys)
                RegionData[region].Clear();

            foreach (var item in filtered)
            {

                if (!string.IsNullOrEmpty(item.Region) && RegionData.TryGetValue(item.Region, out var regionCollection))
                {
                    regionCollection.Add(item);
                }

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
