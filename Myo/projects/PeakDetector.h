#ifndef PEAKDETECTOR_H
#define PEAKDETECTOR_H

#include <vector>


/*
Code that invokes template functions must have matching 
template function declarations. Declarations must include 
the same template parameters as the definition. The following 
sample generates LNK2019 on a user-defined operator, and shows 
how to fix it.*/


enum PeakType: uint8_t { positive, negative, noneDetected};

template <class T>
class PeakDetector
{
	public:
	PeakDetector(int measureLength, T minimumSampleDifference, T minimumPeakThreshold, T mimimumPeakOffset);
	~PeakDetector();

	

	void Calculate(T Sample);
	PeakType GetPeak();
	T GetRawPeekValue();

private:
	int Average(std::vector<int> array, size_t arrayLength);

	int measureLength;
	T minimumSampleDifference;
	T minimumPeakThreshold;
	T mimimumPeakOffset;

	T lastSample;
	PeakType peak;

    

    int currentDirection;
    std::vector<int> Direction;
	std::vector<T> RawData;
    int lastDetectedPeek;
};

#endif
