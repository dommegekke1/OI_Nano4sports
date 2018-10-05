#ifndef STEPCALCULATOR_H
#define STEPCALCULATOR_H

#include <vector>
#include <iostream>

class StepCalculator
{
public:

	StepCalculator(int measureLength, float measurementThreshold, float triggerThreshold);
	~StepCalculator();

	bool GetStep();
	int GetDebugArrayOut();

	void Calculate(float Sample);

private:
    void shiftLeft(std::vector<int> *array, size_t arraySize);

    bool step;
	int DEBUG_arrayOUT;

    float lastMeasurement;
    int measureLength;

    int currentDirection;
    std::vector<int> Direction;
	std::vector<int> Last_Directions;
    int lastDetectedPeek;

    float directionThreshold;
    float triggerThreshold;
};

#endif