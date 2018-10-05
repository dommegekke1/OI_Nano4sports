#define _USE_MATH_DEFINES
#include <iostream>
#include <iomanip>
#include <stdexcept>
#include <string>
#include <string.h>
#include <fstream>



// The only file that needs to be included to use the Myo C++ SDK is myo.hpp.
#include <myo/myo.hpp>
#include "DataCollector.h"
#include "Communicator.h"
#include "StepCalculator.h"

constexpr auto Connected = true;
const char filename[] = "test.txt ";

int main(int argc, char** argv)
{
	// We catch any exceptions that might occur below -- see the catch statement for more details.
	try {
#pragma region Try to connect

		// First, we create a Hub with our application identifier. Be sure not to use the com.example namespace when
		// publishing your application. The Hub provides access to one or more Myos.
		myo::Hub hub("com.example.hello-myo");
		std::cout << "Attempting to find a Myo..." << std::endl;
	
		myo::Myo* myo = hub.waitForMyo(10000);
		if (!myo)
		{
			throw std::runtime_error("Unable to find a Myo!");
		}

		// We've found a Myo.
		std::cout << "Connected to a Myo armband!" << std::endl << std::endl;
#pragma endregion

		DataCollector collector;
		hub.addListener(&collector);

#pragma region Create file
		//file open
		std::ofstream valueFile;
		valueFile.open(filename);
		valueFile << "roll,pitch,yaw, gyro_x, gyro_y, gyro_z, accel_x, accel_y, accel_z, time\n";
#pragma endregion


		// starting com port
		// magic from mister Ryan
		Communicator COM = Communicator(4, CBR_115200);

		// add the Stepcalculator
		StepCalculator WaveDetector = StepCalculator(8, 10, 150);


		// initialise baterylevel and bluetoothRange for the collector 
		myo->requestBatteryLevel();
		myo->requestRssi();

		// vibrate once
		myo->vibrate(myo::Myo::vibrationShort);

		// turn on emg data transfer
		myo->setStreamEmg(myo->streamEmgEnabled);
			


		int display = 0;
		int relativeTime = 0;
		int steps = 0;

		while (1) {
			hub.run(1000 / 60); // time setting

			relativeTime = std::clock();

			//Get EMG DATA
			std::array<int8_t, 8> EMG_Data;
			collector.getEMG(&EMG_Data);

			// detection 
			WaveDetector.Calculate(collector.getGyroscope().z());
			if (WaveDetector.GetStep())
			{
				steps++;
			}



#pragma region Display output



			display++;
			if (display > 15)
			{
				display = 0;
				system("CLS");

				// header
				std::cout << "\n				Nano4Sports - Fontys OI\n\n";
					if (collector.getConnectionStatus()) { std::cout << "					Connected\n\n"; }
					else { std::cout << "					Disconnected \n\n"; }
				std::cout << "		Battery: "<< (int)collector.getBatteryLevel() << "		"
					<< "	Bluetooth Signal Strength: " << (int)collector.getBluetoothRange() <<"\n \n";

				// stepcalculator



				// Measurements 
				std::cout << "			Rotation_pitch		: " << collector.getRotation_pitch() << "\n"
					<< "			Rotation_roll		: " << collector.getRotation_roll() << "\n"
					<< "			Rotation_yaw		: " << collector.getRotation_yaw() << "\n"
					<< "			Gyroscope x		: " << collector.getGyroscope().x() << "\n"
					<< "			Gyroscope y		: " << collector.getGyroscope().y() << "\n"
					<< "			Gyroscope y		: " << collector.getGyroscope().z() << "\n"
					<< "			Accelerometer x		: " << collector.getAccelerometer().x() << "\n"
					<< "			Accelerometer y		: " << collector.getAccelerometer().y() << "\n"
					<< "			Accelerometer z		: " << collector.getAccelerometer().z() << "\n"
					<< "			Relative Time		: " << relativeTime << "\n\n"
					<< "			EMG_DATA[0]		: " << (int)EMG_Data[0] << "\n"
					<< "			EMG_DATA[1]		: " << (int)EMG_Data[1] << "\n"
					<< "			EMG_DATA[2]		: " << (int)EMG_Data[2] << "\n"
					<< "			EMG_DATA[3]		: " << (int)EMG_Data[3] << "\n"
					<< "			EMG_DATA[4]		: " << (int)EMG_Data[4] << "\n"
					<< "			EMG_DATA[5]		: " << (int)EMG_Data[5] << "\n"
					<< "			EMG_DATA[6]		: " << (int)EMG_Data[6] << "\n"
					<< "			EMG_DATA[7]		: " << (int)EMG_Data[7] << "\n\n\n";
		

				// footer
				std::cout << "		Writing to "	 << filename << "\n";
				std::cout << "		Writing to COM4" <<   "\n";
				std::cout << "		some magic  :" << steps <<"\n";

			}
#pragma endregion

#pragma region COM sender
			// only record/send when device is connected
			if (collector.getConnectionStatus() == Connected)
			{
				// writing to File
				valueFile	<< collector.getRotation_pitch()		<< " "
							<< collector.getRotation_roll()			<< " "
							<< collector.getRotation_yaw()			<< " "
							<< collector.getGyroscope().x()			<< " "
							<< collector.getGyroscope().y()			<< " "
							<< collector.getGyroscope().z()			<< " "
							<< collector.getAccelerometer().x()		<< " "
							<< collector.getAccelerometer().y()		<< " "
							<< collector.getAccelerometer().z()		<< " "
							<< (int)EMG_Data[0]						<< " "
							<< (int)EMG_Data[1]						<< " "
							<< (int)EMG_Data[2]						<< " "
							<< (int)EMG_Data[3]						<< " "
							<< (int)EMG_Data[4]						<< " "
							<< (int)EMG_Data[5]						<< " "
							<< (int)EMG_Data[6]						<< " "
							<< (int)EMG_Data[7]						<< " "
							<< relativeTime							<< "\n";

				// SERIAL COM PORT PART 
				std::string measurement;


				
				// Rotation (from gyroscope)
				measurement.append(std::to_string(collector.getRotation_roll())); measurement.append(" ");
				measurement.append(std::to_string(collector.getRotation_pitch())); measurement.append(" ");
				measurement.append(std::to_string(collector.getRotation_yaw())); measurement.append(" ");

				
				// Gyroscope
				measurement.append(std::to_string(collector.getGyroscope().x())); measurement.append(" ");
				measurement.append(std::to_string(collector.getGyroscope().y())); measurement.append(" ");
				measurement.append(std::to_string(collector.getGyroscope().z())); measurement.append(" ");   

				//Accelerometer
				measurement.append(std::to_string(collector.getAccelerometer().x())); measurement.append(" ");
				measurement.append(std::to_string(collector.getAccelerometer().y())); measurement.append(" ");
				measurement.append(std::to_string(collector.getAccelerometer().z())); measurement.append(" ");
							
				measurement.append(std::to_string(relativeTime)); measurement.append(" \n");
				
				/*	//  some EMG data
				measurement.append(std::to_string((int)EMG_Data[5])); measurement.append(" ");
				measurement.append(std::to_string((int)EMG_Data[6])); measurement.append(" ");
				measurement.append(std::to_string((int)EMG_Data[7])); measurement.append(" \n");
				*/


				char messageBuffer[512];
				strncpy(messageBuffer, measurement.c_str(), sizeof(messageBuffer));
				COM.Write(messageBuffer, measurement.length());
			}
#pragma endregion
			

		}
		// If a standard exception occurred, we print out its message and exit.
	}
	catch (const std::exception& e) {
		std::cerr << "Error: " << e.what() << std::endl;
		std::cerr << "something Fucked up ! ... Ryan: \" niet mijn probleem\"";
		std::cin.ignore();
		return 1;
	}
}
