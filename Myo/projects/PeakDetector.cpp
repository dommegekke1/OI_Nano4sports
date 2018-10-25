#include "PeakDetector.h"
#include <algorithm>
#include <vector>

template <class T>
PeakDetector<T>::PeakDetector(int measureLength, T minimumSampleDifference, T minimumPeakThreshold, T mimimumPeakOffset)
{
    if (measureLength <= 4  || !(measureLength %2))	throw "measureLength";
    
    this->measureLength = measureLength;
    this->minimumPeakThreshold = minimumPeakThreshold;
    this->minimumSampleDifference = minimumSampleDifference;
	this->mimimumPeakOffset = mimimumPeakOffset;

    lastSample	= 0;
    currentDirection = 0;
    lastDetectedPeek = 0;
	
	peak = PeakType::noneDetected;
	Direction.resize(measureLength);	
	RawData.resize(measureLength);
}

template <class T>
PeakDetector<T>::~PeakDetector()
{
}

template <class T>
PeakType PeakDetector<T>::GetPeak()
{
	return peak;
}

template <class T>
T PeakDetector<T>::GetRawPeekValue()
{
	return RawData[measureLength / 2];
}

template <class T>
void PeakDetector<T>::Calculate(T sample)
{
	peak = PeakType::noneDetected;
	lastDetectedPeek++;

    if      (lastSample < sample - minimumSampleDifference)		{ currentDirection = -1; }
    else if (lastSample > sample + minimumSampleDifference)		{ currentDirection =  1; }
    else														{ return; }

    lastSample = sample;
	
	std::rotate(Direction.begin(), Direction.begin() + 1, Direction.end());
	std::rotate(RawData.begin(), RawData.begin() + 1, RawData.end());

    Direction[measureLength - 1] = currentDirection;
	
    if (Average(Direction, measureLength) == 0 && lastDetectedPeek > measureLength)
    {
		if (sample >= mimimumPeakOffset + minimumPeakThreshold)
		{
			peak = PeakType::positive;
			lastDetectedPeek = 0;
		}
		else if (sample <= (mimimumPeakOffset + (minimumPeakThreshold - (minimumPeakThreshold *2))) )
		{
			peak = PeakType::negative;
			lastDetectedPeek = 0;
		}     
    }
}


template <class T>
int PeakDetector<T>::Average(std::vector<int> array, size_t arrayLength)
{
	int average = 0;
	for (int i = 0; i < arrayLength; i++)
	{
		average += array[i];
	}
	return average;
}


template class PeakDetector<int>;
template class PeakDetector<unsigned int>;
template class PeakDetector<float>;
template class PeakDetector<double>;
template class PeakDetector<long>;