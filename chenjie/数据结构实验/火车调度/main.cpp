#include<iostream>
#include "Track1.h"
#include "Menu.h"
using namespace std;
int main()
{
	Menu menu;
	Track1 track1;
	Track1 temp;
	menu.cinFirstRow(track1);
	menu.cinSecondRow(temp);
	menu.coutOperationSequence(track1, temp);
	return 0;
}