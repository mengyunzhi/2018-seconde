#include "Track3.h"



Track3::Track3()
{
}


Track3::~Track3()
{
}

bool Track3::toTrack2(Track2 &track2)
{
	char temp;
	if (pop(temp) && track2.push(temp)) {
		return true;
	}else return false;
}