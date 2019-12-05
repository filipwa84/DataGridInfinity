# DataGrid Infinity Bug

The DataGrid sometimes goes into an infinity loop. What triggers it is somewhat random and seems to depend on the screen resolution, the DPI settings and the width of the given DataGrid rows.

In this example - and on my computer - the application just hangs as soon as it starts if the DataGrid is in a StackPanel. However, putting it inside a Grid works. Testing the same code on a second computer with higher resolution and a DPI setting of 150, it crashes in both senarios.

Opening the Task Manager while it is haning one can see that there is a core is consistently running at 100%.

Importing the DataGrid source code into the project and hitting pause while it is haning, the code keeps coming back to DataGridRow.cs line 1967: ```element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity))```.
