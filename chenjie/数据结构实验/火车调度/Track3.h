#pragma once
#include "Track2.h"
class Track3 :
	public Track2
{
public:
	Track3();
	~Track3();
	bool toTrack2(Track2 &);		// 将栈顶元素移到车厢2
	
};

