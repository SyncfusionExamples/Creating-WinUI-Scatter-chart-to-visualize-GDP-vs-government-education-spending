# Visualizing GDP and Government Education Spending with Syncfusion WinUI Charts

This example showcases how to build an interactive Scatter Chart visualization using Syncfusion WinUI controls to explore the relationship between a country’s GDP spent on education and the share of government spending allocated to education.
By integrating real-time filtering through a year-based slider, the chart enables users to examine trends across regions and time, helping uncover patterns, priorities, and disparities in education investment.

## Key Features

**1. Interactive Scatter Chart:**

Plots GDP vs. government education spending for each country.
Highlights clusters, outliers, and regional trends.
Supports multiple series for regions like Asia, Europe, Africa, etc.

**2. Year-Based Filtering:**

A Syncfusion WinUI Slider allows users to select a year (2000–2024).
Chart updates dynamically to reflect selected year’s data.

**3. Custom Styling:**

Styled axes with percentage labels and grid lines.
Tooltip shows country name, GDP share, and government spending share.
Legend with region-based color coding and icons.

## Syncfusion Controls Used

[SfCartesianChart](https://help.syncfusion.com/winui/cartesian-charts/getting-started)

Displays scatter points for each country.
X-axis: % of GDP spent on education.
Y-axis: % of government budget allocated to education.
Legend & Tooltip
Legend maps colors to regions.
Tooltip provides detailed data on hover.

[SfSlider](https://help.syncfusion.com/winui/slider/getting-started)

Enables year selection with two-way data binding.
Enhances interactivity and user control.

## Use Cases

**1. Policy Analysis:** Compare education priorities across countries.

**2. Economic Research:** Study correlations between GDP and education investment.

**3. Education Planning:** Identify regions needing more support.

**4. Data Journalism:** Tell compelling stories with visual data.

## Output

![Scatter_series_blog_demo](https://github.com/user-attachments/assets/f381bb03-1bc4-4c62-a3fd-1c2f34f5fc58)

## Troubleshooting

**Path too long exception**

If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

For a step-by-step procedure, refer to the [GDP and Government Education Spending]().
