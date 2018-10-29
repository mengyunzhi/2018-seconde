#pragma once
#include <iostream>
#include "Track1.h"
#include "Track2.h"
#include "Track3.h"
using namespace std;
class Menu
{
public:
	Menu();
	~Menu();
	void cinFirstRow(Track1 & track1);
	void cinSecondRow(Track1 & temp);
	void coutOperationSequence(Track1 & track1, Track1 & temp);	
};

