#include "StepCalculator.h"
#include <algorithm>
#include <vector>

StepCalculator::StepCalculator(int measureLength, float measurementThreshold, float triggerThreshold)
{
    if (measureLength < 0 || measureLength > 20)
    {
        // this is not done 
        throw "measureLength";
    }

    this->measureLength = measureLength;
    this->triggerThreshold = triggerThreshold;
    directionThreshold = measurementThreshold;

    lastMeasurement = 0;
    currentDirection = 0;
    lastDetectedPeek = 0;
	Direction.resize(measureLength);
	Last_Directions.reserve(measureLength);
	
}

StepCalculator::~StepCalculator()
{

}


bool StepCalculator::GetStep()
{
	return this->step;
}

int StepCalculator::GetDebugArrayOut()
{
	return this->DEBUG_arrayOUT;
}

void StepCalculator::Calculate(float Sample)
{
    step = false;
    int average = 0;

    if      (lastMeasurement < Sample - directionThreshold)    { currentDirection = -1; }
    else if (lastMeasurement > Sample + directionThreshold)    { currentDirection = 1; }
    else                                                       { return; }

    lastMeasurement = Sample;

	shiftLeft(&Direction, measureLength);
    Direction[measureLength - 1] = currentDirection;
    lastDetectedPeek++;

    for (int i = 0; i < measureLength; i++)
    {
        average += Direction[i];
    }

	kijk = Sample;

    DEBUG_arrayOUT = average;
    if (average == 0 && lastDetectedPeek > measureLength)
    {
		if (Sample >= triggerThreshold)
		{
			step = true;
			lastDetectedPeek = 0;
		}
		else if (Sample <= (triggerThreshold - (triggerThreshold*2)) )
		{
			step = true;
			lastDetectedPeek = 0;

			if (kijk > 1)
			{

			}
		}
        
    }
}

void StepCalculator::shiftLeft(std::vector<int> *vector, size_t vectorSize)
{
	std::rotate(vector->begin(), vector->begin() + 1, vector->end());
	
    //for (size_t i = 1; i < vectorSize; ++i)
   // {
	//	vector[i - 1] = vector[i];
   // }
}