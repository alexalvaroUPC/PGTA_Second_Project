lo# ASTERIX CAT048 Decoder

This project implements an ASTERIX CAT048 decoder, designed to interpret and process ASTERIX (All Purpose Structured Eurocontrol Surveillance Information Exchange) Category 048 messages.

## Overview

ASTERIX CAT048 is a standardized format used in air traffic management systems for exchanging surveillance data. 
This decoder is specifically tailored to handle Category 048 messages, which typically contain radar-derived information about aircraft positions and associated data.

## Features

- Decodes ASTERIX CAT048 messages
- Extracts relevant information from the decoded messages
- Provides a structured output of the decoded data

## Installation

To set up this project on your local machine, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/alexalvaroUPC/PGTA_Second_Project.git
   ```

2. Navigate to the project directory:
   ```bash
   cd PGTA_Second_Project
   ```

3. Install any required dependencies (if applicable)

## Installation as a standalone application

In order to install this application as a standalone version:
1. Download the setup file
	```bash
	Find it inside the DecoderASTERIX048 folder with file name: DecoderASTERIX048.msi or setup.exe
	```
2. Open the downloaded file
3. Follow the steps through the installation
4. The application can be executed under the name AST048Decoder

## Usage

Using the decoder is quite simple, the first step is to select the asterix binary file to be decoded. 
The application offers the possibility to display the processed data in a table. This is useful if checks must be ran, but will increase the waiting time for large files.
Once the file is decoded, the display shows the data analysis window, here (filters can be applied) you are able to:
```
	a. Export a CSV 
	b. Display the data to be used in a table
	c. Initialize the simulator using the (filtered) data
	d. Note that the option of resetting the data to the unfiltered version is always possible
```
If option c. is picked, the simulator will load with all the data (filters applied) in the ASTERIX file. This could take some time for larger files with not many filters selected.
	Inside the simulator one can use the buttons to run through time automatically or manually. Stepbacks are possible too.
	Using the (Re)Start button, simulations can be (re)started. The pause button freezes time, which can be unfrozen by clicking on the resume button.
	Step forward and back buttons perform the operations of moving ahead or backwards one second at a time.
	The simulation speed can be changed and accelerated up to 50 ticks per second; however, if the amount of data is big, the real speed will be lower.
	Placing the cursor on an aircraft will display its callsign, heading and (corrected) altitude.
Some interesting functionalities have been included:
```
	i. On the left side of the screen, a scroll bar allows to select a cut-off FL, together with the see over/under buttons one can choose which flight levels are visible in the simulator.
	ii. By typing a callsign in the textbox, the simulator will add (if found) the aircraft (remember to use CAPITAL letters) to the tracking list. Clicking on one of the tracked callsigns will delete it from the tracking list.
	iii. If the map is clicked a window will show querying you to add a new registry zone according to your desired dimensions in nautical miles; aircraft that go through this zone will be added to the tracking list. Right-clicking an existing zone will delete it.
```
What is the tracking list?
	This list is a log of all flights of interest to the user. Flights present in this list will have their routes traced on the map with the following colour scheme: black for manually entered callsigns, same colour as the registry zones for the ones detected by registry zones.
	The purpose of this is allowing you to track aircraft according to their callsign, or setting up interesting zones and keeping a log of aircraft that go through them (i.e placing a zone in front of the runway will help keep a log of landings/departures).
	In addition to being displayed on the map, the tracking list is saved by clicking the "Guardar instantánea" button. You will get queried for a file name, a PDF will be generated.
	The PDF contains:
 
```
	a. An image of the current situation in the map (includes aircraft, tracked routes, registry zones)
	b. The coordinates, callsign, heading, (corrected) FL of all aircraft present at the precise instant of saving the file
	c. A log of the first incursions logged for each registry zone: callsign, coordinates of incursion, geodesic height. Therefore, one could know easily with quite precision the aircraft heights at the runway threshold and other relevant data)
```
 
Besides the PDF, clicking the button will close the simulator and return you to the data analysis window. This time around the data you will see displayed on the table corresponds exclusively to those aircraft you have tracked manually or through incursion zones -if none are tracked, the data will be the full ASTERIX file.
	With this information you know can export your data with those flight records ou have found of interest, run the simulation again with only these flights; or reset the data and simulate all messages again. It is completely up to you!
	
The transformations to WGS84 geodesic coordinates are based on the ARTAS transformations [2] using the ellipsoid data provided at [2][3] and radar specifications given at [2].
		

## Contributing

Contributions to improve the ASTERIX CAT048 decoder are welcome. Please feel free to submit pull requests or open issues to discuss potential enhancements.

## Acknowledgments

This project was developed as part of the PGTA (Planificación y Gestión del Tráfico Aéreo) course.

For more information about ASTERIX and its applications in air traffic management, please refer to the official Eurocontrol documentation.

## Citations:
[1] https://github.com/alexalvaroUPC/PGTA_Second_Project
[2] https://www.atenea.upc.edu (PGTA course, coordinate transformations folder, SASSC-TRANSLIB-SRD-98-0154-D.pdf)(used also for semi-major axis, radar location (geodesic coordinates, terrain elevation and antenna height)
[3] https://en.wikipedia.org/wiki/World_Geodetic_System#WGS84 (used for semi-minor axis, excentricity)
