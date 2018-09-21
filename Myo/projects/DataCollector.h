
#ifndef DATACOLLECTOR_H
#define DATACOLLECTOR_H

#include <myo/myo.hpp>
#include <array>

#pragma once
class DataCollector : public myo::DeviceListener
{

private:

	/// raw data
	myo::Quaternion<float> rotation_r;
	myo::Vector3<float> gyroscope;
	myo::Vector3<float> accelerometer;
	std::array<int8_t, 8> EMG;

	/// calculated data
	float	rotation_roll;
	float	rotation_pitch;
	float	rotation_yaw;

	/// device information
	uint8_t batteryLevel;
	int8_t BluetoothRange;
	bool connectionStatus;

public:
	DataCollector();

	/// Sensor 
	void onOrientationData(myo::Myo* myo, uint64_t timestamp, const myo::Quaternion<float>& rotation);
	void onAccelerometerData(myo::Myo* myo, uint64_t timestamp, const myo::Vector3<float>& accel);
	void onGyroscopeData(myo::Myo* myo, uint64_t timestamp, const myo::Vector3<float>& gyro);
	void onEmgData(myo::Myo* myo, uint64_t timestamp, const int8_t* emg); // WARNING not implemented returns 0

	/// device status
	void onBatteryLevelReceived(myo::Myo* myo, uint64_t timestamp, uint8_t level);
	void onRssi(myo::Myo* myo, uint64_t timestamp, int8_t rssi);
	void onConnect(myo::Myo* myo, uint64_t timestamp, myo::FirmwareVersion firmwareVersion);
	void onDisconnect(myo::Myo* myo, uint64_t timestamp);

	/// Raw SensorValues
	myo::Quaternion<float>	getRotation()		{ return rotation_r; }
	myo::Vector3<float>		getGyroscope()		{ return gyroscope; }
	myo::Vector3<float>		getAccelerometer()	{ return accelerometer; }
	void					getEMG( std::array<int8_t, 8> *data)
												{ if (data != NULL)	*data = EMG; }

	/// calculated data
	float getRotation_roll()	{ return rotation_roll; }
	float getRotation_pitch()	{ return rotation_pitch; }
	float getRotation_yaw()		{ return rotation_yaw; }

	///device status
	uint8_t	getBatteryLevel()	{ return batteryLevel; }
	int8_t	getBluetoothRange()	{ return BluetoothRange; }
	bool getConnectionStatus()  { return connectionStatus; }
};

#endif //DATACOLLECTOR_H